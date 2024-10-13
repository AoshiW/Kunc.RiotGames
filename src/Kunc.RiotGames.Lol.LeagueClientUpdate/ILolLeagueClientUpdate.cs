using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

public interface ILolLeagueClientUpdate : IDisposable
{
    Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage, CancellationToken cancellationToken = default);
    public Task<T?> GetFromJsonAsync<T>([StringSyntax(StringSyntaxAttribute.Uri)] string requestUri, CancellationToken cancellationToken = default);
    public Task<HttpResponseMessage> PostAsJsonAsync<T>([StringSyntax(StringSyntaxAttribute.Uri)] string requestUri, T value, CancellationToken cancellationToken = default);
    public Task<HttpResponseMessage> PutAsJsonAsync<T>([StringSyntax(StringSyntaxAttribute.Uri)] string requestUri, T value, CancellationToken cancellationToken = default);

    event EventHandler<LcuEventArgs<JsonElement>>? OnLcuEvent;
    Task ConnectWampAsync(CancellationToken token = default);
    Task CloseWampAsync(CancellationToken token = default);

    IDisposable Subscribe(LcuEventAttribute attribute, Delegate eventHandler);
    IDisposable Subscribe([StringSyntax(StringSyntaxAttribute.Uri)] string uri, Delegate eventHandler);
    IDisposable Subscribe(Delegate eventHandler);
    IDisposable[] SubscribeAll<T>(T? target = null, MethodOptions options = MethodOptions.Public | MethodOptions.Instance) where T : class;
    int UnsubscribeAll();
}
