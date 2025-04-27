using System.Net;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Kunc.RiotGames.Api.Http.Handlers;

public class RateLimiterHandler : DelegatingHandler
{
    private readonly IRiotGamesRateLimiter _rateLimiter;
    private readonly ILogger<RateLimiterHandler> _logger;
    private readonly RiotGamesApiOptions _options;

    /// <summary>
    /// Initializes a new instance of the <see cref="RateLimiterHandler"/> class.
    /// </summary>
    public RateLimiterHandler(IRiotGamesRateLimiter rateLimiter, IOptions<RiotGamesApiOptions> options, ILogger<RateLimiterHandler>? logger = null)
    {
        _rateLimiter = rateLimiter;
        _logger = logger ?? NullLogger<RateLimiterHandler>.Instance;
        _options = options.Value;
    }

    /// <summary>
    ///  Throw <see cref="NotSupportedException"/>.
    /// </summary>
    /// <exception cref="NotSupportedException"></exception>
    protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        throw new NotSupportedException("Use SendAsync, Send isn't supported");
    }

    /// <inheritdoc/>
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (!request.Options.TryGetValue(RequestInfo.HttpRequestOptionsKey, out var requestInfo))
        {
            _logger.LogMissingRequestInfo("Rate limiter skipped");
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }

        // first check the methodRl, then appRl!
        using var methodRl = await _rateLimiter.AcquireMethodAsync(requestInfo.Host, requestInfo.MethodId, cancellationToken).ConfigureAwait(false);
        using var appRl = await _rateLimiter.AcquireAppAsync(requestInfo.Host, cancellationToken).ConfigureAwait(false);

        var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

        await _rateLimiter.UpdateAsync(requestInfo, request, response, cancellationToken).ConfigureAwait(false);

        if (response.StatusCode is HttpStatusCode.TooManyRequests)
        {
            var delay = response.Headers.RetryAfter?.Delta ?? _options.Delay;
            if (response.Headers.TryGetValues(ApiConstants.Headers.RateLimitType, out var rateLimitType) && rateLimitType.First() == "method")
            {
                appRl.Dispose();
            }
            _logger.HitRateLimits(requestInfo.Host, requestInfo.MethodId, delay, rateLimitType?.First() ?? "Unknow");
            await Task.Delay(delay, cancellationToken).ConfigureAwait(false);
        }
        return response;
    }
}
