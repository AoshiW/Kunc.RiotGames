using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Kunc.RiotGames.Api.Http.Handlers;

internal class LogRequestHandler : DelegatingHandler
{
    private readonly ILogger<RiotGamesApiClient> _logger;

    public LogRequestHandler(ILogger<RiotGamesApiClient>? logger = null)
    {
        _logger = logger ?? NullLogger<RiotGamesApiClient>.Instance;
    }

    protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        throw new NotSupportedException("Use SendAsync, Send isn't supported");
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var startTime = Stopwatch.GetTimestamp();

        var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

        var elapsed = Stopwatch.GetElapsedTime(startTime);
        _logger.LogRequest(request.RequestUri, response.StatusCode, elapsed);
        return response;
    }
}
