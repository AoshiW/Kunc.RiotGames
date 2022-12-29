using System.Net.Http.Json;
using System.Text.Json;

namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

public partial class LolLeagueClientUpdate
{
    public Lockfile Lockfile
    {
        get => _lockfile;
        set
        {
            _lockfile = value;
            Client.BaseAddress = new Uri($"https://127.0.0.1:{_lockfile.Port}/");
            Client.DefaultRequestHeaders.Authorization = _lockfile.ToAuthenticationHeaderValue();
        }
    }
    private Lockfile _lockfile;

    public HttpClient Client { get; }

    public LolLeagueClientUpdate(Lockfile lockfile)
    {
        ArgumentNullException.ThrowIfNull(lockfile);
        var clientHandler = new HttpClientHandler()
        {
            ClientCertificateOptions = ClientCertificateOption.Manual,
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator,
        };
        Client = new HttpClient(clientHandler);
        Lockfile = lockfile;
        Wamp.OnMessage += OnMessage;
    }

    public Task<HttpResponseMessage> SendAsync<T>(HttpMethod method, string requestUri, T value, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default)
    {
        var request = new HttpRequestMessage(method, requestUri)
        {
            Content = JsonContent.Create(value, typeof(T), null, options),
        };
        return Client.SendAsync(request, cancellationToken);
    }

    public Task<T?> GetAsync<T>(string requestUri, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default)
        => Client.GetFromJsonAsync<T>(requestUri, options, cancellationToken);
}
