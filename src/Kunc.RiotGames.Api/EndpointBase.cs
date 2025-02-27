using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
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
        var cacheKey = $"{request.Host}{request.Path}";

        // unfortunately it is not possible to dynamically set whether the response should be cached
        // so the cache must be called twice (1. to test if the data is available; 2. to save the data)
        // but it loses stampede protection.
        // alternative solution: cache everything and if we don't want to cache something then delete it immediately
        // https://github.com/dotnet/aspnetcore/issues/56483
        var bytes = await HybridCache.GetAsync<byte[]>(cacheKey, cancellationToken).ConfigureAwait(false);

        if (bytes is null)
        {
            var response = await Client.SendAsync(request, options, cancellationToken).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
                return default;

            bytes = await response.Content.ReadAsByteArrayAsync(cancellationToken).ConfigureAwait(false);

            await HybridCache.GetOrCreateAsync(cacheKey, bytes, static (bytes, _) => ValueTask.FromResult(bytes),
                Options.MethodCacheEntryOptions.GetValueOrDefault(request.MethodId) ?? Options.DefaultCacheEntryOptions,
                null, // todo add tags (maybe as a method argument (or in RiotRequestOptions))
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
    static readonly HybridCacheEntryOptions CacheOnly = new() { Flags = HybridCacheEntryFlags.DisableUnderlyingData };

    public static ValueTask<T?> GetAsync<T>(this HybridCache hybridCache, string key, CancellationToken cancellationToken = default)
    {
        return hybridCache.GetOrCreateAsync<T?>(key, static _ => throw new UnreachableException(), CacheOnly, null, cancellationToken);
    }
}
