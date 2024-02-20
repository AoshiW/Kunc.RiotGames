using Kunc.RiotGames.Api.Http;
using Kunc.RiotGames.Lol;

namespace Kunc.RiotGames.Api.TftLeagueV1;

public class TftLeagueV1Endpoint : ITftLeagueV1
{
    private readonly IRiotGamesApiClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="TftLeagueV1Endpoint"/> class.
    /// </summary>
    public TftLeagueV1Endpoint(IRiotGamesApiClient client)
    {
        ArgumentNullException.ThrowIfNull(client);
        _client = client;
    }

    public async Task<LeagueListDto> GetChallengerLeagueAsync(string region, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/tft/league/v1/challenger",
            Path = $"/tft/league/v1/challenger",
        };
        return await _client.SendAndDeserializeAsync<LeagueListDto>(request, cancellationToken).ConfigureAwait(false);
    }

    public async Task<LeagueEntryDto[]> GetAllLeaguesEntriesAsync(string region, Tier tier, Division division, AllLeaguesEntriesQuery? query = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/tft/league/v1/entries/{tier}/{division}",
            Path = $"/tft/league/v1/entries/{tier.ToUpperString()}/{division.ToFastString()}",
            Query = query,
        };
        return await _client.SendAndDeserializeAsync<LeagueEntryDto[]>(request, cancellationToken).ConfigureAwait(false);
    }

    public async Task<LeagueListDto> GetGrandmasterLeagueAsync(string region, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/tft/league/v1/grandmaster",
            Path = $"/tft/league/v1/grandmaster",
        };
        return await _client.SendAndDeserializeAsync<LeagueListDto>(request, cancellationToken).ConfigureAwait(false);
    }

    public async Task<LeagueListDto?> GetLeagueByIdAsync(string region, Guid leagueId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/tft/league/v1/leagues/{leagueId}",
            Path = $"/tft/league/v1/leagues/{leagueId}",
        };
        return await _client.SendAndDeserializeAsync<LeagueListDto>(request, cancellationToken).ConfigureAwait(false);
    }

    public async Task<LeagueListDto> GetMasterLeagueAsync(string region, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/tft/league/v1/master",
            Path = $"/tft/league/v1/master",
        };
        return await _client.SendAndDeserializeAsync<LeagueListDto>(request, cancellationToken).ConfigureAwait(false);
    }

    public async Task<TopRatedLadderEntryDto[]> GetTopRatedLadderAsync(string region, QueueType queue, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/tft/league/v1/rated-ladders/{queue}/top",
            Path = $"/tft/league/v1/rated-ladders/{queue.ToApiString()}/top",
        };
        return await _client.SendAndDeserializeAsync<TopRatedLadderEntryDto[]>(request, cancellationToken).ConfigureAwait(false);
    }
}
