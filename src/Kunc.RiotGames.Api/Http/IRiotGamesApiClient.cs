
namespace Kunc.RiotGames.Api.Http;

public interface IRiotGamesApiClient
{
    Task<T?> SendAndDeserializeAsync<T>(RiotRequestMessage request, RiotRequestOptions options, CancellationToken cancellationToken = default);
    Task<HttpResponseMessage> SendAsync(RiotRequestMessage request, RiotRequestOptions options, CancellationToken cancellationToken = default);
}
