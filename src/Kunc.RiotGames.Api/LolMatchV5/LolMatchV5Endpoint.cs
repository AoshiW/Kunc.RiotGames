using System.Text.Json;
using Kunc.RiotGames.Abstractions;
using Kunc.RiotGames.Api.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;

namespace Kunc.RiotGames.Api.LolMatchV5;

public class LolMatchV5Endpoint : ApiEndpoint, ILolMatchV5
{
    private readonly IDistributedCache _cache;

    /// <summary>
    /// Initializes a new instance of the <see cref="LolMatchV5Endpoint"/> class.
    /// </summary>
    public LolMatchV5Endpoint(IServiceProvider services) : base(services)
    {
        _cache = services.GetService<IDistributedCache>() ?? NullDistributedCache.Instance;
    }

    /// <inheritdoc/>
    public async Task<string[]> GetMatchIdsAsync(string region, string puuid, MatchIdsQuery? query = null, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);
        ArgumentException.ThrowIfNullOrEmpty(puuid);
        
        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/match/v5/matches/by-puuid/{puuid}/ids",
            Path = $"/lol/match/v5/matches/by-puuid/{puuid}/ids",
            Query = query,
        };
        var data = await _client.SendAndDeserializeAsync<string[]>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <inheritdoc/>
    public async Task<MatchDto?> GetMatchAsync(string region, string matchId, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);
        ArgumentException.ThrowIfNullOrEmpty(matchId);

        var bytes = await _cache.GetAsync("", cancellationToken).ConfigureAwait(false);
        if (bytes is null)
        {
            var request = new RiotRequestMessage()
            {
                HttpMethod = HttpMethod.Get,
                Host = region,
                MethodId = "/lol/match/v5/matches/{matchId}",
                Path = $"/lol/match/v5/matches/{matchId}",
            };
            using var response = await _client.SendAsync(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                bytes = await response.Content.ReadAsByteArrayAsync(cancellationToken).ConfigureAwait(false);
                await _cache.SetAsync("", bytes, cancellationToken).ConfigureAwait(false);
            }
        }
        return bytes is null
            ? null
            : JsonSerializer.Deserialize<MatchDto?>(bytes);
    }

    /// <inheritdoc/>
    public async Task<TimelineDto?> GetMatchTimelineAsync(string region, string matchId, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);
        ArgumentException.ThrowIfNullOrEmpty(matchId);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/match/v5/matches/{matchId}/timeline",
            Path = $"/lol/match/v5/matches/{matchId}/timeline",
        };
        return await _client.SendAndDeserializeAsync<TimelineDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }
}
