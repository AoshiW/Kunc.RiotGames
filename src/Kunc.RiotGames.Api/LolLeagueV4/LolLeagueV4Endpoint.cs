using Kunc.RiotGames.Api.Http;
using Kunc.RiotGames.Lol;

namespace Kunc.RiotGames.Api.LolLeagueV4;

public class LolLeagueV4Endpoint : ILolLeagueV4
{
    private readonly IRiotGamesApiClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="LolLeagueV4Endpoint"/> class.
    /// </summary>
    public LolLeagueV4Endpoint(IRiotGamesApiClient client)
    {
        ArgumentNullException.ThrowIfNull(client);
        _client = client;
    }

    public async Task<LeagueListDto> GetChallengerLeagueAsync(string region, QueueType queue, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/league/v4/challengerleagues/by-queue/{queue}",
            Path = $"/lol/league/v4/challengerleagues/by-queue/{queue}",
        };
        return await _client.SendAndDeserializeAsync<LeagueListDto>(request, cancellationToken).ConfigureAwait(false);
    }

    public async Task<LeagueEntryDto[]> GetAllLeaguesEntriesAsync(string region, QueueType queue, Tier tier, Division division, AllLeaguesEntriesQuery? query = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/league/v4/entries/{queue}/{tier}/{division}",
            Path = $"/lol/league/v4/entries/{queue.ToApiString()}/{tier.ToUpperString()}/{division.ToFastString()}",
        };
        return await _client.SendAndDeserializeAsync<LeagueEntryDto[]>(request, cancellationToken).ConfigureAwait(false);

    }

    public async Task<LeagueListDto> GetGrandmasterLeagueAsync(string region, QueueType queue, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/league/v4/grandmasterleagues/by-queue/{queue}",
            Path = $"/lol/league/v4/grandmasterleagues/by-queue/{queue.ToApiString()}",
        };
        return await _client.SendAndDeserializeAsync<LeagueListDto>(request, cancellationToken).ConfigureAwait(false);
    }

    public async Task<LeagueListDto?> GetLeagueByIdAsync(string? region, Guid leagueId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/league/v4/leagues/{leagueId}",
            Path = $"/lol/league/v4/leagues/{leagueId}",
        };
        return await _client.SendAndDeserializeAsync<LeagueListDto>(request, cancellationToken).ConfigureAwait(false);
    }

    public async Task<LeagueListDto> GetMasterLeagueAsync(string region, QueueType queue, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/league/v4/masterleagues/by-queue/{queue}",
            Path = $"/lol/league/v4/masterleagues/by-queue/{queue.ToApiString()}",
        };
        return await _client.SendAndDeserializeAsync<LeagueListDto>(request, cancellationToken).ConfigureAwait(false);
    }
}
