using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Kunc.RiotGames.Api.Http;

public class RiotGamesApiClient : IRiotGamesApiClient
{
    private readonly HttpClient _client = new();
    private readonly RiotGamesApiOptions _options;
    private readonly IRiotGamesRateLimiter _rateLimiter;
    private readonly ILogger<RiotGamesApiClient> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="RiotGamesApiClient"/> class.
    /// </summary>
    public RiotGamesApiClient(IOptions<RiotGamesApiOptions> options, IRiotGamesRateLimiter rateLimiter, ILogger<RiotGamesApiClient>? logger = null)
    {
        _options = options.Value;
        _rateLimiter = rateLimiter;
        _logger = logger ?? NullLogger<RiotGamesApiClient>.Instance;
    }

    /// <inheritdoc/>
    public async Task<HttpResponseMessage> SendAsync(RiotRequestMessage request, RiotRequestOptions options, CancellationToken cancellationToken = default)
    {
        int retries = 0;
        List<Exception>? exceptions = null;
        do
        {
            // first check the methodRl, then appRl!
            using var methodRl = await _rateLimiter.AcquireMethodAsync(request.Host, request.MethodId, cancellationToken);
            using var appRl = await _rateLimiter.AcquireAppAsync(request.Host, cancellationToken);
            retries++;
            using var httpRequestMessage = request.ToHttpRequestMessage();
            if (options.IncludeApiKey)
                httpRequestMessage.Headers.Add(ApiConstants.RiotToken, _options.ApiKey);
            var response = await _client.SendAsync(httpRequestMessage, cancellationToken).ConfigureAwait(false);

            await _rateLimiter.UpdateAsync(request.Host, request, response, cancellationToken);
            if (response.IsSuccessStatusCode || response.StatusCode is HttpStatusCode.NotFound)
                return response;

            exceptions ??= new();
            var msg = await ReadErrorMessageAsync(response.Content, cancellationToken).ConfigureAwait(false);
            exceptions.Add(new HttpRequestException(msg, null, response.StatusCode));

            if (response.StatusCode is HttpStatusCode.TooManyRequests)
            {
                var delay = response.Headers.RetryAfter?.Delta ?? _options.Delay;
                var rateLimitType = "Unknow";
                if (response.Headers.TryGetValues(ApiConstants.RateLimitType, out var rlt) && (rateLimitType = rlt.First()) == "method")
                {
                    appRl.Dispose();
                }
                _logger.HitRateLimits(request.Host, request.MethodId, delay, rateLimitType);
                await Task.Delay(delay, cancellationToken).ConfigureAwait(false);
            }
            else if (response.StatusCode is >= (HttpStatusCode)400 and < (HttpStatusCode)500)
            {
                throw exceptions[^1];
            }
            else if (response.StatusCode is >= (HttpStatusCode)500 and < (HttpStatusCode)600)
            {
                await Task.Delay(_options.Delay, cancellationToken).ConfigureAwait(false);
            }
        } while (retries < 5);
        var lastException = exceptions[^1];
        throw new AggregateException($"Request failed after {retries} attempts.", exceptions);
    }

    /// <inheritdoc/>
    public async Task<T?> SendAndDeserializeAsync<T>(RiotRequestMessage request, RiotRequestOptions options, CancellationToken cancellationToken = default)
    {
        var response = await SendAsync(request, options, cancellationToken).ConfigureAwait(false);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<T>(_options.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
        }
        return default;
    }


    async ValueTask<string> ReadErrorMessageAsync(HttpContent content, CancellationToken cancellationToken)
    {
        var jsonElement = await content.ReadFromJsonAsync<JsonElement>(_options.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
        var msg = jsonElement.TryGetProperty("status"u8, out var status) &&
                    status.TryGetProperty("message"u8, out var message) &&
                    message.ValueKind == JsonValueKind.String
                    ? message.ToString()
                    : string.Empty;
        return msg;
    }
}
