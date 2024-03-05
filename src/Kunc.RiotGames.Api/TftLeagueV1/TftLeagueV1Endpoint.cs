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

    /// <inheritdoc/>
    public async Task<LeagueListDto> GetChallengerLeagueAsync(string region, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/tft/league/v1/challenger",
            Path = $"/tft/league/v1/challenger",
        };
        return await _client.SendAndDeserializeAsync<LeagueListDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<LeagueEntryDto[]> LeagueEntriesForSummonerAsync(string region, string summonerId, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);
        ArgumentException.ThrowIfNullOrEmpty(summonerId);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/tft/league/v1/entries/by-summoner/{summonerId}",
            Path = $"/tft/league/v1/entries/by-summoner/{summonerId}",
        };
        return await _client.SendAndDeserializeAsync<LeagueEntryDto[]>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<LeagueEntryDto[]> GetAllLeaguesEntriesAsync(string region, Tier tier, Division division, AllLeaguesEntriesQuery? query = null, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/tft/league/v1/entries/{tier}/{division}",
            Path = $"/tft/league/v1/entries/{tier.ToUpperString()}/{division.ToFastString()}",
            Query = query,
        };
        return await _client.SendAndDeserializeAsync<LeagueEntryDto[]>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<LeagueListDto> GetGrandmasterLeagueAsync(string region, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/tft/league/v1/grandmaster",
            Path = $"/tft/league/v1/grandmaster",
        };
        return await _client.SendAndDeserializeAsync<LeagueListDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<LeagueListDto?> GetLeagueByIdAsync(string region, Guid leagueId, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/tft/league/v1/leagues/{leagueId}",
            Path = $"/tft/league/v1/leagues/{leagueId}",
        };
        return await _client.SendAndDeserializeAsync<LeagueListDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<LeagueListDto> GetMasterLeagueAsync(string region, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/tft/league/v1/master",
            Path = $"/tft/league/v1/master",
        };
        return await _client.SendAndDeserializeAsync<LeagueListDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TopRatedLadderEntryDto[]> GetTopRatedLadderAsync(string region, QueueType queue, CancellationToken cancellationToken)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/tft/league/v1/rated-ladders/{queue}/top",
            Path = $"/tft/league/v1/rated-ladders/{queue.ToApiString()}/top",
        };
        return await _client.SendAndDeserializeAsync<TopRatedLadderEntryDto[]>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }
}
