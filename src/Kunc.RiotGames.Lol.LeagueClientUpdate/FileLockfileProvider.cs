using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

public class FileLockfileProvider : ILockfileProvider
{
    private FileSystemWatcher? _fileSystemWatcher;
    private readonly PeriodicTimer _timer;
    private readonly ILogger<FileLockfileProvider> _logger;
    private Lockfile? _lockfile;
    private bool _disposedValue;
    private bool isProccesFound;
    private string? _filePath;

    /// <inheritdoc/>
    public event EventHandler<LockFileCreatedEventArgs>? Created;

    /// <inheritdoc/>
    public event EventHandler? Deleted;

    /// <summary>
    /// Initializes a new instance of the <see cref="FileLockfileProvider"/> class.
    /// </summary>
    public FileLockfileProvider(ILogger<FileLockfileProvider>? logger = null, TimeProvider? timeProvider = null)
    {
        _logger = logger ?? NullLogger<FileLockfileProvider>.Instance;
        _timer = new(TimeSpan.FromSeconds(5), timeProvider ?? TimeProvider.System);
        _ = CheckProcessAsync(default);
    }

    private async Task CheckProcessAsync(CancellationToken cancellationToken)
    {
        while (await _timer.WaitForNextTickAsync(cancellationToken))
        {
            var processes = Process.GetProcessesByName("LeagueClientUx");
            if (processes.Length == 0)
            {
                _logger.LogProcessNotFound();
                continue;
            }
            foreach (var process in processes)
            {
                if (process.MainModule is not null)
                {
                    _timer.Period = Timeout.InfiniteTimeSpan;
                    var filenamePath = process.MainModule.FileName;
                    var path = Path.GetDirectoryName(filenamePath)!;
                    _filePath = Path.Join(path, "lockfile");
                    _logger.LogProcessFound();
                    InitFileSystemWatcher(path);
                    return;
                }
            }
            _logger.LogProcessFoundNotPath();
        } 
    }

    private void InitFileSystemWatcher(string path)
    {
        _fileSystemWatcher = new (path, "lockfile")
        {
            NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.Attributes,
            EnableRaisingEvents = true,
        };
        _fileSystemWatcher.Created += FileSystemWatcherEvent;
        _fileSystemWatcher.Deleted += FileSystemWatcherEvent;
        FileSystemWatcherEvent(_fileSystemWatcher, new(WatcherChangeTypes.Created, path, "lockfile"));

    }

    /// <inheritdoc/>
    public ValueTask<Lockfile?> GetLockfileAsync(CancellationToken cancellationToken = default)
    {
        ObjectDisposedException.ThrowIf(_disposedValue, this);

        return _lockfile is not null || _filePath is null
            ? ValueTask.FromResult<Lockfile?>(_lockfile)
            : FromFileAsync(_filePath, cancellationToken);

        static async ValueTask<Lockfile?> FromFileAsync(string path, CancellationToken cancellationToken)
        {
            using var stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using var reader = new StreamReader(stream);
            var lockfile = await reader.ReadToEndAsync(cancellationToken).ConfigureAwait(false);
            return Lockfile.Parse(lockfile.AsSpan().Trim(), null);
        }
    }


    private async void FileSystemWatcherEvent(object sender, FileSystemEventArgs e)
    {
        if (e.Name is not "lockfile")
            return;

        switch (e.ChangeType)
        {
            case WatcherChangeTypes.Created:
                try
                {
                    _lockfile = await GetLockfileAsync(default).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    return;
                }
                Debug.Assert(_lockfile is not null);

                _logger.LogCreate(_lockfile);
                Created?.Invoke(this, new()
                {
                    Lockfile = _lockfile,
                });
                break;
            case WatcherChangeTypes.Deleted:
                _lockfile = default;
                _logger.LogDelete();
                Deleted?.Invoke(this, EventArgs.Empty);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Releases the unmanaged resources and optionally disposes of the managed resources.
    /// </summary>
    /// <param name="disposing">
    /// <see langword="true"/> to release both managed and unmanaged resources;
    /// <see langword="false"/> to releases only unmanaged resources.
    /// </param>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                _fileSystemWatcher?.Dispose();
            }
            _disposedValue = true;
        }
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
