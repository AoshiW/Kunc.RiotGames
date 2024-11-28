using System.Buffers;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Unicode;

namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

public sealed class Lockfile : IEquatable<Lockfile?>, ISpanFormattable, ISpanParsable<Lockfile>, IUtf8SpanFormattable, IUtf8SpanParsable<Lockfile>
{
    /// <summary>
    /// Represent a Lockfile with default values.
    /// </summary>
    public static Lockfile Empty => _empty ??= new(string.Empty, 0, 0, string.Empty, string.Empty);
    private static Lockfile? _empty;

    /// <summary>
    /// Process name.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Process id.
    /// </summary>
    public int ProcessID { get; }

    /// <summary>
    /// Process port.
    /// </summary>
    public int Port { get; }

    public string Password { get; }
    public string Protocol { get; }

    /// <summary>
    ///  Initializes a new instance of the <see cref="Lockfile"/> class.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="processID"></param>
    /// <param name="port"></param>
    /// <param name="password"></param>
    /// <param name="protocol"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public Lockfile(string name, int processID, int port, string password, string protocol)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(password);
        ArgumentNullException.ThrowIfNull(protocol);
        ArgumentOutOfRangeException.ThrowIfNegative(processID);
        ArgumentOutOfRangeException.ThrowIfNegative(port);
        Name = name;
        ProcessID = processID;
        Port = port;
        Password = password;
        Protocol = protocol;
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        return Equals(obj as Lockfile);
    }

    /// <inheritdoc/>
    public bool Equals(Lockfile? other)
    {
        return other is not null &&
               Name == other.Name &&
               ProcessID == other.ProcessID &&
               Port == other.Port &&
               Password == other.Password &&
               Protocol == other.Protocol;
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return HashCode.Combine(Name, ProcessID, Port, Password, Protocol);
    }

    /// <inheritdoc/>
    public static Lockfile Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        return TryParse(s, provider, out var lockfile)
            ? lockfile
            : throw new FormatException();
    }

    /// <inheritdoc/>
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out Lockfile result)
    {
        result = default;
        Span<Range> slices = stackalloc Range[6];
        if (s.Split(slices, ':') != 5)
            return false;

        var name = s[slices[0]];
        var numberProcessId = s[slices[1]];
        var numberPort = s[slices[2]];
        var password = s[slices[3]];
        var protocol = s[slices[4]];

        if (int.TryParse(numberProcessId, provider, out var processId) && int.TryParse(numberPort, provider, out var port))
        {
            //name and protocol should be the same value every time
            const string defaultName = "LeagueClient";
            var nameStr = name.SequenceEqual(defaultName) ? defaultName : name.ToString();
            var protocolStr = protocol.SequenceEqual(Uri.UriSchemeHttps) ? Uri.UriSchemeHttps : protocol.ToString();

            result = new Lockfile(nameStr, processId, port, password.ToString(), protocolStr);
            return true;
        }
        return false;
    }

    /// <inheritdoc/>
    public static Lockfile Parse(string s, IFormatProvider? provider)
    {
        ArgumentNullException.ThrowIfNull(s);
        return Parse(s.AsSpan(), provider);
    }

    /// <inheritdoc/>
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Lockfile result)
    {
        return TryParse(s.AsSpan(), provider, out result);
    }


    /// <inheritdoc/>
    public static Lockfile Parse(ReadOnlySpan<byte> utf8Text, IFormatProvider? provider)
    {
        return TryParse(utf8Text, provider, out var lockfile)
            ? lockfile
            : throw new FormatException();
    }

    /// <inheritdoc/>
    public static bool TryParse(ReadOnlySpan<byte> utf8Text, IFormatProvider? provider, [MaybeNullWhen(false)] out Lockfile result)
    {
        char[]? array = null;
        Span<char> buffer = utf8Text.Length < 32
            ? stackalloc char[utf8Text.Length]
            : (array = ArrayPool<char>.Shared.Rent(utf8Text.Length));
        var c = Encoding.UTF8.GetChars(utf8Text, array);
        var isParsed = TryParse(buffer.Slice(0, c), provider, out result);
        if (array is not null)
            ArrayPool<char>.Shared.Return(array);
        return isParsed;
    }

    /// <summary>
    /// Create <see cref="AuthenticationHeaderValue"/> from lockfile.
    /// </summary>
    /// <returns></returns>
    public AuthenticationHeaderValue ToAuthenticationHeaderValue()
    {
        ReadOnlySpan<byte> user = "riot:"u8;
        var bytesCount = Encoding.ASCII.GetByteCount(Password);
        Span<byte> bytes = stackalloc byte[bytesCount + user.Length];

        user.CopyTo(bytes);
        Encoding.ASCII.GetBytes(Password, bytes.Slice(5));

        var base64 = Convert.ToBase64String(bytes);
        return new("Basic", base64);
    }

    /// <summary>
    /// Create <see cref="NetworkCredential"/> from lockfile.
    /// </summary>
    /// <returns></returns>
    public NetworkCredential ToCredential()
    {
        return new("riot", Password);
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return ToString(null, null);
    }

    /// <inheritdoc/>
    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        return $"{Name}:{ProcessID}:{Port}:{Password}:{Protocol}";
    }

    /// <inheritdoc/>
    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
    {
        return destination.TryWrite($"{Name}:{ProcessID}:{Port}:{Password}:{Protocol}", out charsWritten);
    }

    /// <inheritdoc/>
    public bool TryFormat(Span<byte> utf8Destination, out int bytesWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
    {
        return Utf8.TryWrite(utf8Destination, $"{Name}:{ProcessID}:{Port}:{Password}:{Protocol}", out bytesWritten);
    }
}
