
namespace Kunc.RiotGames.Api.Http;

public interface IRiotGamesApiClient
{
    Task<T?> SendAndDeserializeAsync<T>(RiotRequestMessage request, CancellationToken cancellationToken = default);
    Task<HttpResponseMessage> SendAsync(RiotRequestMessage request, CancellationToken cancellationToken = default);
}