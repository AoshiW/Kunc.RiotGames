namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

internal class RateLimiterHandler : DelegatingHandler
{
    private readonly LolLeagueClientUpdateOptions _options;

    public RateLimiterHandler(HttpMessageHandler httpMessageHandler, LolLeagueClientUpdateOptions options) : base(httpMessageHandler)
    {
        ArgumentNullException.ThrowIfNull(options);
        _options = options;
    }

    protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
    {
       throw new NotImplementedException();
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        using var lease = await _options.RateLimiter.AcquireAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
        return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
    }
}
