using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Kunc.RiotGames.Api.Http;

public class RiotGamesApiClient : IRiotGamesApiClient
{
    readonly HttpClient _client = new();
    private readonly RiotGamesApiOptions _options;
    private readonly ILogger<RiotGamesApiClient> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="RiotGamesApiClient"/> class.
    /// </summary>
    public RiotGamesApiClient(IOptions<RiotGamesApiOptions> options, ILogger<RiotGamesApiClient>? logger = null)
    {
        _options = options.Value;
        _logger = logger ?? NullLogger<RiotGamesApiClient>.Instance;
    }

    /// <inheritdoc/>
    public async Task<HttpResponseMessage> SendAsync(RiotRequestMessage request, RiotRequestOptions options, CancellationToken cancellationToken = default)
    {
        int retries = 0;
        do
        {
            // get method rl
            // get host rl
            retries++;
            using var httpRequestMessage = request.ToHttpRequestMessage();
            if (options.IncludeApiKey)
                httpRequestMessage.Headers.Add("X-Riot-Token", _options.ApiKey);
            var response = await _client.SendAsync(httpRequestMessage, cancellationToken).ConfigureAwait(false);
            if (response.IsSuccessStatusCode || response.StatusCode is HttpStatusCode.NotFound)
                return response;
            if (response.StatusCode is HttpStatusCode.TooManyRequests)
            {
                var delay = response.Headers.RetryAfter?.Delta ?? _options.Delay;
                var rt = response.Headers.TryGetValues("X-Rate-Limit-Type", out var rlt) && rlt.First() == "method";
                if (rt)
                {
                    // todo free method
                }
                _logger.LogInformation("delay:{0}, Host:{1}, rt:{2}", delay, request.Host, rlt);
                await Task.Delay(delay, cancellationToken).ConfigureAwait(false);
            }
            else if (response.StatusCode is >= (HttpStatusCode)400 and < (HttpStatusCode)500)
            {
                var msg = await ReadErrorMessageAsync(response.Content, cancellationToken).ConfigureAwait(false);
                throw new HttpRequestException(msg, null, response.StatusCode);
            }
            else if (response.StatusCode is >= (HttpStatusCode)500 and < (HttpStatusCode)600)
            {
                await Task.Delay(_options.Delay, cancellationToken).ConfigureAwait(false);
            }
            //free host rl
            //free method rl if not
        } while (retries < 5);
        throw new Exception();
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
