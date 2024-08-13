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
    public event EventHandler<LockFileCreatedEventArgs>? Created;

    /// <inheritdoc/>
    public event EventHandler? Deleted;

    /// <summary>
    /// Initializes a new instance of the <see cref="FileLockfileProvider"/> class.
    /// </summary>
    public FileLockfileProvider(ILogger<FileLockfileProvider>? logger = null)
    {
        _logger = logger ?? NullLogger<FileLockfileProvider>.Instance;
        var path = GetLockfilePath();
        _filePath = Path.Combine(path, "lockfile");
        _fileSystemWatcher = new FileSystemWatcher(path, "lockfile")
        {
            NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.Attributes, 
            EnableRaisingEvents = true,
        };
        _fileSystemWatcher.Created += FileSystemWatcherEvent;
        _fileSystemWatcher.Deleted += FileSystemWatcherEvent;
    }

    protected virtual string GetLockfilePath()
    {
        // todo get path from process?
        return OperatingSystem.IsWindows() 
            ? @"C:\Riot Games\League of Legends\"
            : throw new PlatformNotSupportedException();
    }

    /// <inheritdoc/>
    public ValueTask<Lockfile?> GetLockfileAsync(CancellationToken cancellationToken = default)
    {
        ObjectDisposedException.ThrowIf(_disposedValue, GetType());

        return _lockfile is not null
            ? ValueTask.FromResult<Lockfile?>(_lockfile)
            : GetLockfileAsyncCore(_filePath, cancellationToken);

        static ValueTask<Lockfile?> GetLockfileAsyncCore(string path, CancellationToken cancellationToken)
        {
            if(!File.Exists(path))
                return default;
            return FromFileAsync(path, cancellationToken)!;
        }
    }

    static async ValueTask<Lockfile> FromFileAsync(string path, CancellationToken cancellationToken = default)
    {
        using var stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        using var reader = new StreamReader(stream);
        var lockfile = await reader.ReadToEndAsync(cancellationToken).ConfigureAwait(false);
        return Lockfile.Parse(lockfile.AsSpan().Trim(), null);
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
        Created?.Invoke(this, new()
        {
            Lockfile = _lockfile,
        });
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
