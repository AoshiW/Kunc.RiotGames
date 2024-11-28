using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

[Experimental("KNCRG0000", UrlFormat = "https://github.com/AoshiW/Kunc.RiotGames/blob/dev/DiagnosticIds.md#{0}")]
public sealed class ProcessArgsLockfileProvider : ILockfileProvider
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
    private readonly ILogger<ProcessArgsLockfileProvider> _logger;
    private Lockfile? _lastLockfile;

    /// <inheritdoc/>
    public event EventHandler<LockFileCreatedEventArgs>? Created;

    /// <inheritdoc/>
    public event EventHandler? Deleted;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProcessArgsLockfileProvider"/> class.
    /// </summary>
    public ProcessArgsLockfileProvider(ILogger<ProcessArgsLockfileProvider>? logger, TimeProvider? timeProvider = null)
    {
        // todo add suppourt for MacOS?
        if (!OperatingSystem.IsWindows())
            throw new PlatformNotSupportedException();
        _timer = new PeriodicTimer(TimeSpan.FromSeconds(7), timeProvider ?? TimeProvider.System);
        _logger = logger ?? NullLogger<ProcessArgsLockfileProvider>.Instance;

        _ = CheckProcessAsync(_cancellationTokenSource.Token);
    }

    async Task CheckProcessAsync(CancellationToken cancellationToken)
    {
        while (await _timer.WaitForNextTickAsync(cancellationToken))
        {
            Lockfile? newLockfile;
            try
            {
                newLockfile = await GetLockfileAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogInfoException(ex);
                continue;
            }
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
    public async ValueTask<Lockfile?> GetLockfileAsync(CancellationToken cancellationToken = default)
    {
        _process.Start();
        var output = await _process.StandardOutput.ReadToEndAsync(cancellationToken);
        var lockfile = output.AsSpan().Trim().IsEmpty
            ? default
            : ExtrackLockfile(output.AsSpan().Trim());
        return lockfile;
    }

    private static Lockfile ExtrackLockfile(ReadOnlySpan<char> s)
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
