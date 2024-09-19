using System.Diagnostics;

namespace Kunc.RiotGames.Lor.DeckCodes;

[Flags]
internal enum Base32FormattingOptions
{
    None,
    RemovePadding
}

/// <summary>
/// Convert between binary data and UTF-8 encoded text that is represented in Base32.
/// </summary>
internal static class Base32
{
    private static ReadOnlySpan<char> Alphabet =>
    [
        'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
        'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
        'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X',
        'Y', 'Z', '2', '3', '4', '5', '6', '7'
    ];
    private static ReadOnlySpan<byte> ReversedMapAlphabet =>
    [
      //   0     1     2     3     4     5     6     7     8    9     10    11    12    13    14    15
        0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, //  0 -  15
        0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, // 16 -  31
        0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, // 23 -  47
        0xff, 0xff,   26,   27,   28,   29,   30,   31, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, // 48 -  63
        0xff,    0,    1,    2,    3,    4,    5,    6,    7,    8,    9,   10,   11,   12,   13,   14, // 64 -  79
          15,   16,   17,   18,   19,   20,   21,   22,   23,   24,   25, 0xff, 0xff, 0xff, 0xff, 0xff, // 80 -  95
        0xff,    0,    1,    2,    3,    4,    5,    6,    7,    8,    9,   10,   11,   12,   13,   14, // 96 - 111
          15,   16,   17,   18,   19,   20,   21,   22,   23,   24,   25, 0xff, 0xff, 0xff, 0xff, 0xff, //112 - 127
    ];
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

    /// <summary>
    /// Converts the span containing a string, which encodes binary data as Base32 digits, to the equivalent byte array.
    /// </summary>
    /// <param name="chars">A span containing the string representation that is encoded with Base32 digits.</param>
    /// <returns>The array of bytes represented by the specified Base32 string.</returns>
    /// <exception cref="FormatException"></exception>
    public static byte[] FromBase32(ReadOnlySpan<char> chars)
    {
        var length = GetByteCount(chars);
        if (length == 0)
            return [];
        var bytes = new byte[length];
        return TryFromBase32(chars, bytes, out var w)
            ? bytes
            : throw new FormatException($"Illegal character: {chars[w]}");
    }

    /// <summary>
    /// Tries to convert the specified span containing a string representation that is encoded with Base32 digits into a span of 8-bit unsigned integers.
    /// </summary>
    /// <param name="chars">A span containing the string representation that is encoded with Base32 digits.</param>
    /// <param name="bytes">The span in which to write the converted 8-bit unsigned integers. If this method returns <see langword="false"/>, either the span remains unmodified or contains an incomplete conversion of <paramref name="chars"/>, up to the last valid character.</param>
    /// <param name="written">When this method returns, contains the total number of characters written into <paramref name="bytes"/>.</param>
    /// <returns><see langword="true"/> if the conversion is successful; otherwise, <see langword="false"/>.</returns>
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

    /// <summary>
    /// Converts an span of 8-bit unsigned integers to its equivalent string representation that is encoded with Base32 digits.
    /// </summary>
    /// <param name="bytes">A read-only span of 8-bit unsigned integers.</param>
    /// <param name="options"></param>
    /// <returns>The string representation, in Base32, of the contents of <paramref name="bytes"/>.</returns>
    public static string ToBase32(ReadOnlySpan<byte> bytes, Base32FormattingOptions options = Base32FormattingOptions.None)
    {
        if (bytes.IsEmpty)
            return string.Empty;
        var length = GetCharCount(bytes, options);
        var base32 = new string('\0', length);
        unsafe // TODO remove unsafe in .NET 10, from .NET 9 string.Create allow ref struct as arg
        {
            fixed (char* ptr = base32)
            {
                TryToBase32(bytes, new Span<char>(ptr, length), out _, options);
                return base32;
            }
        }
    }

    /// <summary>
    /// Tries to convert the 8-bit unsigned integers inside the specified read-only span into their equivalent string representation that is encoded with Base32 digits.
    /// </summary>
    /// <param name="bytes">A read-only span of 8-bit unsigned integers.</param>
    /// <param name="chars">The span in which to write the string representation in Base32 of the elements in bytes.</param>
    /// <param name="written">When this method returns, contains the total number of characters written into <paramref name="chars"/>.</param>
    /// <param name="options"></param>
    /// <returns><see langword="true"/> if the conversion is successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryToBase32(ReadOnlySpan<byte> bytes, Span<char> chars, out int written, Base32FormattingOptions options)
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

        Span<char> rest = stackalloc char[8];

        b0 = (offset < bytes.Length) ? bytes[offset++] : default;
        b1 = (offset < bytes.Length) ? bytes[offset++] : default;
        b2 = (offset < bytes.Length) ? bytes[offset++] : default;
        b3 = (offset < bytes.Length) ? bytes[offset++] : default;
        b4 = (offset < bytes.Length) ? bytes[offset++] : default;

        rest[0] = (numCharsToOutput >= 1) ? Alphabet[b0 >> 3] : PaddingChar;
        rest[1] = (numCharsToOutput >= 2) ? Alphabet[((b0 & 0x07) << 2) | (b1 >> 6)] : PaddingChar;
        rest[2] = (numCharsToOutput >= 3) ? Alphabet[(b1 >> 1) & 0x1f] : PaddingChar;
        rest[3] = (numCharsToOutput >= 4) ? Alphabet[((b1 & 0x01) << 4) | (b2 >> 4)] : PaddingChar;
        rest[4] = (numCharsToOutput >= 5) ? Alphabet[((b2 & 0x0f) << 1) | (b3 >> 7)] : PaddingChar;
        rest[5] = (numCharsToOutput >= 6) ? Alphabet[(b3 >> 2) & 0x1f] : PaddingChar;
        rest[6] = (numCharsToOutput >= 7) ? Alphabet[((b3 & 0x3) << 3) | (b4 >> 5)] : PaddingChar;
        rest[7] = (numCharsToOutput >= 8) ? Alphabet[b4 & 0x1f] : PaddingChar;

        rest.Slice(0, length - written).CopyTo(chars.Slice(written));
        written = length;
        return true;
    }
}
