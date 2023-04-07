using System.Net.Http.Json;
using System.Text.Json;

namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

public partial class LolLeagueClientUpdate : IDisposable
{
    /// <summary>
    /// Gets or sets the lockfile used by the client.
    /// </summary>
    /// <remarks>
    /// Changing the lockfile will update the client's base address and authentication headers.
    /// </remarks>
    public Lockfile Lockfile
    {
        get => _lockfile;
        set
        {
            ArgumentNullException.ThrowIfNull(value);
            _lockfile = value;
            Client.BaseAddress = new Uri($"https://127.0.0.1:{_lockfile.Port}/");
            Client.DefaultRequestHeaders.Authorization = _lockfile.ToAuthenticationHeaderValue();
            _ = _wamp.CloseAsync(default).ConfigureAwait(false);
        }
    }
    private Lockfile _lockfile = default!;
    private bool _disposedValue;

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
    /// <param name="lockfile"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public LolLeagueClientUpdate(Lockfile lockfile)
    {
        ArgumentNullException.ThrowIfNull(lockfile);
        var clientHandler = new HttpClientHandler()
        {
            ClientCertificateOptions = ClientCertificateOption.Manual,
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator,
        };
        Client = new HttpClient(clientHandler);
        _wamp = new(this);
        _wamp.OnMessage += OnMessage;
        Lockfile = lockfile;
    }

    public Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage, CancellationToken cancellationToken = default)
    {
        return Client.SendAsync(httpRequestMessage, cancellationToken);
    }

    public async Task<HttpResponseMessage> SendAsync<T>(HttpMethod method, string requestUri, T value, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(requestUri);
        using var request = new HttpRequestMessage(method, requestUri)
        {
            Content = JsonContent.Create(value, typeof(T), null, options),
        };
        return await Client.SendAsync(request, cancellationToken).ConfigureAwait(false);
    }

    public Task<HttpResponseMessage> PostdAsync<T>(string requestUri, T value, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default)
    {
        return SendAsync<T>(HttpMethod.Post, requestUri, value, options, cancellationToken);
    }

    public Task<HttpResponseMessage> PutdAsync<T>(string requestUri, T value, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default)
    {
        return SendAsync<T>(HttpMethod.Put, requestUri, value, options, cancellationToken);
    }

    public Task<T?> GetAsync<T>(string requestUri, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(requestUri);
        return Client.GetFromJsonAsync<T>(requestUri, options, cancellationToken);
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
        if (!_disposedValue && disposing)
        {
            _cancellationTokenSource?.Dispose();
            Client.Dispose();
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
