using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Kunc.RiotGames.Api.Http;

public class RiotGamesApiClient : IRiotGamesApiClient, IDisposable
{
    private readonly HttpClient _client;
    private readonly RiotGamesApiOptions _options;
    private readonly ILogger<RiotGamesApiClient> _logger;
    private bool _disposedValue;

    /// <summary>
    /// Initializes a new instance of the <see cref="RiotGamesApiClient"/> class.
    /// </summary>
    public RiotGamesApiClient(IOptions<RiotGamesApiOptions> options, [FromKeyedServices(ApiConstants.Project)] IEnumerable<DelegatingHandler> handlers, ILogger<RiotGamesApiClient>? logger = null)
    {
        _options = options.Value;

        _client= new(CreateChain(handlers));
        _logger = logger ?? NullLogger<RiotGamesApiClient>.Instance;
    }

    static HttpMessageHandler CreateChain(IEnumerable<DelegatingHandler> handlers)
    {
        HttpMessageHandler handler = new HttpClientHandler();
        foreach (var item in handlers)
        {
            item.InnerHandler = handler;
            handler = item;
        }
        return handler;
    }

    /// <inheritdoc/>
    public async Task<HttpResponseMessage> SendAsync(RiotRequestMessage request, RiotRequestOptions options, CancellationToken cancellationToken = default)
    {
        ObjectDisposedException.ThrowIf(_disposedValue, this);
        int retries = 0;
        List<Exception>? exceptions = null;
        do
        {
            retries++;
            using var httpRequestMessage = request.ToHttpRequestMessage();
            if (options.IncludeApiKey)
                httpRequestMessage.Headers.Add(ApiConstants.Headers.RiotToken, _options.ApiKey);

            var response = await _client.SendAsync(httpRequestMessage, cancellationToken).ConfigureAwait(false);
            
            if (response.IsSuccessStatusCode || response.StatusCode is HttpStatusCode.NotFound)
                return response;

            var msg = await ReadErrorMessageAsync(response.Content, cancellationToken).ConfigureAwait(false);
            (exceptions ??= new()).Add(new HttpRequestException(msg, null, response.StatusCode));

            if (response.StatusCode is >= (HttpStatusCode)400 and < (HttpStatusCode)500)
            {
                throw exceptions[^1];
            }
            else if (response.StatusCode is >= (HttpStatusCode)500 and < (HttpStatusCode)600)
            {
                await Task.Delay(_options.Delay, cancellationToken).ConfigureAwait(false);
            }
        } while (retries < 5);
        throw new AggregateException($"Request failed after {retries} attempts.", exceptions);
    }

    async ValueTask<string> ReadErrorMessageAsync(HttpContent content, CancellationToken cancellationToken)
    {
        try
        {
            var jsonElement = await content.ReadFromJsonAsync<JsonElement>(_options.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
            return jsonElement.TryGetProperty("status"u8, out var status) &&
                        status.TryGetProperty("message"u8, out var message) &&
                        message.ValueKind == JsonValueKind.String
                        ? message.ToString()
                        : jsonElement.ToString();
        }
        catch
        {
            // sometimes Riot does not return JSON but only this:
            // error code: 504
            return await content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Releases the unmanaged resources and optionally disposes of the managed resources.
    /// </summary>
    /// <param name="disposing">
    /// <see langword="true"/> to release both managed and unmanaged resources;
    /// <see langword="false"/> to releases only unmanaged resources.
    /// </param>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                _client.Dispose();
            }
            _disposedValue = true;
        }
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
