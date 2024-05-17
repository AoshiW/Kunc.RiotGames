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

using System.Buffers;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Kunc.RiotGames.Lor.DeckCodes;

// https://www.meziantou.net/fastest-way-to-enumerate-a-list-t.htm

/// <inheritdoc cref="ILorDeckEncoder"/>
public class LorDeckEncoder : ILorDeckEncoder
{
    private const int MaxVersion = 5;
    private const int Format = 1;
    private const int InitialVersion = 1;
    private const int CardCodeLength = 7;
    private static readonly Dictionary<int, string> IntIdentifierToFactionCode;
    private static readonly Dictionary<uint, (int Identifier, int LibraryVersion)> FactionCodeInfo = new()
    {
        { ConvertFactionToUInt("DE"), (0, 1) },
        { ConvertFactionToUInt("FR"), (1, 1) },
        { ConvertFactionToUInt("IO"), (2, 1) },
        { ConvertFactionToUInt("NX"), (3, 1) },
        { ConvertFactionToUInt("PZ"), (4, 1) },
        { ConvertFactionToUInt("SI"), (5, 1) },
        { ConvertFactionToUInt("BW"), (6, 2) },
        { ConvertFactionToUInt("SH"), (7, 3) },
        { ConvertFactionToUInt("MT"), (9, 2) },
        { ConvertFactionToUInt("BC"), (10, 4) },
        { ConvertFactionToUInt("RU"), (12, 5) },
    };

    static LorDeckEncoder()
    {
        IntIdentifierToFactionCode = new(FactionCodeInfo.Count);
        foreach (var item in FactionCodeInfo)
        {
            IntIdentifierToFactionCode.Add(item.Value.Identifier, string.Create(2, item.Key, static (s, arg) =>
            {
                s[0] = (char)(arg >> 16);
                s[1] = (char)arg;
            }));
        }
    }

    /// <remarks>
    /// Convert Span (2 char) to uint is more efficient than ToString().
    /// </remarks>
    private static uint ConvertFactionToUInt(ReadOnlySpan<char> span) => (uint)span[0] << 16 | span[1];

    /// <inheritdoc/>
    public List<T> GetDeckFromCode<T>(ReadOnlySpan<char> deckCode) where T : IDeckItem, new()
    {
        var length = Base32.GetByteCount(deckCode);
        var bytes = ArrayPool<byte>.Shared.Rent(length);
        var byteSpan = bytes.AsSpan(0, length);

        if (!Base32.TryFromBase32(deckCode, byteSpan, out _))
        {
            ArrayPool<byte>.Shared.Return(bytes);
            throw new ArgumentException("Invalid deck code");
        }

        //grab format and version
        int format = byteSpan[0] >> 4;
        int version = byteSpan[0] & 0xF;
        byteSpan = byteSpan.Slice(1);

        if (version > MaxVersion)
        {
            ArrayPool<byte>.Shared.Return(bytes);
            throw new ArgumentException("The provided code requires a higher version of this library; please update.");
        }

        var result = new List<T>(20);

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
        ArrayPool<byte>.Shared.Return(bytes);
        return result;
    }

    /// <summary>
    /// Create CardCode from given arguments.
    /// </summary>
    /// <param name="set">Set number.</param>
    /// <param name="faction">Faction code.</param>
    /// <param name="number">Card number.</param>
    /// <returns></returns>
#pragma warning disable CA1716 // Identifiers should not match keywords
    protected virtual string CreateCardCode(int set, string faction, int number)
#pragma warning restore CA1716 // Identifiers should not match keywords
    {
        return string.Create(CardCodeLength, (set, faction, number), static (span, arg) =>
        {
            arg.set.TryFormat(span, out _, "00", NumberFormatInfo.InvariantInfo);
            arg.faction.CopyTo(span.Slice(2));
            arg.number.TryFormat(span.Slice(4), out _, "000", NumberFormatInfo.InvariantInfo);
        });
    }

    /// <inheritdoc/>
    public string GetCodeFromDeck<T>(IEnumerable<T> deck) where T : IReadOnlyDeckItem
    {
        ArgumentNullException.ThrowIfNull(deck);
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
        EncodeGroupOf(groupedOf3s, result);
        EncodeGroupOf(groupedOf2s, result);
        EncodeGroupOf(groupedOf1s, result);

        //Cards with 4+ counts are handled differently: simply [count] [card code] for each
        EncodeNOfs(ofN, result);

        return result;
    }

    private static int GetMinSupportedLibraryVersion<T>(IEnumerable<T> deck) where T : IReadOnlyDeckItem
    {
        var max = InitialVersion;
        foreach (var item in deck)
        {
            var facCode = item.CardCode.AsSpan(2, 2);
            if (!FactionCodeInfo.TryGetValue(ConvertFactionToUInt(facCode), out var valueInfo))
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

    private static void EncodeNOfs<T>(List<T> nOfs, List<byte> bytes) where T : IReadOnlyDeckItem
    {
        Span<byte> buffer = stackalloc byte[10];
        foreach (var item in CollectionsMarshal.AsSpan(nOfs))
        {
            VarintTranslator.TryGetVarint(item.Count, buffer, out var w);
            bytes.AddRange(buffer.Slice(0, w));

            ParseCardCode(item.CardCode, out int setNumber, out var factionCode, out int cardNumber);
            int factionNumber = FactionCodeInfo[ConvertFactionToUInt(factionCode)].Identifier;

            VarintTranslator.TryGetVarint(setNumber, buffer, out w);
            bytes.AddRange(buffer.Slice(0, w));

            VarintTranslator.TryGetVarint(factionNumber, buffer, out w);
            bytes.AddRange(buffer.Slice(0, w));

            VarintTranslator.TryGetVarint(cardNumber, buffer, out w);
            bytes.AddRange(buffer.Slice(0, w));
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
        ParseCardCode(code, out set, out faction);
        number = int.Parse(code.Slice(4), NumberFormatInfo.InvariantInfo);
    }
    private static void ParseCardCode(ReadOnlySpan<char> code, out int set, out ReadOnlySpan<char> faction)
    {
        set = int.Parse(code.Slice(0, 2), NumberFormatInfo.InvariantInfo);
        faction = code.Slice(2, 2);
    }

    private static List<List<T>> GetGroupedOfs<T>(List<T> list) where T : IReadOnlyDeckItem
    {
        var result = new List<List<T>>();
        while (list.Count > 0)
        {
            var currentSet = new List<T>(4);

            //get info from last
            var lastIndex = list.Count - 1;
            var lastItem = list[lastIndex];
            ParseCardCode(lastItem.CardCode, out int setNumber, out var factionCode);

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

                if (currentFactionCode.SequenceEqual(factionCode) && int.Parse(currentSetNumberStr, NumberFormatInfo.InvariantInfo) == setNumber)
                {
                    currentSet.Add(list[i]);
                    list.RemoveAt(i);
                }
            }
            result.Add(currentSet);
        }
        return result;
    }

    private static void EncodeGroupOf<T>(List<List<T>> groupOf, List<byte> bytes) where T : IReadOnlyDeckItem
    {
        Span<byte> buffer = stackalloc byte[10];
        VarintTranslator.TryGetVarint(groupOf.Count, buffer, out var w);
        bytes.AddRange(buffer.Slice(0, w));
        foreach (var currentList in CollectionsMarshal.AsSpan(groupOf))
        {
            //how many cards in current group?
            VarintTranslator.TryGetVarint(currentList.Count, buffer, out w);
            bytes.AddRange(buffer.Slice(0, w));

            //what is this group, as identified by a set and faction pair
            string currentCardCode = currentList[0].CardCode;
            ParseCardCode(currentCardCode, out int currentSetNumber, out var currentFactionCode);
            int currentFactionNumber = FactionCodeInfo[ConvertFactionToUInt(currentFactionCode)].Identifier;

            VarintTranslator.TryGetVarint(currentSetNumber, buffer, out w);
            bytes.AddRange(buffer.Slice(0, w));

            VarintTranslator.TryGetVarint(currentFactionNumber, buffer, out w);
            bytes.AddRange(buffer.Slice(0, w));

            //what are the cards, as identified by the third section of card code only now, within this group?
            foreach (var item in CollectionsMarshal.AsSpan(currentList))
            {
                var sequenceNumber = item.CardCode.AsSpan(4, 3);
                int number = int.Parse(sequenceNumber, NumberFormatInfo.InvariantInfo);
                VarintTranslator.TryGetVarint(number, buffer, out w);
                bytes.AddRange(buffer.Slice(0, w));
            }
        }
    }

    private static bool ValidDeckItem<T>(T item) where T : IReadOnlyDeckItem
    {
        var cardCode = item.CardCode.AsSpan();
        if (cardCode.Length != CardCodeLength || item.Count < 1)
            return false;
        var faction = ConvertFactionToUInt(cardCode.Slice(2, 2));
        return FactionCodeInfo.ContainsKey(faction)
            && cardCode.Slice(0, 2).IndexOfAnyExceptInRange('0', '9') == -1
            && cardCode.Slice(4).IndexOfAnyExceptInRange('0', '9') == -1;
    }
}
