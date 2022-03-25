using Kunc.RiotGames.Extensions;

namespace Kunc.RiotGames.Lol.Api.Clash;

/// <inheritdoc cref="ILolClashV1"/>
public class LolClashEndpoint : ILolClashV1
{
    private readonly RiotGamesApiClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="LolClashEndpoint"/> class with the specified <paramref name="client"/>.
    /// </summary>
    /// <param name="client"></param>
    /// <exception cref="ArgumentNullException">If <paramref name="client"/> is null.</exception>
    public LolClashEndpoint(RiotGamesApiClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<Player[]> GetPlayerAsync(Platform routing, string summonerId, CancellationToken cancellationToken = default)
    {
        const string methodId = "/lol/clash/v1/players/by-summoner/{summonerId}";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, $"/lol/clash/v1/players/by-summoner/{summonerId}");
        var rotation = await _client.SendAndDeserializeAsync<Player[]>(routing.ToLowerString(), requestFunc, methodId, cancellationToken).ConfigureAwait(false);
        return rotation!;
    }

    /// <inheritdoc/>
    public async Task<Team?> GetTeamAsync(Platform routing, string teamId, CancellationToken cancellationToken = default)
    {
        const string methodId = "/lol/clash/v1/teams/{teamId}";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, $"/lol/clash/v1/teams/{teamId}");
        var rotation = await _client.SendAndDeserializeAsync<Team>(routing.ToLowerString(), requestFunc, methodId, cancellationToken).ConfigureAwait(false);
        return rotation;
    }

    /// <inheritdoc/>
    public async Task<Tournament[]> GetAllActiveOrUpcomingTournamentsAsync(Platform routing, CancellationToken cancellationToken = default)
    {
        const string methodId = "/lol/clash/v1/tournaments";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, "/lol/clash/v1/tournaments");
        var rotation = await _client.SendAndDeserializeAsync<Tournament[]>(routing.ToLowerString(), requestFunc, methodId, cancellationToken).ConfigureAwait(false);
        return rotation!;
    }

    /// <inheritdoc/>
    public async Task<Tournament?> GetTournamentByTeamIdAsync(Platform routing, string teamId, CancellationToken cancellationToken = default)
    {
        const string methodId = "/lol/clash/v1/tournaments/by-team/{teamId}";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, $"/lol/clash/v1/tournaments/by-team/{teamId}");
        var rotation = await _client.SendAndDeserializeAsync<Tournament>(routing.ToLowerString(), requestFunc, methodId, cancellationToken).ConfigureAwait(false);
        return rotation;
    }

    /// <inheritdoc/>
    public async Task<Tournament?> GetTournamentByIdAsync(Platform routing, string tournamentId, CancellationToken cancellationToken = default)
    {
        const string methodId = "/lol/clash/v1/tournaments/{tournamentId}";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, $"/lol/clash/v1/tournaments/{tournamentId}");
        var rotation = await _client.SendAndDeserializeAsync<Tournament>(routing.ToLowerString(), requestFunc, methodId, cancellationToken).ConfigureAwait(false);
        return rotation;
    }
}