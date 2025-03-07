using System.Collections.Concurrent;
using System.Diagnostics;
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
    internal readonly HybridCache HybridCache;
    internal readonly RiotGamesApiOptions Options;

    protected IRiotGamesApiClient Client { get; }
    protected ILogger<RiotGamesApi> Logger { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="EndpointBase"/> class.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    protected EndpointBase(IServiceProvider services)
    {
        ArgumentNullException.ThrowIfNull(services);
        Client = services.GetRequiredService<IRiotGamesApiClient>();
        HybridCache = services.GetRequiredService<HybridCache>();
        Options = services.GetRequiredService<IOptions<RiotGamesApiOptions>>().Value;
        Logger = services.GetService<ILogger<RiotGamesApi>>() ?? NullLogger<RiotGamesApi>.Instance;
    }

    internal async Task<T?> SendAndDeserializeAsync<T>(RiotRequestMessage request, RiotRequestOptions options, CancellationToken cancellationToken = default)
    {
        var cacheKey = request.GetCacheKey();
        var cacheOptions = Options.MethodCacheEntryOptions.GetValueOrDefault(request.MethodId) ?? Options.DefaultCacheEntryOptions;

        // unfortunately it is not possible to dynamically set whether the response should be cached
        // so the cache must be called twice (1. to test if the data is available; 2. to save the data)
        // but it loses stampede protection.
        // alternative solution: cache everything and if we don't want to cache something then delete it immediately
        // https://github.com/dotnet/aspnetcore/issues/56483
        var bytes = await HybridCache.GetAsync<byte[]>(cacheKey, cacheOptions, cancellationToken).ConfigureAwait(false);

        if (bytes is null)
        {
            var response = await Client.SendAsync(request, options, cancellationToken).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
                return default;

            bytes = await response.Content.ReadAsByteArrayAsync(cancellationToken).ConfigureAwait(false);

            await HybridCache.SetAsync(cacheKey, bytes,
                cacheOptions,
                null, // todo add tags ... maybe as a method argument (or in RiotRequestMessage?)
                cancellationToken).ConfigureAwait(false);
        }

        try
        {
            return JsonSerializer.Deserialize<T>(bytes, Options.JsonSerializerOptions);
        }
        catch (Exception ex)
        {
            Logger.LogDeserializeException(ex, request);
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
