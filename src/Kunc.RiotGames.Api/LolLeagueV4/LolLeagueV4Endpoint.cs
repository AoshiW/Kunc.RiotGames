using Kunc.RiotGames.Api.Http;
using Kunc.RiotGames.Lol;

namespace Kunc.RiotGames.Api.LolLeagueV4;

public class LolLeagueV4Endpoint : EndpointBase, ILolLeagueV4
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LolLeagueV4Endpoint"/> class.
    /// </summary>
    public LolLeagueV4Endpoint(IServiceProvider service) : base(service)
    { }

    /// <inheritdoc/>
    public async Task<LeagueListDto> GetChallengerLeagueAsync(string region, QueueType queue, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = MethodId.Lol_LeagueV4_Challenger,
            Path = $"/lol/league/v4/challengerleagues/by-queue/{queue.ToApiString()}",
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
            MethodId = MethodId.Lol_LeagueV4_Entries_ByPuuid,
            Path = $"/lol/league/v4/entries/by-puuid/{puuid}",
        };
        var data = await SendAndDeserializeAsync<LeagueEntryDto[]>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <inheritdoc/>
    public async Task<LeagueEntryDto[]> GetAllLeaguesEntriesAsync(string region, QueueType queue, Tier tier, Division division, AllLeaguesEntriesQuery? query = null, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = MethodId.Lol_LeagueV4_Entries,
            Path = $"/lol/league/v4/entries/{queue.ToApiString()}/{tier.ToUpperString()}/{division.ToFastString()}",
        };
        var data = await SendAndDeserializeAsync<LeagueEntryDto[]>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <inheritdoc/>
    public async Task<LeagueListDto> GetGrandmasterLeagueAsync(string region, QueueType queue, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = MethodId.Lol_LeagueV4_Grandmaster,
            Path = $"/lol/league/v4/grandmasterleagues/by-queue/{queue.ToApiString()}",
        };
        var data = await SendAndDeserializeAsync<LeagueListDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <inheritdoc/>
    public async Task<LeagueListDto?> GetLeagueByIdAsync(string region, Guid leagueId, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = MethodId.Lol_LeagueV4_League,
            Path = $"/lol/league/v4/leagues/{leagueId}",
        };
        return await SendAndDeserializeAsync<LeagueListDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<LeagueListDto> GetMasterLeagueAsync(string region, QueueType queue, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = MethodId.Lol_LeagueV4_Master,
            Path = $"/lol/league/v4/masterleagues/by-queue/{queue.ToApiString()}",
        };
        var data = await SendAndDeserializeAsync<LeagueListDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
        return data!;
    }
}
