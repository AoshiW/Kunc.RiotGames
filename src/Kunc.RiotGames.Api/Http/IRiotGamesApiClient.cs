
namespace Kunc.RiotGames.Api.Http;

public interface IRiotGamesApiClient
{
    Task<HttpResponseMessage> SendAsync(RiotRequestMessage request, RiotRequestOptions options, CancellationToken cancellationToken = default);
}
