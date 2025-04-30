using System.Threading.RateLimiting;

namespace Kunc.RiotGames.Lol.LeagueClientUpdate.Handlers;

internal class RateLimiterHandler : DelegatingHandler
{
    private readonly RateLimiter _rateLimiter;

    public RateLimiterHandler(RateLimiter? rateLimiter = null)
    {
        _rateLimiter = rateLimiter ?? new NoopLimiter(); // TODO replace with some RL
    }

    protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
    {
       throw new NotSupportedException();
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        using var lease = await _rateLimiter.AcquireAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
        return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
    }
}
