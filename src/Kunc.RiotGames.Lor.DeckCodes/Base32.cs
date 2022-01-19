#pragma warning disable IDE0057 // Use range operator
using System;
using System.Collections.Generic;

namespace Kunc.RiotGames.Lor.DeckCodes;

[Flags]
enum Base32FormattingOptions
{
    None,
    RemovePadding
}

class Base32
{
    private static readonly Dictionary<char, int> CharMap = new(Mask + 1);
    private static readonly char[] Alphabet = new[]
    {
        'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
        'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
        'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X',
        'Y', 'Z', '2', '3', '4', '5', '6', '7'
    };
    private const int Mask = 31;
    private const int Shift = 5;
    private const char PaddingChar = '=';

    static Base32()
    {
        for (int i = 0; i < Alphabet.Length; i++) CharMap[Alphabet[i]] = i;
    }

    public static byte[] FromBase32(ReadOnlySpan<char> chars)
    {
        chars = chars.Trim().TrimEnd(PaddingChar);
        if (chars.IsEmpty)
        {
            return Array.Empty<byte>();
        }
        var result = new byte[chars.Length * Shift / 8];
        int buffer = 0;
        int next = 0;
        int bitsLeft = 0;
        foreach (var item in chars)
        {
            var itemUpper = char.ToUpper(item);
            if (!CharMap.TryGetValue(itemUpper, out var value))
            {
                throw new FormatException($"Illegal character: {itemUpper}");
            }
            buffer = buffer << Shift | value & Mask;
            bitsLeft += Shift;
            if (bitsLeft >= 8)
            {
                result[next++] = (byte)(buffer >> bitsLeft - 8);
                bitsLeft -= 8;
            }
        }
        return result;
    }

    public static string ToBase32(ReadOnlySpan<byte> bytes, Base32FormattingOptions options = default)
    {
        if (options < Base32FormattingOptions.None || options > Base32FormattingOptions.RemovePadding)
        {
            throw new ArgumentException($"Illegal enum value: {options}.", nameof(options));
        }
        if (bytes.IsEmpty)
        {
            return string.Empty;
        }
        if (bytes.Length >= 1 << 28)
        {
            throw new ArgumentOutOfRangeException(nameof(bytes));
        }

        int outputLength = (options & Base32FormattingOptions.RemovePadding) == Base32FormattingOptions.RemovePadding
            ? (bytes.Length * 8 + Shift - 1) / Shift
            : (int)Math.Ceiling(bytes.Length / 5.0) * 8;

        unsafe
        {
            fixed (byte* p = bytes)
            {
                return string.Create(outputLength, (Ptr: new IntPtr(p), bytes.Length), (span, arg) =>
                {
                    var data = new ReadOnlySpan<byte>(arg.Ptr.ToPointer(), arg.Length);
                    int spanIndex = 0;
                    int buffer = data[0];
                    int dataIndex = 1;
                    int bitsLeft = 8;
                    while (bitsLeft > 0 || dataIndex < data.Length)
                    {
                        if (bitsLeft < Shift)
                        {
                            if (dataIndex < data.Length)
                            {
                                buffer = buffer << 8 | data[dataIndex++];
                                bitsLeft += 8;
                            }
                            else
                            {
                                int pad = Shift - bitsLeft;
                                buffer <<= pad;
                                bitsLeft += pad;
                            }
                        }
                        int index = Mask & buffer >> bitsLeft - Shift;
                        bitsLeft -= Shift;
                        span[spanIndex++] = Alphabet[index];
                    }
                    if (spanIndex < span.Length)
                        span.Slice(spanIndex).Fill(PaddingChar);
                });
            }
        }
    }
}
