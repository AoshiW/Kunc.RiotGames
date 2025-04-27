using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Kunc.RiotGames.Api.Http.Handlers;

// todo this is probably not needed with httpClientFactory
public class LogRequestHandler : DelegatingHandler
{
    private readonly ILogger<LogRequestHandler> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="LogRequestHandler"/> class.
    /// </summary>
    public LogRequestHandler(ILogger<LogRequestHandler>? logger = null)
    {
        _logger = logger ?? NullLogger<LogRequestHandler>.Instance;
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
        var startTime = Stopwatch.GetTimestamp();

        var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

        var elapsed = Stopwatch.GetElapsedTime(startTime);
        _logger.LogRequest(request.RequestUri, response.StatusCode, elapsed);
        return response;
    }
}
