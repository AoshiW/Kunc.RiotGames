using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

public sealed class Lockfile : IEquatable<Lockfile?>, ISpanFormattable
#if NET7_0_OR_GREATER
    , ISpanParsable<Lockfile>
#endif
{
    /// <summary>
    /// Represent a Lockfile with default values.
    /// </summary>
    public static Lockfile Empty => _empty ??= new(string.Empty, 0, 0, string.Empty, string.Empty);
    private static Lockfile? _empty;

    /// <summary>
    /// The default path where lockfile is located.
    /// </summary>
    public static string DefaulthPath
        => OperatingSystem.IsWindows() ? @"C:\Riot Games\League of Legends\lockfile"
        : throw new PlatformNotSupportedException();

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
#if NET8_0_OR_GREATER
        ArgumentOutOfRangeException.ThrowIfNegative(processID);
        ArgumentOutOfRangeException.ThrowIfNegative(port);
#else
        if (processID < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(processID), processID, $"'{nameof(processID)}' must be a non-negative value.");
        }
        if (port < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(port), port, $"'{nameof(port)}' must be a non-negative value.");
        }
#endif
        Name = name;
        ProcessID = processID;
        Port = port;
        Password = password;
        Protocol = protocol;
    }

    /// <summary>
    /// Get lockfile from specific path.
    /// </summary>
    /// <remarks>
    /// Unfortunately, the <paramref name="cancellationToken"/> parameter is ignored for .NET 6.
    /// </remarks>
    /// <param name="path">Path to file. If not set, <see cref="DefaulthPath"/> is used.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<Lockfile> FromFileAsync(string? path = null, CancellationToken cancellationToken = default)
    {
        path ??= DefaulthPath;
        using var stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        using var reader = new StreamReader(stream);
        var lockfile = await reader.ReadToEndAsync(
#if NET7_0_OR_GREATER
            cancellationToken
#endif
            ).ConfigureAwait(false);
        return Parse(lockfile, null);
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj) => Equals(obj as Lockfile);

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
    public override int GetHashCode() => HashCode.Combine(Name, ProcessID, Port, Password, Protocol);

    /// <inheritdoc/>
    public static Lockfile Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
        => TryParse(s, provider, out var lockfile)
        ? lockfile
        : throw new FormatException();

    /// <inheritdoc/>
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out Lockfile result)
    {
        if (TryReadNext(ref s, out var name) &&
            TryReadNext(ref s, out var number1) && int.TryParse(number1, NumberStyles.Integer, provider, out var processId) &&
            TryReadNext(ref s, out var number2) && int.TryParse(number2, NumberStyles.Integer, provider, out var port) &&
            TryReadNext(ref s, out var password))
        {
            var protocol = s;
            result = new Lockfile(name.ToString(), processId, port, password.ToString(), protocol.ToString());
            return true;
        }
        result = default;
        return false;

        static bool TryReadNext(ref ReadOnlySpan<char> span, out ReadOnlySpan<char> output)
        {
            var index = span.IndexOf(':');
            if (index == -1)
            {
                output = default;
                return false;
            }
            output = span.Slice(0, index);
            span = span.Slice(index + 1);
            return true;
        }
    }

    /// <inheritdoc/>
    public static Lockfile Parse(string s, IFormatProvider? provider)
    {
        ArgumentNullException.ThrowIfNull(s);
        return Parse(s.AsSpan(), provider);
    }

    /// <inheritdoc/>
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Lockfile result)
        => TryParse(s.AsSpan(), provider, out result);

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
    public NetworkCredential ToCredential() => new("riot", Password);


    /// <inheritdoc/>
    public override string ToString()
        => $"{Name}:{ProcessID}:{Port}:{Password}:{Protocol}";

    /// <inheritdoc/>
    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
        => destination.TryWrite($"{Name}:{ProcessID}:{Port}:{Password}:{Protocol}", out charsWritten);

    /// <inheritdoc/>
    public string ToString(string? format, IFormatProvider? formatProvider)
        => ToString();
}
