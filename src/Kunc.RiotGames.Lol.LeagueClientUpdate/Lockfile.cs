using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

public sealed class Lockfile : IEquatable<Lockfile?>
#if NET7_0_OR_GREATER
, ISpanParsable<Lockfile>
#endif
{
    public static string DefaulthPath
        => OperatingSystem.IsWindows() ? Path.Combine("C:", "Riot Games", "League of Legends", "lockfile")
        : throw new PlatformNotSupportedException();

    const char Separator = ':';
    public string Name { get; }
    public int ProcessID { get; }
    public int Port { get; }
    public string Password { get; }
    public string Protocol { get; }

    public Lockfile(string name, int processID, int port, string password, string protocol)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(password);
        ArgumentNullException.ThrowIfNull(protocol);
        Name = name;
        ProcessID = processID;
        Port = port;
        Password = password;
        Protocol = protocol;
    }

    public static async Task<Lockfile> FromFileAsync(string? path = null)
    {
        path ??= DefaulthPath;
        using var stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        using var reader = new StreamReader(stream);
        var lockfile = await reader.ReadToEndAsync();
        return Parse(lockfile, null);
    }

    /// <inheritdoc/>
    public override string ToString() 
        => $"{Name}{Separator}{ProcessID}{Separator}{Port}{Separator}{Password}{Separator}{Protocol}";

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
            var index = span.IndexOf(Separator);
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

    public NetworkCredential ToCredential() => new("riot", Password);
}
