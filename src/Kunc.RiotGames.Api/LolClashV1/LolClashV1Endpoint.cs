using Kunc.RiotGames.Api.Http;

namespace Kunc.RiotGames.Api.LolClashV1;

public class LolClashV1Endpoint : ILolClashV1
{
    private readonly IRiotGamesApiClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="LolClashV1Endpoint"/> class.
    /// </summary>
    public LolClashV1Endpoint(IRiotGamesApiClient client)
    {
        ArgumentNullException.ThrowIfNull(client);
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<PlayerDto[]> GetPlayersBySummonerIdAsync(string region, string summonerId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(region);
        ArgumentNullException.ThrowIfNull(summonerId);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/clash/v1/players/by-summoner/{summonerId}",
            Path = $"/lol/clash/v1/players/by-summoner/{summonerId}",
        };
        return await _client.SendAndDeserializeAsync<PlayerDto[]>(request, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TeamDto?> GetTeamByIdAsync(string region, string teamId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(region);
        ArgumentNullException.ThrowIfNull(teamId);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/clash/v1/teams/{teamId}",
            Path = $"/lol/clash/v1/teams/{teamId}",
        };
        return await _client.SendAndDeserializeAsync<TeamDto>(request, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TournamentDto[]> GetAllActiveOrUpcomingTournamentsAsync(string region, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/clash/v1/tournaments",
            Path = "/lol/clash/v1/tournaments",
        };
        return await _client.SendAndDeserializeAsync<TournamentDto[]>(request, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TournamentDto?> GetTournamentByTeamIdAsync(string region, string teamId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(region);
        ArgumentNullException.ThrowIfNull(teamId);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/clash/v1/tournaments/by-team/{teamId}",
            Path = $"/lol/clash/v1/tournaments/by-team/{teamId}",
        };
        return await _client.SendAndDeserializeAsync<TournamentDto>(request, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TournamentDto?> GetTournamentByIdAsync(string region, string tournamentId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(region);
        ArgumentNullException.ThrowIfNull(tournamentId);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/clash/v1/tournaments/{tournamentId}",
            Path = $"/lol/clash/v1/tournaments/{tournamentId}",
        };
        return await _client.SendAndDeserializeAsync<TournamentDto>(request, cancellationToken).ConfigureAwait(false);
    }
}
