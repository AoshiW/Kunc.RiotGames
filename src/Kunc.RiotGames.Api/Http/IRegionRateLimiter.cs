using System.Threading.RateLimiting;

namespace Kunc.RiotGames.Api.Http;

public interface IRegionRateLimiter
{
    ValueTask<RateLimitLease> AcquireAppAsync(CancellationToken cancellationToken);
    ValueTask<RateLimitLease> AcquireMethodAsync(string methodId, CancellationToken cancellationToken);
    void Updade(RiotRequestMessage request, HttpResponseMessage response);
}
