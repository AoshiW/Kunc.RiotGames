using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames;

[JsonConverter(typeof(RiotIdConverter))]
public sealed class RiotId : ISpanParsable<RiotId>, ISpanFormattable
{
    public string GameName { get; }

    public string TagLine { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="RiotId"/> class.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    public RiotId(string gameName, string tagLine)
    {
        ArgumentNullException.ThrowIfNull(gameName);
        ArgumentNullException.ThrowIfNull(tagLine);
        GameName = gameName;
        TagLine = tagLine;
    }

    /// <inheritdoc/>
    public static RiotId Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        return TryParse(s, provider, out var result)
            ? result
            : throw new FormatException();
    }

    /// <inheritdoc/>
    public static RiotId Parse(string s, IFormatProvider? provider)
    {
        ArgumentNullException.ThrowIfNull(s);
        return Parse(s.AsSpan(), provider);
    }

    /// <inheritdoc/>
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out RiotId result)
    {
        result = default;
        var index = s.IndexOf('#');
        if (index is -1)
            return false;

        var gameName = s.Slice(0, index).ToString();
        var tagLine = s.Slice(index + 1).ToString();

        result = new(gameName, tagLine);
        return true;
    }

    /// <inheritdoc/>
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out RiotId result)
    {
        return TryParse(s.AsSpan(), provider, out result);
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"{GameName}#{TagLine}";
    }

    /// <inheritdoc/>
    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        return ToString();
    }

    /// <inheritdoc/>
    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
    {
        return destination.TryWrite($"{GameName}#{TagLine}", out charsWritten);
    }
}
