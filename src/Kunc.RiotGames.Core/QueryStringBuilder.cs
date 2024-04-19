using System.Runtime.CompilerServices;

namespace Kunc.RiotGames;

/// <summary>
/// Value builder for building query string.
/// </summary>
public ref struct QueryStringBuilder
{
    DefaultInterpolatedStringHandler _handler;

    /// <summary>
    /// Append query string parametr.
    /// </summary>
    /// <typeparam name="T">Type of value.</typeparam>
    /// <param name="key">Parametr name.</param>
    /// <param name="value">Parametr value.</param>
    public void Append<T>(string key, T value)
    {
        AppendKey(key);
        _handler.AppendFormatted(value);
    }

    void AppendKey(string key)
    {
        _handler.AppendLiteral("&");
        _handler.AppendLiteral(key);
        _handler.AppendLiteral("=");
    }

    /// <summary>Gets the built <see cref="string"/> and clears the builder.</summary>
    /// <returns>The built string.</returns>
    public string ToStringAndClear()
    {
        SetFirstChar();
        return _handler.ToStringAndClear();
    }

    /// <summary>Gets the built <see cref="string"/>.</summary>
    /// <returns>The built string.</returns>
    public override string ToString()
    {
        SetFirstChar();
        return _handler.ToString();
    }

    private void SetFirstChar()
    {
        if (DefaultInterpolatedStringHandler_pos(ref _handler) > 0)
            DefaultInterpolatedStringHandler_chars(ref _handler)[0] = '?';

        [UnsafeAccessor(UnsafeAccessorKind.Field, Name = "_chars")]
        static extern ref readonly Span<char> DefaultInterpolatedStringHandler_chars(ref DefaultInterpolatedStringHandler handler);

        [UnsafeAccessor(UnsafeAccessorKind.Field, Name = "_pos")]
        static extern ref readonly int DefaultInterpolatedStringHandler_pos(ref DefaultInterpolatedStringHandler handler);
    }
}
