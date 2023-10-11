using System.Diagnostics;

namespace Kunc.RiotGames.Lor.DeckCodes;

[Flags]
internal enum Base32FormattingOptions
{
    None,
    RemovePadding
}

internal static class Base32
{
    private static readonly char[] Alphabet =
    {
        'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
        'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
        'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X',
        'Y', 'Z', '2', '3', '4', '5', '6', '7'
    };
    private static ReadOnlySpan<byte> ReversedMapAlphabet => new byte[]
    {
      //   0     1     2     3     4     5     6     7     8    9     10    11    12    13    14    16
        0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, //  0 -  15
        0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, // 16 -  31
        0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, // 23 -  47
        0xff, 0xff,   26,   27,   28,   29,   30,   31, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, // 48 -  63
        0xff,    0,    1,    2,    3,    4,    5,    6,    7,    8,    9,   10,   11,   12,   13,   14, // 64 -  79
          15,   16,   17,   18,   19,   20,   21,   22,   23,   24,   25, 0xff, 0xff, 0xff, 0xff, 0xff, // 80 -  95
        0xff,    0,    1,    2,    3,    4,    5,    6,    7,    8,    9,   10,   11,   12,   13,   14, // 96 - 111
          15,   16,   17,   18,   19,   20,   21,   22,   23,   24,   25, 0xff, 0xff, 0xff, 0xff, 0xff, //128 - 143
    };
    private const int Mask = 31;
    private const int Shift = 5;
    private const char PaddingChar = '=';

    public static int GetByteCount(ReadOnlySpan<char> chars) => chars.TrimEnd(PaddingChar).Length * Shift / 8;

    public static int GetCharCount(ReadOnlySpan<byte> bytes, Base32FormattingOptions options)
    {
        return options.HasFlag(Base32FormattingOptions.RemovePadding)
            ? (bytes.Length * 8 + Shift - 1) / Shift
            : (int)Math.Ceiling(bytes.Length / (float)Shift) * 8;
    }

    public static byte[] FromBase32(ReadOnlySpan<char> chars)
    {
        var length = GetByteCount(chars);
        if (length == 0)
            return Array.Empty<byte>();
        var bytes = new byte[length];
        return TryFromBase32(chars, bytes, out var w)
            ? bytes
            : throw new FormatException($"Illegal character: {chars[w]}");
    }

    public static bool TryFromBase32(ReadOnlySpan<char> chars, Span<byte> bytes, out int written)
    {
        chars = chars.TrimEnd(PaddingChar);
        written = 0;
        if (chars.IsEmpty)
        {
            return true;
        }
        if (bytes.Length < GetByteCount(chars))
        {
            return false;
        }
        int buffer = 0;
        int bitsLeft = 0;
        foreach (var item in chars)
        {
            byte value;
            if (item >= ReversedMapAlphabet.Length || (value = ReversedMapAlphabet[item]) == 0xff)
            {
                return false;
            }
            buffer = buffer << Shift | value & Mask;
            bitsLeft += Shift;
            if (bitsLeft >= 8)
            {
                bytes[written++] = (byte)(buffer >> bitsLeft - 8);
                bitsLeft -= 8;
            }
        }
        return true;
    }

    public static string ToBase32(ReadOnlySpan<byte> bytes, Base32FormattingOptions options = Base32FormattingOptions.None)
    {
        if (bytes.IsEmpty)
            return string.Empty;
        var length = GetCharCount(bytes, options);
        var base32 = new string('\0', length);
        unsafe
        {
            fixed (char* ptr = base32)
            {
                TryToBase32(bytes, new Span<char>(ptr, length), options, out _);
                return base32;
            }
        }
    }

    public static bool TryToBase32(ReadOnlySpan<byte> bytes, Span<char> chars, Base32FormattingOptions options, out int written)
    {
        written = 0;
        var length = GetCharCount(bytes, options);
        if (chars.Length < length)
            return false;
        byte b0, b1, b2, b3, b4;
        int offset = 0;
        while (offset + 5 <= bytes.Length)
        {
            b0 = bytes[offset++];
            b1 = bytes[offset++];
            b2 = bytes[offset++];
            b3 = bytes[offset++];
            b4 = bytes[offset++];

            chars[written++] = Alphabet[b0 >> 3];
            chars[written++] = Alphabet[((b0 & 0x07) << 2) | (b1 >> 6)];
            chars[written++] = Alphabet[(b1 >> 1) & 0x1f];
            chars[written++] = Alphabet[((b1 & 0x01) << 4) | (b2 >> 4)];
            chars[written++] = Alphabet[((b2 & 0x0f) << 1) | (b3 >> 7)];
            chars[written++] = Alphabet[(b3 >> 2) & 0x1f];
            chars[written++] = Alphabet[((b3 & 0x3) << 3) | (b4 >> 5)];
            chars[written++] = Alphabet[b4 & 0x1f];
        }

        if (written == length)
            return true;
        var numCharsToOutput = (bytes.Length - offset) switch
        {
            1 => 2,
            2 => 4,
            3 => 5,
            4 => 7,
            _ => throw new UnreachableException()
        };

        b0 = (offset < bytes.Length) ? bytes[offset++] : default;
        b1 = (offset < bytes.Length) ? bytes[offset++] : default;
        chars[written++] = (numCharsToOutput >= 1) ? Alphabet[b0 >> 3] : PaddingChar;
        chars[written++] = (numCharsToOutput >= 2) ? Alphabet[((b0 & 0x07) << 2) | (b1 >> 6)] : PaddingChar;

        if (written == length)
            return true;
        b2 = (offset < bytes.Length) ? bytes[offset++] : default;
        chars[written++] = (numCharsToOutput >= 3) ? Alphabet[(b1 >> 1) & 0x1f] : PaddingChar;
        chars[written++] = (numCharsToOutput >= 4) ? Alphabet[((b1 & 0x01) << 4) | (b2 >> 4)] : PaddingChar;

        if (written == length)
            return true;
        b3 = (offset < bytes.Length) ? bytes[offset++] : default;
        chars[written++] = (numCharsToOutput >= 5) ? Alphabet[(((b2 & 0x0f) << 1) | (b3 >> 7))] : PaddingChar;

        if (written == length)
            return true;
        b4 = (offset < bytes.Length) ? bytes[offset++] : default;
        chars[written++] = (numCharsToOutput >= 6) ? Alphabet[(b3 >> 2) & 0x1f] : PaddingChar;
        chars[written++] = (numCharsToOutput >= 7) ? Alphabet[((b3 & 0x3) << 3) | (b4 >> 5)] : PaddingChar;

        if (written == length)
            return true;
        chars[written++] = (numCharsToOutput >= 8) ? Alphabet[b4 & 0x1f] : PaddingChar;
        return true;
    }
}
