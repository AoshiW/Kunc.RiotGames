using Kunc.RiotGames.Extensions;
using Kunc.RiotGames.Lol.Api;

namespace Kunc.RiotGames.Tft.Api.League;

/// <inheritdoc cref="ITftLeagueV1"/>
public class TftLeagueEndpoint : ITftLeagueV1
{
    private readonly RiotGamesApiClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="TftLeagueEndpoint"/> class with the specified <paramref name="client"/>.
    /// </summary>
    /// <param name="client"></param>
    /// <exception cref="ArgumentNullException">If <paramref name="client"/> is null.</exception>
    public TftLeagueEndpoint(RiotGamesApiClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<LeagueList> GetChallengerLeagueAsync(Platform routing, CancellationToken cancellationToken = default)
    {
        const string methodId = "/tft/league/v1/challenger";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, "/tft/league/v1/challenger");
        var leagueList = await _client.SendAndDeserializeAsync<LeagueList>(routing.ToLowerString(), requestFunc, methodId, cancellationToken).ConfigureAwait(false);
        return leagueList!;
    }

    /// <inheritdoc/>
    public async Task<LeagueEntry[]> GetSummonerLeagueEntriesAsync(Platform routing, string summonerId, CancellationToken cancellationToken = default)
    {
        const string methodId = "/tft/league/v1/entries/by-summoner/{summonerId}";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, $"/tft/league/v1/entries/by-summoner/{summonerId}");
        var leagueEntries = await _client.SendAndDeserializeAsync<LeagueEntry[]>(routing.ToLowerString(), requestFunc, methodId, cancellationToken).ConfigureAwait(false);
        return leagueEntries!;
    }

    /// <inheritdoc/>
    public async Task<LeagueEntry[]> GetAllLeagueEntriesAsync(Platform routing, Tier tier, Division division, CancellationToken cancellationToken = default)
    {
        const string methodId = "/tft/league/v1/entries/{tier}/{division}";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, $"/tft/league/v1/entries/{tier}/{division}");
        var leagueEntries = await _client.SendAndDeserializeAsync<LeagueEntry[]>(routing.ToLowerString(), requestFunc, methodId, cancellationToken).ConfigureAwait(false);
        return leagueEntries!;
    }

    /// <inheritdoc/>
    public async Task<LeagueList> GetGrandmasterLeagueAsync(Platform routing, CancellationToken cancellationToken = default)
    {
        const string methodId = "/tft/league/v1/grandmaster";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, "/tft/league/v1/grandmaster");
        var leagueList = await _client.SendAndDeserializeAsync<LeagueList>(routing.ToLowerString(), requestFunc, methodId, cancellationToken).ConfigureAwait(false);
        return leagueList!;
    }

    /// <inheritdoc/>
    public async Task<LeagueList> GetLeagueAsync(Platform routing, string leagueId, CancellationToken cancellationToken = default)
    {
        const string methodId = "/tft/league/v1/leagues/{leagueId}";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, $"/tft/league/v1/leagues/{leagueId}");
        var leagueList = await _client.SendAndDeserializeAsync<LeagueList>(routing.ToLowerString(), requestFunc, methodId, cancellationToken).ConfigureAwait(false);
        return leagueList!;
    }

    /// <inheritdoc/>
    public async Task<LeagueList> GetMasterLeagueAsync(Platform routing, CancellationToken cancellationToken = default)
    {
        const string methodId = "/tft/league/v1/master";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, "/tft/league/v1/master");
        var leagueList = await _client.SendAndDeserializeAsync<LeagueList>(routing.ToLowerString(), requestFunc, methodId, cancellationToken).ConfigureAwait(false);
        return leagueList!;
    }

    /// <inheritdoc/>
    public async Task<TopRatedLadderEntry[]> GetTopRatedLadderAsync(Platform routing, TftQueue queue, CancellationToken cancellationToken = default)
    {
        const string methodId = "/tft/league/v1/rated-ladders/{queue}/top";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, $"/tft/league/v1/rated-ladders/{queue.ToApiString()}/top");
        var topRatedLadderEntry = await _client.SendAndDeserializeAsync<TopRatedLadderEntry[]>(routing.ToLowerString(), requestFunc, methodId, cancellationToken).ConfigureAwait(false);
        return topRatedLadderEntry!;
    }
}
