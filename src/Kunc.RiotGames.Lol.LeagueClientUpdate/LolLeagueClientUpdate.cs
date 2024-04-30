using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

public partial class LolLeagueClientUpdate : IDisposable
{
    private bool _disposedValue;
    private readonly ILogger<LolLeagueClientUpdate> _logger;
    private readonly ILockfileProvider _lockfileProvider;

    /// <summary>
    /// Internal HttpClient for sending requests.
    /// </summary>
    /// <remarks>
    /// Do not call the "Dispose" function!!
    /// </remarks>
    public HttpClient Client { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="LolLeagueClientUpdate"/> class with the specified <see cref="Lockfile"/>.
    /// </summary>
    /// <param name="lockfileProvider"></param>
    /// <param name="wamp"></param>
    /// <param name="loggerFactory"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public LolLeagueClientUpdate(ILockfileProvider lockfileProvider, IWamp? wamp = null, ILoggerFactory? loggerFactory = null)
    {
        ArgumentNullException.ThrowIfNull(lockfileProvider);
        loggerFactory ??= NullLoggerFactory.Instance;
        var clientHandler = new HttpClientHandler()
        {
            ClientCertificateOptions = ClientCertificateOption.Manual,
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator,
        };
        Client = new HttpClient(clientHandler);
        _lockfileProvider = lockfileProvider;
        _lockfileProvider.Created += _lockfileProvider_Created;
        _lockfileProvider.Deleted += _lockfileProviedr_Deleted;
        Wamp = wamp ?? new Wamp(loggerFactory.CreateLogger<Wamp>());
        Wamp.OnMessage += OnMessage;
        _logger = loggerFactory.CreateLogger<LolLeagueClientUpdate>();
        TryInit();
    }

    private async void TryInit()
    {
        var lockfile = await _lockfileProvider.GetLockfileAsync();
        if (lockfile is null)
            return;
        _lockfileProvider_Created(_lockfileProvider, lockfile);
    }

    private void _lockfileProviedr_Deleted(object? sender, EventArgs e)
    {
        Wamp.CloseAsync(default);
        Client.BaseAddress = null;
    }

    private void _lockfileProvider_Created(object? sender, Lockfile e)
    {
        Client.BaseAddress = new Uri($"https://127.0.0.1:{e.Port}/");
        Client.DefaultRequestHeaders.Authorization = e.ToAuthenticationHeaderValue();
        _ = ConnectWampAsyncCore(e, default);
    }

    /// <inheritdoc/>
    public Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage, CancellationToken cancellationToken = default)
    {
        CheckLockfile();
        return Client.SendAsync(httpRequestMessage, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponseMessage> SendAsync<T>(HttpMethod method, string requestUri, T value, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default)
    {
        CheckLockfile();
        ArgumentNullException.ThrowIfNull(requestUri);
        ArgumentNullException.ThrowIfNull(value);
        using var request = new HttpRequestMessage(method, requestUri)
        {
            Content = JsonContent.Create(value, typeof(T), null, options),
        };
        return await Client.SendAsync(request, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<T?> GetAsync<T>(string requestUri, CancellationToken cancellationToken = default)
    {
        CheckLockfile();
        ArgumentNullException.ThrowIfNull(requestUri);
        return Client.GetFromJsonAsync<T>(requestUri, cancellationToken);
    }

    private void CheckLockfile()
    {
        if (Client.BaseAddress is null)
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
                Client.Dispose();
                Wamp.Dispose();
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
