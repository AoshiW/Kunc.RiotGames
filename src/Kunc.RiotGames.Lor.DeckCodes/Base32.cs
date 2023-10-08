namespace Kunc.RiotGames.Lor.DeckCodes;

[Flags]
internal enum Base32FormattingOptions
{
    None,
    RemovePadding
}

internal static class Base32
{
    private static readonly Dictionary<char, int> CharMap = new(60);
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
            if (!CharMap.TryGetValue(item, out var value))
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
    public static bool TryToBase32(ReadOnlySpan<byte> bytes, Span<char> chars, Base32FormattingOptions options, out int w)
    {
        w = 0;
        var length = GetCharCount(bytes, options);
        if (chars.Length < length)
            return false;
        byte b1, b2, b3, b4, b5;
        int offset = 0;
        while (offset + 5 <= bytes.Length)
        {
            b1 = bytes[offset++];
            b2 = bytes[offset++];
            b3 = bytes[offset++];
            b4 = bytes[offset++];
            b5 = bytes[offset++];

            chars[w++] = Alphabet[b1 >> 3];
            chars[w++] = Alphabet[((b1 & 0x07) << 2) | (b2 >> 6)];
            chars[w++] = Alphabet[(b2 >> 1) & 0x1f];
            chars[w++] = Alphabet[((b2 & 0x01) << 4) | (b3 >> 4)];
            chars[w++] = Alphabet[((b3 & 0x0f) << 1) | (b4 >> 7)];
            chars[w++] = Alphabet[(b4 >> 2) & 0x1f];
            chars[w++] = Alphabet[((b4 & 0x3) << 3) | (b5 >> 5)];
            chars[w++] = Alphabet[b5 & 0x1f];
        }

        if (w == length)
            return true;
#pragma warning disable CA2201 // Do not raise reserved exception types
        var numCharsToOutput = (bytes.Length - offset) switch
        {
            1 => 2,
            2 => 4,
            3 => 5,
            4 => 7,
            _ => throw new Exception("UnreachableException"), // 8, this should not happen 
        };
#pragma warning restore CA2201 // Do not raise reserved exception types

        b1 = (offset < bytes.Length) ? bytes[offset++] : default;
        b2 = (offset < bytes.Length) ? bytes[offset++] : default;
        chars[w++] = (numCharsToOutput >= 1) ? Alphabet[b1 >> 3] : PaddingChar;
        chars[w++] = (numCharsToOutput >= 2) ? Alphabet[((b1 & 0x07) << 2) | (b2 >> 6)] : PaddingChar;

        if (w == length)
            return true;
        b3 = (offset < bytes.Length) ? bytes[offset++] : default;
        chars[w++] = (numCharsToOutput >= 3) ? Alphabet[(b2 >> 1) & 0x1f] : PaddingChar;
        chars[w++] = (numCharsToOutput >= 4) ? Alphabet[((b2 & 0x01) << 4) | (b3 >> 4)] : PaddingChar;

        if (w == length)
            return true;
        b4 = (offset < bytes.Length) ? bytes[offset++] : default;
        chars[w++] = (numCharsToOutput >= 5) ? Alphabet[(int)(((b3 & 0x0f) << 1) | (b4 >> 7))] : PaddingChar;

        if (w == length)
            return true;
        b5 = (offset < bytes.Length) ? bytes[offset++] : default;
        chars[w++] = (numCharsToOutput >= 6) ? Alphabet[(b4 >> 2) & 0x1f] : PaddingChar;
        chars[w++] = (numCharsToOutput >= 7) ? Alphabet[((b4 & 0x3) << 3) | (b5 >> 5)] : PaddingChar;

        if (w == length)
            return true;
        chars[w] = (numCharsToOutput >= 8) ? Alphabet[b5 & 0x1f] : PaddingChar;
        return true;
    }
}
