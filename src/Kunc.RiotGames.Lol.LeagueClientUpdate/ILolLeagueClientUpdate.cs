using System.Text.Json;

namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

public interface ILolLeagueClientUpdate : IDisposable
{
    HttpClient Client { get; }
    IWamp Wamp { get; }

    event EventHandler<LcuEventArgs<JsonElement>>? OnLcuEvent;

    Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage, CancellationToken cancellationToken = default);
    Task<HttpResponseMessage> SendAsync<T>(HttpMethod method, string requestUri, T value, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default);
    Task<T?> GetAsync<T>(string requestUri, CancellationToken cancellationToken = default);

    void Subscribe(LcuEventAttribute attribute, Delegate eventHandler);
    void Subscribe(string uri, Delegate eventHandler);
    void Subscribe(Delegate eventHandler);

    bool Unsubscribe(LcuEventAttribute attribute, Delegate eventHandler);
    bool Unsubscribe(string uri, Delegate eventHandler);
    bool Unsubscribe(Delegate eventHandler);

    int SubscribeAll<T>(T? target = null, MethodOptions options = MethodOptions.Public | MethodOptions.Instance) where T : class;

    Task ConnectWampAsync(CancellationToken token = default);
    Task CloseWampAsync(CancellationToken token = default);
}
