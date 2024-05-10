using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

public class FileLockfileProvider : ILockfileProvider
{
    private readonly FileSystemWatcher _fileSystemWatcher;
    private readonly ILogger<FileLockfileProvider> _logger;
    private readonly string _filePath;
    private Lockfile? _lockfile;
    private bool _disposedValue;

    /// <inheritdoc/>
    public event EventHandler<Lockfile>? Created;

    /// <inheritdoc/>
    public event EventHandler? Deleted;

    protected virtual string LockfileDirectory =>
        OperatingSystem.IsWindows() ? @"C:\Riot Games\League of Legends\"
        : throw new PlatformNotSupportedException();

    /// <summary>
    /// Initializes a new instance of the <see cref="FileLockfileProvider"/> class.
    /// </summary>
    public FileLockfileProvider(ILogger<FileLockfileProvider>? logger = null)
    {
        _logger = logger ?? NullLogger<FileLockfileProvider>.Instance;
        _filePath = Path.Combine(LockfileDirectory, "lockfile");
        _fileSystemWatcher = new FileSystemWatcher(LockfileDirectory, "lockfile")
        {
            NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.Attributes, 
            EnableRaisingEvents = true,
        };
        _fileSystemWatcher.Created += FileSystemWatcherEvent;
        _fileSystemWatcher.Deleted += FileSystemWatcherEvent;
    }

    /// <inheritdoc/>
    public ValueTask<Lockfile?> GetLockfileAsync(CancellationToken cancellationToken = default)
    {
        ObjectDisposedException.ThrowIf(_disposedValue, GetType());

        return _lockfile is not null
            ? ValueTask.FromResult<Lockfile?>(_lockfile)
            : GetLockfileAsyncCore(_filePath, cancellationToken);

        static async ValueTask<Lockfile?> GetLockfileAsyncCore(string path, CancellationToken cancellationToken)
        {
            if(!File.Exists(path))
                return default;
            return await Lockfile.FromFileAsync(path, cancellationToken).ConfigureAwait(false);
        }
    }

    private void FileSystemWatcherEvent(object sender, FileSystemEventArgs e)
    {
        if (e.Name is not "lockfile")
            return;

        switch (e.ChangeType)
        {
            case WatcherChangeTypes.Created:
                InvokeCreated();
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

    private async void InvokeCreated()
    {
        _lockfile = await GetLockfileAsync(default).ConfigureAwait(false);
        Debug.Assert(_lockfile is not null);

        _logger.LogCreate(_lockfile);
        Created?.Invoke(this, _lockfile);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                _fileSystemWatcher.Dispose();
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
