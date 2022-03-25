using Kunc.RiotGames.Extensions;

namespace Kunc.RiotGames.Lol.Api.League;

/// <inheritdoc cref="ILolLeagueV4"/>
public class LolLeagueEndpoint : ILolLeagueV4
{
    private readonly RiotGamesApiClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="LolLeagueEndpoint"/> class with the specified <paramref name="client"/>.
    /// </summary>
    /// <param name="client"></param>
    /// <exception cref="ArgumentNullException">If <paramref name="client"/> is null.</exception>
    public LolLeagueEndpoint(RiotGamesApiClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<LeagueList> GetChallengerLeagueAsync(Platform routing, LolQueue queue, CancellationToken cancellationToken = default)
    {
        const string methodId = "/lol/league/v4/challengerleagues/by-queue/{queue}";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, $"/lol/league/v4/challengerleagues/by-queue/{queue.ToApiString()}");
        var leagueList = await _client.SendAndDeserializeAsync<LeagueList>(routing.ToLowerString(), requestFunc, methodId, cancellationToken).ConfigureAwait(false);
        return leagueList!;
    }

    /// <inheritdoc/>
    public async Task<LeagueEntry[]> GetSummonerLeagueEntriesAsync(Platform routing, string summonerId, CancellationToken cancellationToken = default)
    {
        const string methodId = "/lol/league/v4/entries/by-summoner/{encryptedSummonerId}";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, $"/lol/league/v4/entries/by-summoner/{summonerId}");
        var leagueEntries = await _client.SendAndDeserializeAsync<LeagueEntry[]>(routing.ToLowerString(), requestFunc, methodId, cancellationToken).ConfigureAwait(false);
        return leagueEntries!;
    }

    /// <inheritdoc/>
    public async Task<LeagueEntry[]> GetAllLeagueEntriesAsync(Platform routing, LolQueue queue, Tier tier, Division division, CancellationToken cancellationToken = default)
    {
        if (tier < Tier.Iron || tier > Tier.Diamond)
            throw new ArgumentOutOfRangeException(nameof(tier), tier, "Valid values: Iron to Diamond.");
        const string methodId = "/lol/league/v4/entries/{queue}/{tier}/{division}";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, $"/lol/league/v4/entries/{queue.ToApiString()}/{tier.ToUpperString()}/{division.ToStringPerf()}");
        var leagueEntries = await _client.SendAndDeserializeAsync<LeagueEntry[]>(routing.ToLowerString(), requestFunc, methodId, cancellationToken).ConfigureAwait(false);
        return leagueEntries!;
    }

    /// <inheritdoc/>
    public async Task<LeagueList> GetGrandmasterLeagueAsync(Platform routing, LolQueue queue, CancellationToken cancellationToken = default)
    {
        const string methodId = "/lol/league/v4/grandmasterleagues/by-queue/{queue}";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, $"/lol/league/v4/grandmasterleagues/by-queue/{queue.ToApiString()}");
        var leagueList = await _client.SendAndDeserializeAsync<LeagueList>(routing.ToLowerString(), requestFunc, methodId, cancellationToken).ConfigureAwait(false);
        return leagueList!;
    }

    /// <inheritdoc/>
    public async Task<LeagueList> GetLeagueAsync(Platform routing, string leagueId, CancellationToken cancellationToken = default)
    {
        const string methodId = "/lol/league/v4/leagues/{leagueId}";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, $"/lol/league/v4/leagues/{leagueId}");
        var leagueList = await _client.SendAndDeserializeAsync<LeagueList>(routing.ToLowerString(), requestFunc, methodId, cancellationToken).ConfigureAwait(false);
        return leagueList!;
    }

    /// <inheritdoc/>
    public async Task<LeagueList> GetMasterLeagueAsync(Platform routing, LolQueue queue, CancellationToken cancellationToken = default)
    {
        const string methodId = "/lol/league/v4/masterleagues/by-queue/{queue}";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, $"/lol/league/v4/masterleagues/by-queue/{queue.ToApiString()}");
        var leagueList = await _client.SendAndDeserializeAsync<LeagueList>(routing.ToLowerString(), requestFunc, methodId, cancellationToken).ConfigureAwait(false);
        return leagueList!;
    }
}
