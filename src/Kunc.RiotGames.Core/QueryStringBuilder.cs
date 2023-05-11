using System.Runtime.CompilerServices;

namespace Kunc.RiotGames;

/// <summary>
/// Value builder for building query string.
/// </summary>
public ref struct QueryStringBuilder
{
    readonly DefaultInterpolatedStringHandler _handler;
    bool _hasAny;

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
        var sep = "&";
        if (!_hasAny)
        {
            sep = "?";
            _hasAny = true;
        }
        _handler.AppendLiteral(sep);
        _handler.AppendLiteral(key);
        _handler.AppendLiteral("=");
    }

    public string ToStringAndClear()
    {
        _hasAny = false;
        return _handler.ToStringAndClear();
    }

    public override string ToString()
    {
        return _handler.ToString();
    }
}
