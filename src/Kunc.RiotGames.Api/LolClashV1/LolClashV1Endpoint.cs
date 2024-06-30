using Kunc.RiotGames.Api.Http;

namespace Kunc.RiotGames.Api.LolClashV1;

public class LolClashV1Endpoint : ApiEndpoint, ILolClashV1
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LolClashV1Endpoint"/> class.
    /// </summary>
    public LolClashV1Endpoint(IServiceProvider services) : base(services)
    {
    }

    /// <inheritdoc/>
    public async Task<PlayerDto[]> GetPlayersBySummonerIdAsync(string region, string summonerId, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);
        ArgumentException.ThrowIfNullOrEmpty(summonerId);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/clash/v1/players/by-summoner/{summonerId}",
            Path = $"/lol/clash/v1/players/by-summoner/{summonerId}",
        };
        var data = await Client.SendAndDeserializeAsync<PlayerDto[]>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <inheritdoc/>
    public async Task<TeamDto?> GetTeamByIdAsync(string region, string teamId, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);
        ArgumentException.ThrowIfNullOrEmpty(teamId);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/clash/v1/teams/{teamId}",
            Path = $"/lol/clash/v1/teams/{teamId}",
        };
        return await Client.SendAndDeserializeAsync<TeamDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TournamentDto[]> GetAllActiveOrUpcomingTournamentsAsync(string region, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/clash/v1/tournaments",
            Path = "/lol/clash/v1/tournaments",
        };
        var data = await Client.SendAndDeserializeAsync<TournamentDto[]>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <inheritdoc/>
    public async Task<TournamentDto?> GetTournamentByTeamIdAsync(string region, string teamId, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);
        ArgumentException.ThrowIfNullOrEmpty(teamId);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/clash/v1/tournaments/by-team/{teamId}",
            Path = $"/lol/clash/v1/tournaments/by-team/{teamId}",
        };
        return await Client.SendAndDeserializeAsync<TournamentDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TournamentDto?> GetTournamentByIdAsync(string region, string tournamentId, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);
        ArgumentException.ThrowIfNullOrEmpty(tournamentId);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/clash/v1/tournaments/{tournamentId}",
            Path = $"/lol/clash/v1/tournaments/{tournamentId}",
        };
        return await Client.SendAndDeserializeAsync<TournamentDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }
}
