/*
 * Derived from https://github.com/RiotGames/LoRDeckCodes
 * 
 * Copyright (C) 2019 Riot Games
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System.Runtime.InteropServices;

using CommunityToolkit.HighPerformance.Buffers;

namespace Kunc.RiotGames.Lor.DeckCodes;

// https://www.meziantou.net/fastest-way-to-enumerate-a-list-t.htm

/// <inheritdoc cref="ILorDeckEncoder"/>
public class LorDeckEncoder : ILorDeckEncoder
{
    private const int MaxVersion = 5;
    private const int Format = 1;
    private const int InitialVersion = 1;
    private const int CardCodeLength = 7;
    private static readonly Dictionary<int, string> IntIdentifierToFactionCode = new();
    private static readonly Dictionary<uint, (int Identifier, int LibraryVersion)> FactionCodeInfo = new()
    {
        { ConvertFactionToUint("DE"), (0, 1) },
        { ConvertFactionToUint("FR"), (1, 1) },
        { ConvertFactionToUint("IO"), (2, 1) },
        { ConvertFactionToUint("NX"), (3, 1) },
        { ConvertFactionToUint("PZ"), (4, 1) },
        { ConvertFactionToUint("SI"), (5, 1) },
        { ConvertFactionToUint("BW"), (6, 2) },
        { ConvertFactionToUint("SH"), (7, 3) },
        { ConvertFactionToUint("MT"), (9, 2) },
        { ConvertFactionToUint("BC"), (10, 4) },
        { ConvertFactionToUint("RU"), (12, 5) },
    };

    static LorDeckEncoder()
    {
        foreach (var item in FactionCodeInfo)
        {
            IntIdentifierToFactionCode.Add(item.Value.Identifier, string.Create(2, item.Key, (s, arg) =>
            {
                s[0] = (char)(arg >> 16);
                s[1] = (char)arg;
            }));
        }
    }

    private readonly StringPool? _stringPool;

    /// <summary>
    /// Initializes a new instance of the <see cref="LorDeckEncoder"/> class.
    /// </summary>
    /// <param name="stringPool">A <see cref="StringPool"/> for caching CardCode <see cref="string"/>s, set to <see langword="null"/> for disabled.</param>
    public LorDeckEncoder(StringPool? stringPool)
    {
        _stringPool = stringPool;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="LorDeckEncoder"/> class.
    /// </summary>
    public LorDeckEncoder() : this(new StringPool())
    { }

    /// <remarks>
    /// Convert Span (2 char) to uint is more efficient than ToString().
    /// </remarks>
    private static uint ConvertFactionToUint(ReadOnlySpan<char> span) => (uint)span[0] << 16 | span[1];

    /// <inheritdoc/>
    public List<T> GetDeckFromCode<T>(ReadOnlySpan<char> code) where T : IDeckItem, new()
    {
        using var bytesOwner = SpanOwner<byte>.Allocate(Base32.CalculateLength(code));
        if (!Base32.TryFromBase32(code, bytesOwner.Span, out _))
            throw new ArgumentException("Invalid deck code");
        var byteSpan = bytesOwner.Span;
        var result = new List<T>(20);

        //grab format and version
        int format = byteSpan[0] >> 4;
        int version = byteSpan[0] & 0xF;
        byteSpan = byteSpan.Slice(1);

        if (version > MaxVersion)
        {
            throw new ArgumentException("The provided code requires a higher version of this library; please update.");
        }

        for (int i = 3; i > 0; i--)
        {
            int numGroupOfs = VarintTranslator.PopVarint(ref byteSpan);
            for (int j = 0; j < numGroupOfs; j++)
            {
                int numOfsInThisGroup = VarintTranslator.PopVarint(ref byteSpan);
                int set = VarintTranslator.PopVarint(ref byteSpan);
                int faction = VarintTranslator.PopVarint(ref byteSpan);
                string factionString = IntIdentifierToFactionCode[faction];
                for (int k = 0; k < numOfsInThisGroup; k++)
                {
                    int number = VarintTranslator.PopVarint(ref byteSpan);
                    var newEntry = new T()
                    {
                        CardCode = CreateCardCode(set, factionString, number),
                        Count = i
                    };
                    result.Add(newEntry);
                }
            }
        }

        //the remainder of the deck code is comprised of entries for cards with counts >= 4
        //this will only happen in Limited and special game modes.
        //the encoding is simply [count] [cardcode]
        while (!byteSpan.IsEmpty)
        {
            int count = VarintTranslator.PopVarint(ref byteSpan);
            int set = VarintTranslator.PopVarint(ref byteSpan);
            int faction = VarintTranslator.PopVarint(ref byteSpan);
            int number = VarintTranslator.PopVarint(ref byteSpan);
            var factionStr = IntIdentifierToFactionCode[faction];

            var newEntry = new T()
            {
                CardCode = CreateCardCode(set, factionStr, number),
                Count = count
            };
            result.Add(newEntry);
        }
        return result;
    }

    private string CreateCardCode(int set, string faction, int number)
    {
        Span<char> span = stackalloc char[CardCodeLength];
        set.TryFormat(span, out _, "00");
        faction.CopyTo(span.Slice(2));
        number.TryFormat(span.Slice(4), out _, "000");
        return _stringPool?.GetOrAdd(span) ?? span.ToString();
    }

    /// <inheritdoc/>
    public string GetCodeFromDeck<T>(IEnumerable<T> deck) where T : IReadOnlyDeckItem
    {
        var bytes = GetDeckCodeBytes(deck);
        return Base32.ToBase32(CollectionsMarshal.AsSpan(bytes), Base32FormattingOptions.RemovePadding);
    }

    /// <exception cref="ArgumentException"></exception>
    private static List<byte> GetDeckCodeBytes<T>(IEnumerable<T> deck) where T : IReadOnlyDeckItem
    {
        var of3 = new List<T>();
        var of2 = new List<T>();
        var of1 = new List<T>();
        var ofN = new List<T>();
        foreach (var item in deck)
        {
            if (!ValidDeckItem(item))
                throw new ArgumentException("The provided deck contains invalid card codes or count.");

            if (item.Count == 3)
                of3.Add(item);
            else if (item.Count == 2)
                of2.Add(item);
            else if (item.Count == 1)
                of1.Add(item);
            else
                ofN.Add(item);
        }
        var result = new List<byte>(32)
        {
            (byte)(Format << 4 | GetMinSupportedLibraryVersion(deck) & 0xF) //formatAndVersion
        };

        //build the lists of set and faction combinations within the groups of similar card counts
        var groupedOf3s = GetGroupedOfs(of3);
        var groupedOf2s = GetGroupedOfs(of2);
        var groupedOf1s = GetGroupedOfs(of1);

        //to ensure that the same decklist in any order produces the same code, do some sorting
        SortGroupOf(groupedOf3s);
        SortGroupOf(groupedOf2s);
        SortGroupOf(groupedOf1s);

        //Nofs (since rare) are simply sorted by the card code - there's no optimiziation based upon the card count
        ofN.Sort(static (x, y) => string.Compare(x.CardCode, y.CardCode, StringComparison.Ordinal));

        //Encode
        EncodeGroupOf(result, groupedOf3s);
        EncodeGroupOf(result, groupedOf2s);
        EncodeGroupOf(result, groupedOf1s);

        //Cards with 4+ counts are handled differently: simply [count] [card code] for each
        EncodeNOfs(result, ofN);

        return result;
    }

    private static int GetMinSupportedLibraryVersion<T>(IEnumerable<T> deck) where T : IReadOnlyDeckItem
    {
        var max = InitialVersion;
        foreach (var item in deck)
        {
            var facCode = item.CardCode.AsSpan(2, 2);
            if (!FactionCodeInfo.TryGetValue(ConvertFactionToUint(facCode), out var valueInfo))
                return MaxVersion;
            var value = valueInfo.LibraryVersion;
            if (value > max)
            {
                if (value == MaxVersion)
                    return MaxVersion;
                max = value;
            }
        }
        return max;
    }

    private static void EncodeNOfs<T>(List<byte> bytes, List<T> nOfs) where T : IReadOnlyDeckItem
    {
        foreach (var item in CollectionsMarshal.AsSpan(nOfs))
        {
            bytes.AddRange(VarintTranslator.GetVarint(item.Count));

            ParseCardCode(item.CardCode, out int setNumber, out var factionCode, out int cardNumber);
            int factionNumber = FactionCodeInfo[ConvertFactionToUint(factionCode)].Identifier;

            bytes.AddRange(VarintTranslator.GetVarint(setNumber));
            bytes.AddRange(VarintTranslator.GetVarint(factionNumber));
            bytes.AddRange(VarintTranslator.GetVarint(cardNumber));
        }
    }

    //The sorting convention of this encoding scheme is
    //First by the number of set/faction combinations in each top-level list
    //Second by the alphanumeric order of the card codes within those lists.
    private static void SortGroupOf<T>(List<List<T>> groupOf) where T : IReadOnlyDeckItem
    {
        groupOf.Sort(static (x, y) =>
        {
            var compareCount = x.Count.CompareTo(y.Count);
            return compareCount != 0 ? compareCount : string.Compare(x[0].CardCode, y[0].CardCode, StringComparison.Ordinal);
        });
        foreach (var item in CollectionsMarshal.AsSpan(groupOf))
        {
            item.Sort(static (x, y) => string.Compare(x.CardCode, y.CardCode, StringComparison.Ordinal));
        }
    }

    private static void ParseCardCode(ReadOnlySpan<char> code, out int set, out ReadOnlySpan<char> faction, out int number)
    {
        faction = code.Slice(2, 2);
        set = int.Parse(code.Slice(0, 2));
        number = int.Parse(code.Slice(4));
    }

    private static List<List<T>> GetGroupedOfs<T>(List<T> list) where T : IReadOnlyDeckItem
    {
        List<List<T>> result = new();
        while (list.Count > 0)
        {
            List<T> currentSet = new();

            //get info from last
            var lastIndex = list.Count - 1;
            var lastItem = list[lastIndex];
            ParseCardCode(lastItem.CardCode, out int setNumber, out var factionCode, out _);

            //now add that to our new list, remove from old
            currentSet.Add(lastItem);
            list.RemoveAt(lastIndex);

            //sweep through rest of list and grab entries that should live with our first one.
            //matching means same set and faction - we are already assured the count matches from previous grouping.
            for (int i = list.Count - 1; i >= 0; i--)
            {
                var currentCardCode = list[i].CardCode.AsSpan();
                var currentSetNumberStr = currentCardCode.Slice(0, 2);
                var currentFactionCode = currentCardCode.Slice(2, 2);

                if (currentFactionCode.Equals(factionCode, StringComparison.OrdinalIgnoreCase) && int.Parse(currentSetNumberStr) == setNumber)
                {
                    currentSet.Add(list[i]);
                    list.RemoveAt(i);
                }
            }
            result.Add(currentSet);
        }
        return result;
    }

    private static void EncodeGroupOf<T>(List<byte> bytes, List<List<T>> groupOf) where T : IReadOnlyDeckItem
    {
        bytes.AddRange(VarintTranslator.GetVarint(groupOf.Count));
        foreach (var currentList in CollectionsMarshal.AsSpan(groupOf))
        {
            //how many cards in current group?
            bytes.AddRange(VarintTranslator.GetVarint(currentList.Count));

            //what is this group, as identified by a set and faction pair
            string currentCardCode = currentList[0].CardCode;
            ParseCardCode(currentCardCode, out int currentSetNumber, out var currentFactionCode, out int _);
            int currentFactionNumber = FactionCodeInfo[ConvertFactionToUint(currentFactionCode)].Identifier;
            bytes.AddRange(VarintTranslator.GetVarint(currentSetNumber));
            bytes.AddRange(VarintTranslator.GetVarint(currentFactionNumber));

            //what are the cards, as identified by the third section of card code only now, within this group?
            foreach (var item in CollectionsMarshal.AsSpan(currentList))
            {
                var sequenceNumber = item.CardCode.AsSpan(4, 3);
                int number = int.Parse(sequenceNumber);
                bytes.AddRange(VarintTranslator.GetVarint(number));
            }
        }
    }

    private static bool ValidDeckItem<T>(T item) where T : IReadOnlyDeckItem
    {
        var cardcode = item.CardCode.AsSpan();
        if (cardcode.Length != CardCodeLength || item.Count < 1)
            return false;

        var faction = ConvertFactionToUint(cardcode.Slice(2, 2));
        return FactionCodeInfo.ContainsKey(faction)
            && int.TryParse(cardcode.Slice(0, 2), out _)
            && int.TryParse(cardcode.Slice(4), out _);
    }
}
