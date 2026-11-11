using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net;
using System.Text.Json;
using Kunc.RiotGames.Api.Http;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Kunc.RiotGames.Api;

public abstract class EndpointBase
{
    private readonly HttpClient _client;
    private readonly HybridCache _hybridCache;
    private readonly RiotGamesApiOptions _options;
    private readonly ILogger<RiotGamesApi> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="EndpointBase"/> class.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    protected EndpointBase(IServiceProvider services)
    {
        ArgumentNullException.ThrowIfNull(services);
        _client = services.GetRequiredKeyedService<HttpClient>(ApiConstants.Project);
        _hybridCache = services.GetRequiredService<HybridCache>();
        _options = services.GetRequiredService<IOptions<RiotGamesApiOptions>>().Value;
        _logger = services.GetService<ILogger<RiotGamesApi>>() ?? NullLogger<RiotGamesApi>.Instance;
    }

    internal async Task<T?> SendAndDeserializeAsync<T>(RiotRequestMessage request, RiotRequestOptions options, CancellationToken cancellationToken = default)
    {
        var cacheKey = request.GetCacheKey();
        var cacheOptions = _options.MethodCacheEntryOptions.GetValueOrDefault(request.MethodId) ?? _options.DefaultCacheEntryOptions;

        var bytes = await _hybridCache.GetOrCreateAsync(cacheKey, (request, options, _client), static async (state, hcContext, ct) =>
        {
            using var httpRequest = state.request.ToHttpRequestMessage(state.options);
            var response = await state._client.SendAsync(httpRequest, ct).ConfigureAwait(false);

            if (response.StatusCode is HttpStatusCode.NotFound)
            {
                hcContext.Flags |= HybridCacheEntryFlags.DisableDistributedCacheWrite | HybridCacheEntryFlags.DisableLocalCacheWrite;
                return default;
            }
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsByteArrayAsync(ct).ConfigureAwait(false);
        },
        cacheOptions, null, cancellationToken).ConfigureAwait(false);

        try
        {
            return JsonSerializer.Deserialize<T>(bytes, _options.JsonSerializerOptions);
        }
        catch (Exception ex)
        {
            _logger.LogDeserializeException(ex, request);
            throw;
        }
    }
}

static file class Extensions
{
    private static readonly ConcurrentDictionary<HybridCacheEntryFlags, HybridCacheEntryOptions> Cache = new();

    public static ValueTask<T?> GetAsync<T>(this HybridCache hybridCache, string key, HybridCacheEntryOptions? options = null, CancellationToken cancellationToken = default)
    {
        options = Cache.GetOrAdd(options?.Flags ?? HybridCacheEntryFlags.None, key => new()
        {
            Flags = key | HybridCacheEntryFlags.DisableUnderlyingData
        });
        return hybridCache.GetOrCreateAsync<T?>(key, static _ => throw new UnreachableException(), options, null, cancellationToken);
    }
}
