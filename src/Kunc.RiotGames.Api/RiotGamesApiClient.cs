using Kunc.RiotGames.Http;
using System.Collections.Concurrent;
using System.Net;
using System.Text.Json;

namespace Kunc.RiotGames;
public class RiotGamesApiClient
{
    private readonly ConcurrentDictionary<string, RegionalRGApiClient> _clients = new();
    private readonly string _apiKey;
    private readonly RiotGamesApiClientOptions _options;

    public RiotGamesApiClient(string apiKey, RiotGamesApiClientOptions? options = null)
    {
        _apiKey = apiKey;
        _options = options ?? new();
    }

    public async Task<T?> SendAndDeserializeAsync<T>(string region, Func<HttpRequestMessage> requestFunc, string methodId, CancellationToken cancellationToken)
    {
        HttpResponseMessage? response = await SendAsync(region, requestFunc, methodId, cancellationToken).ConfigureAwait(false);
        if (_options.NullSucess.Contains(response.StatusCode))
        {
            return default;
        }
        Stream? stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        return await JsonSerializer.DeserializeAsync<T>(stream, (JsonSerializerOptions?)null, cancellationToken).ConfigureAwait(false);
    }

    public async Task<HttpResponseMessage> SendAsync(string region, Func<HttpRequestMessage> requestFunc, string methodId, CancellationToken cancellationToken)
    {
        RegionalRGApiClient client = _clients.GetOrAdd(region, reg => new(reg, _apiKey, _options));
        return await client.SendAsync(requestFunc, methodId, cancellationToken).ConfigureAwait(false);
    }

    class RegionalRGApiClient
    {
        private readonly HttpClient _client;
        private readonly RiotGamesApiClientOptions _options;
        private readonly SemaphoreSlim _app = new(1);
        private readonly ConcurrentDictionary<string, SemaphoreSlim> _method = new();

        public RegionalRGApiClient(string region, string apiKey, RiotGamesApiClientOptions options)
        {
            _options = options;
            _client = new HttpClient()
            {
                BaseAddress = new(string.Format(options.BaseAddress, region))
            };
            _client.DefaultRequestHeaders.Add("X-Riot-Token", apiKey);
        }

        public async Task<HttpResponseMessage> SendAsync(Func<HttpRequestMessage> requestFunc, string methodId, CancellationToken cancellationToken)
        {
            static bool IsInRange(HttpStatusCode code, int min, int max) => (int)code >= min && (int)code <= max;

            HttpResponseMessage? response = null;
            int i = 0;
            while (_options.Retries == -1 || i++ < _options.Retries)
            {
                var isAppRateLimitReleased = false;
                try
                {
                    await _method.GetOrAdd(methodId, x => new(1)).WaitAsync(cancellationToken);
                    await _app.WaitAsync(cancellationToken);
                    HttpRequestMessage request = requestFunc();
                    response = await _client.SendAsync(request, cancellationToken).ConfigureAwait(false);
                    if (response.IsSuccessStatusCode || _options.NullSucess.Contains(response.StatusCode))
                    {
                        return response;
                    }
                    else if (response.StatusCode == HttpStatusCode.TooManyRequests)
                    {
                        TimeSpan delay;
                        if (response.Headers.TryGetValues("X-Rate-Limit-Type", out var value) && Enum.TryParse<RateLimitType>(value.FirstOrDefault(), true, out var rateLimitType))
                        {
                            delay = response.Headers.RetryAfter?.Delta ?? _options.Delay;
                            if (rateLimitType == RateLimitType.Method)
                            {
                                _app.Release();
                                isAppRateLimitReleased = true;
                            }
                        }
                        else
                        {
                            delay = _options.Delay;
                        }
                        await Task.Delay(delay, cancellationToken);
                    }
                    else if (IsInRange(response.StatusCode, 500, 599))
                    {
                        await Task.Delay(_options.Delay, cancellationToken);
                    }
                    else if (IsInRange(response.StatusCode, 400, 499))
                    {
                        throw new HttpRequestException(await response.Content.ReadAsStringAsync(cancellationToken), null, response.StatusCode);
                    }
                    else
                        response.EnsureSuccessStatusCode();
                }
                finally
                {
                    if (!isAppRateLimitReleased)
                        _app.Release();
                    _method[methodId].Release();
                }
            }
            throw new AggregateException();
        }
    }
}
