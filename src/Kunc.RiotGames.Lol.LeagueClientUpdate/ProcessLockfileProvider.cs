using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

[Experimental("KNCRG0000", UrlFormat = "https://github.com/AoshiW/Kunc.RiotGames/blob/dev/DiagnosticIds.md#{0}")]
public sealed class ProcessLockfileProvider : ILockfileProvider
{
    private readonly PeriodicTimer _timer;
    private readonly CancellationTokenSource _cancellationTokenSource = new();
    private readonly Process _process = new()
    {
        StartInfo = new()
        {
            WindowStyle = ProcessWindowStyle.Hidden,
            FileName = "cmd.exe",
            // https://hextechdocs.dev/getting-started-with-the-lcu-api/
            Arguments = "/C wmic PROCESS WHERE name='LeagueClientUx.exe' GET commandline",
            RedirectStandardOutput = true,
            RedirectStandardInput = true,
            CreateNoWindow = true,
        }
    };
    private Lockfile? _lastLockfile;

    /// <inheritdoc/>
    public event EventHandler<LockFileCreatedEventArgs>? Created;

    /// <inheritdoc/>
    public event EventHandler? Deleted;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProcessLockfileProvider"/> class.
    /// </summary>
    public ProcessLockfileProvider(TimeProvider? timeProvider = null)
    {
        if (!OperatingSystem.IsWindows())
            throw new PlatformNotSupportedException();
        _timer = new PeriodicTimer(TimeSpan.FromSeconds(1), timeProvider ?? TimeProvider.System);

        _ = CheckProcessAsync(_cancellationTokenSource.Token);
    }

    async Task CheckProcessAsync(CancellationToken cancellationToken)
    {
        while (await _timer.WaitForNextTickAsync(cancellationToken))
        {
            var newLockfile = await GetLockfileAsync(cancellationToken).ConfigureAwait(false);
            if (newLockfile is not null)
            {
                if (!newLockfile.Equals(_lastLockfile))
                {
                    _lastLockfile = newLockfile;
                    Created?.Invoke(this, new()
                    {
                        Lockfile = newLockfile,
                    });
                }
            }
            else if (_lastLockfile is not null)
            {
                _lastLockfile = null;
                Deleted?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        _cancellationTokenSource.Cancel();
        _timer.Dispose();
        _cancellationTokenSource.Dispose();
        _process.Dispose();
    }

    /// <inheritdoc/>
    public ValueTask<Lockfile?> GetLockfileAsync(CancellationToken cancellationToken = default)
    {
        _process.Start();
        var r = _process.StandardOutput.ReadToEnd().AsSpan().Trim();
        var result = r.IsEmpty
            ? default
            : ExtrackLockfile(r);
        return ValueTask.FromResult(result);
    }

    static Lockfile ExtrackLockfile(ReadOnlySpan<char> s)
    {
        return new("LeagueClient", 0, ExtractValue<int>(s, "--app-port="), ExtractValue<string>(s, "--remoting-auth-token="), "https");

        static T ExtractValue<T>(ReadOnlySpan<char> s, ReadOnlySpan<char> key) where T : ISpanParsable<T>
        {
            var index = s.IndexOf(key);
            s = s.Slice(index + key.Length);
            index = s.IndexOf('"');
            s = s.Slice(0, index);
            return T.Parse(s, null);
        }
    }
}
