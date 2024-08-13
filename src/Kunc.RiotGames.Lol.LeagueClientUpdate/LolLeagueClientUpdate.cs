using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

public partial class LolLeagueClientUpdate
{
    private readonly HttpClient _client;
    private readonly ILogger<LolLeagueClientUpdate> _logger;
    private readonly ILockfileProvider _lockfileProvider;
    private readonly Task _initTask;
    private readonly LolLeagueClientUpdateOptions _options;
    private bool _disposedValue;

    /// <summary>
    /// Initializes a new instance of the <see cref="LolLeagueClientUpdate"/> class with the specified <see cref="Lockfile"/>.
    /// </summary>
    /// <param name="options"></param>
    /// <param name="lockfileProvider"></param>
    /// <param name="wamp"></param>
    /// <param name="logger"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public LolLeagueClientUpdate(IOptions<LolLeagueClientUpdateOptions> options, ILockfileProvider lockfileProvider, IWamp wamp, ILogger<LolLeagueClientUpdate>? logger = null)
    {
        ArgumentNullException.ThrowIfNull(options);
        ArgumentNullException.ThrowIfNull(lockfileProvider);
        ArgumentNullException.ThrowIfNull(wamp);
        _options = options.Value;
        var clientHandler = new HttpClientHandler()
        {
            ClientCertificateOptions = ClientCertificateOption.Manual,
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator,
        };
        _client = new HttpClient(clientHandler);
        _lockfileProvider = lockfileProvider;
        _lockfileProvider.Created += _lockfileProvider_Created;
        _lockfileProvider.Deleted += _lockfileProviedr_Deleted;
        _wamp = wamp;
        _wamp.OnMessage += OnMessage;
        _logger = logger ?? NullLogger<LolLeagueClientUpdate>.Instance;
        _initTask = InitLockFileAsync();
    }

    private async Task InitLockFileAsync()
    {
        var lockfile = await _lockfileProvider.GetLockfileAsync().ConfigureAwait(false);
        if (lockfile is null)
            return;
        _lockfileProvider_Created(_lockfileProvider, new()
        {
            Lockfile = lockfile,
        });
    }

    private void _lockfileProviedr_Deleted(object? sender, EventArgs e)
    {
        _wamp.CloseAsync(default);
        _client.BaseAddress = null;
    }

    private void _lockfileProvider_Created(object? sender, LockFileCreatedEventArgs e)
    {
        _client.BaseAddress = new Uri($"https://127.0.0.1:{e.Lockfile.Port}/");
        _client.DefaultRequestHeaders.Authorization = e.Lockfile.ToAuthenticationHeaderValue();
        if (_options.AutoReconnectToWamp)
            _ = ConnectWampAsyncCore(e.Lockfile, default);
    }

    /// <inheritdoc/>
    public Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage, CancellationToken cancellationToken = default)
    {
        CheckLockfile();
        return _client.SendAsync(httpRequestMessage, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<T?> GetFromJsonAsync<T>([StringSyntax(StringSyntaxAttribute.Uri)] string requestUri, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(requestUri);
        CheckLockfile();
        return _client.GetFromJsonAsync<T>(requestUri, _options.JsonSerializerOptions, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponseMessage> PostAsJsonAsync<T>([StringSyntax(StringSyntaxAttribute.Uri)] string requestUri, T value, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(requestUri);
        ArgumentNullException.ThrowIfNull(value);
        CheckLockfile();
        return _client.PostAsJsonAsync(requestUri, value, _options.JsonSerializerOptions, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponseMessage> PutAsJsonAsync<T>([StringSyntax(StringSyntaxAttribute.Uri)] string requestUri, T value, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(requestUri);
        ArgumentNullException.ThrowIfNull(value);
        CheckLockfile();
        return _client.PutAsJsonAsync(requestUri, value, _options.JsonSerializerOptions, cancellationToken);
    }

    private void CheckLockfile()
    {
        if (!_initTask.IsCompleted)
            _initTask.Wait(); 
        if (_client.BaseAddress is null)
            throw new InvalidOperationException("Lockfile data is not available.");
    }

    /// <summary>
    /// Releases the unmanaged resources used by the <see cref="LolLeagueClientUpdate"/> and optionally disposes of the managed resources.
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
                _cancellationTokenSource?.Dispose();
                _client.Dispose();
                _wamp.Dispose();
            }
            _lockfileProvider.Created -= _lockfileProvider_Created;
            _lockfileProvider.Deleted -= _lockfileProviedr_Deleted;
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
