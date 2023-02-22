namespace Kunc.RiotGames.Lor.DeckCodes;

[Flags]
internal enum Base32FormattingOptions
{
    None,
    RemovePadding
}

internal class Base32
{
    private static readonly Dictionary<char, int> CharMap = new(Mask + 1);
    private static readonly char[] Alphabet =
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
        for (int i = 0; i < Alphabet.Length; i++)
        {
            CharMap[Alphabet[i]] = i;
            CharMap[char.ToLowerInvariant(Alphabet[i])] = i;
        }
    }

    // Derived from https://github.com/RiotGames/LoRDeckCodes/blob/main/LoRDeckCodes/Base32.cs under apache2
    /// <summary>
    /// Converts the specified (case insensitive) string, which encodes binary data as base32 digits, to an equivalent 8-bit unsigned integer array.
    /// </summary>
    /// <param name="chars">A span containing the string representation that is encoded with base32 digits.</param>
    /// <returns>An array of 8-bit unsigned integers that is equivalent to <paramref name="chars"/>.</returns>
    /// <exception cref="FormatException"></exception>
    public static byte[] FromBase32(ReadOnlySpan<char> chars)
    {
        var length = CalculateLength(chars);
        if (length == 0)
            return Array.Empty<byte>();
        var result = new byte[length];
        return TryFromBase32(chars, result, out var written)
            ? result
            : throw new FormatException($"Illegal character: {chars[written]}");
    }

    public static int CalculateLength(ReadOnlySpan<char> chars)
        => chars.TrimEnd(PaddingChar).Length * Shift / 8;

    public static bool TryFromBase32(ReadOnlySpan<char> chars, Span<byte> span, out int written)
    {
        chars = chars.TrimEnd(PaddingChar);
        written = 0;
        if (chars.IsEmpty)
        {
            return true;
        }
        if (span.Length < CalculateLength(chars))
        {
            return false;
        }
        int buffer = 0;
        int bitsLeft = 0;
        foreach (var item in chars)
        {
            if (!CharMap.TryGetValue(item, out var value))
            {
                return false;
            }
            buffer = buffer << Shift | value & Mask;
            bitsLeft += Shift;
            if (bitsLeft >= 8)
            {
                span[written++] = (byte)(buffer >> bitsLeft - 8);
                bitsLeft -= 8;
            }
        }
        return true;
    }

    // Derived from https://github.com/dotnet/aspnetcore/blob/5fa80eb167ac3ae2c03590b135379fc3e3621175/src/Identity/Extensions.Core/src/Base32.cs under MIT
    /// <summary>
    /// Converts the 8-bit unsigned integers inside the specified read-only span into their equivalent string representation that is encoded with base-64 digits.
    /// </summary>
    /// <param name="bytes">A read-only span of 8-bit unsigned integers.</param>
    /// <param name="options">One of the enumeration. The default value is <see cref="Base32FormattingOptions.None"/>.</param>
    /// <returns>The string representation in base32 of the elements in Array. If the length of bytes is 0, an empty string is returned.</returns>
    /// <exception cref="ArgumentException"><paramref name="options"/> is not a <see cref="Base32FormattingOptions"/> value.</exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
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

        int outputLength = options.HasFlag(Base32FormattingOptions.RemovePadding)
            ? (bytes.Length * 8 + Shift - 1) / Shift
            : (int)Math.Ceiling(bytes.Length / 5.0) * 8;

        var str = new string('\0', outputLength);
        unsafe
        {
            fixed (char* s = str)
            {
                int wi = 0;
                uint b1, b2, b3, b4, b5;
                int offset = 0;
                while (offset + 5 <= bytes.Length)
                {
                    b1 = bytes[offset++];
                    b2 = bytes[offset++];
                    b3 = bytes[offset++];
                    b4 = bytes[offset++];
                    b5 = bytes[offset++];

                    s[wi++] = Alphabet[(int)(b1 >> 3)];
                    s[wi++] = Alphabet[(int)(((b1 & 0x07) << 2) | (b2 >> 6))];
                    s[wi++] = Alphabet[(int)((b2 >> 1) & 0x1f)];
                    s[wi++] = Alphabet[(int)(((b2 & 0x01) << 4) | (b3 >> 4))];
                    s[wi++] = Alphabet[(int)(((b3 & 0x0f) << 1) | (b4 >> 7))];
                    s[wi++] = Alphabet[(int)((b4 >> 2) & 0x1f)];
                    s[wi++] = Alphabet[(int)(((b4 & 0x3) << 3) | (b5 >> 5))];
                    s[wi++] = Alphabet[(int)(b5 & 0x1f)];
                }

                if (wi == str.Length)
                    return str;
                var numCharsToOutput = (bytes.Length - offset) switch
                {
                    1 => 2,
                    2 => 4,
                    3 => 5,
                    4 => 7,
                    _ => throw new Exception("UnreachableException"), // 8, this should not happen 
                };

                b1 = (offset < bytes.Length) ? bytes[offset++] : 0U;
                b2 = (offset < bytes.Length) ? bytes[offset++] : 0U;
                s[wi++] = (numCharsToOutput >= 1) ? Alphabet[(int)(b1 >> 3)] : PaddingChar;
                s[wi++] = (numCharsToOutput >= 2) ? Alphabet[(int)(((b1 & 0x07) << 2) | (b2 >> 6))] : PaddingChar;

                if (wi == str.Length)
                    return str;
                b3 = (offset < bytes.Length) ? bytes[offset++] : 0U;
                s[wi++] = (numCharsToOutput >= 3) ? Alphabet[(int)((b2 >> 1) & 0x1f)] : PaddingChar;
                s[wi++] = (numCharsToOutput >= 4) ? Alphabet[(int)(((b2 & 0x01) << 4) | (b3 >> 4))] : PaddingChar;

                if (wi == str.Length)
                    return str;
                b4 = (offset < bytes.Length) ? bytes[offset++] : 0U;
                s[wi++] = (numCharsToOutput >= 5) ? Alphabet[(int)(((b3 & 0x0f) << 1) | (b4 >> 7))] : PaddingChar;

                if (wi == str.Length)
                    return str;
                b5 = (offset < bytes.Length) ? bytes[offset++] : 0U;
                s[wi++] = (numCharsToOutput >= 6) ? Alphabet[(int)((b4 >> 2) & 0x1f)] : PaddingChar;
                s[wi++] = (numCharsToOutput >= 7) ? Alphabet[(int)(((b4 & 0x3) << 3) | (b5 >> 5))] : PaddingChar;

                if (wi == str.Length)
                    return str;
                s[wi] = (numCharsToOutput >= 8) ? Alphabet[(int)(b5 & 0x1f)] : PaddingChar;
            }
        }
        return str;
    }
}
