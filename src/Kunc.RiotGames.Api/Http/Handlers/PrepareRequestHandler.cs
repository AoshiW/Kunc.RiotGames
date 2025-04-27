using Microsoft.Extensions.Options;

namespace Kunc.RiotGames.Api.Http.Handlers;

public class PrepareRequestHandler : DelegatingHandler
{
    private readonly RiotGamesApiOptions _options;

    /// <summary>
    /// Initializes a new instance of the <see cref="PrepareRequestHandler"/> class.
    /// </summary>
    public PrepareRequestHandler(IOptions<RiotGamesApiOptions> options)
    {
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
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (request.Options.TryGetValue(RequestInfo.HttpRequestOptionsKey, out var requestInfo) && requestInfo.IncludeApiKey)
        {
            request.Headers.Add(ApiConstants.Headers.RiotToken, _options.ApiKey);
        }
        return base.SendAsync(request, cancellationToken);
    }
}
