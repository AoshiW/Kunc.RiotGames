using System;
using Kunc.RiotGames.Api.Http;
using Kunc.RiotGames.Lol;

namespace Kunc.RiotGames.Api.TftLeagueV1;

public class TftLeagueV1Endpoint : EndpointBase, ITftLeagueV1
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TftLeagueV1Endpoint"/> class.
    /// </summary>
    public TftLeagueV1Endpoint(IServiceProvider service) : base(service)
    { }

    /// <inheritdoc/>
    public async Task<LeagueListDto> GetChallengerLeagueAsync(string region, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = MethodId.Tft_LeagueV1_Challenger,
            Path = $"/tft/league/v1/challenger",
        };
        var data = await SendAndDeserializeAsync<LeagueListDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <inheritdoc/>
    public async Task<LeagueEntryDto[]> LeagueEntriesForSummonerAsync(string region, string puuid, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);
        ArgumentException.ThrowIfNullOrEmpty(puuid);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = MethodId.Tft_LeagueV1_ByPuuid,
            Path = $"/tft/league/v1/by-puuid/{puuid}",
        };
        var data = await SendAndDeserializeAsync<LeagueEntryDto[]>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <inheritdoc/>
    public async Task<LeagueEntryDto[]> GetAllLeaguesEntriesAsync(string region, Tier tier, Division division, AllLeaguesEntriesQuery? query = null, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = MethodId.Tft_LeagueV1_Entries,
            Path = $"/tft/league/v1/entries/{tier.ToUpperString()}/{division.ToFastString()}",
            Query = query,
        };
        var data = await SendAndDeserializeAsync<LeagueEntryDto[]>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <inheritdoc/>
    public async Task<LeagueListDto> GetGrandmasterLeagueAsync(string region, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = MethodId.Tft_LeagueV1_Grandmaster,
            Path = $"/tft/league/v1/grandmaster",
        };
        var data = await SendAndDeserializeAsync<LeagueListDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <inheritdoc/>
    public async Task<LeagueListDto> GetMasterLeagueAsync(string region, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = MethodId.Tft_LeagueV1_Master,
            Path = $"/tft/league/v1/master",
        };
        var data = await SendAndDeserializeAsync<LeagueListDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <inheritdoc/>
    public async Task<TopRatedLadderEntryDto[]> GetTopRatedLadderAsync(string region, QueueType queue, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = MethodId.Tft_LeagueV1_RatedLadders,
            Path = $"/tft/league/v1/rated-ladders/{queue.ToApiString()}/top",
        };
        var data = await SendAndDeserializeAsync<TopRatedLadderEntryDto[]>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
        return data!;
    }
}
