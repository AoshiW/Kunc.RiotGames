using System.Threading.RateLimiting;

namespace Kunc.RiotGames.Api.Http;

public interface IRiotGamesRateLimiter
{
    ValueTask<RateLimitLease> AcquireAppAsync(string region, CancellationToken cancellationToken);

    ValueTask<RateLimitLease> AcquireMethodAsync(string region, string methodId, CancellationToken cancellationToken);

    ValueTask UpdateAsync(RequestInfo requestInfo, HttpRequestMessage request, HttpResponseMessage response, CancellationToken cancellationToken);
}
