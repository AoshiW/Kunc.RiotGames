﻿using Kunc.RiotGames.Api.Http;

namespace Kunc.RiotGames.Api.LolMatchV5;

public class LolMatchV5Endpoint : ApiEndpoint, ILolMatchV5
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LolMatchV5Endpoint"/> class.
    /// </summary>
    public LolMatchV5Endpoint(IServiceProvider services) : base(services)
    {
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
        var data = await Client.SendAndDeserializeAsync<string[]>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <inheritdoc/>
    public async Task<MatchDto?> GetMatchAsync(string region, string matchId, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);
        ArgumentException.ThrowIfNullOrEmpty(matchId);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/match/v5/matches/{matchId}",
            Path = $"/lol/match/v5/matches/{matchId}",
        };
        return await Client.SendAndDeserializeAsync<MatchDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
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
        return await Client.SendAndDeserializeAsync<TimelineDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }
}
