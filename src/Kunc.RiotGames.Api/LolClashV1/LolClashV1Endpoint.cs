using Kunc.RiotGames.Api.Http;

namespace Kunc.RiotGames.Api.LolClashV1;

public class LolClashV1Endpoint : EndpointBase, ILolClashV1
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LolClashV1Endpoint"/> class.
    /// </summary>
    public LolClashV1Endpoint(IServiceProvider service) : base(service)
    { }

    /// <inheritdoc/>
    public async Task<PlayerDto[]> GetPlayersByPuuidAsync(string region, string puuid, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);
        ArgumentException.ThrowIfNullOrEmpty(puuid);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = MethodId.Lol_ClashV1_Player,
            Path = $"/lol/clash/v1/players/by-puuid/{puuid}",
        };
        var data = await SendAndDeserializeAsync<PlayerDto[]>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
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
            MethodId = MethodId.Lol_ClashV1_Team,
            Path = $"/lol/clash/v1/teams/{teamId}",
        };
        return await SendAndDeserializeAsync<TeamDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TournamentDto[]> GetAllActiveOrUpcomingTournamentsAsync(string region, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = MethodId.Lol_ClashV1_Tournaments,
            Path = "/lol/clash/v1/tournaments",
        };
        var data = await SendAndDeserializeAsync<TournamentDto[]>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
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
            MethodId = MethodId.Lol_ClashV1_Tournaments_ByTeam,
            Path = $"/lol/clash/v1/tournaments/by-team/{teamId}",
        };
        return await SendAndDeserializeAsync<TournamentDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
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
            MethodId = MethodId.Lol_ClashV1_Tournaments_ById,
            Path = $"/lol/clash/v1/tournaments/{tournamentId}",
        };
        return await SendAndDeserializeAsync<TournamentDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }
}
