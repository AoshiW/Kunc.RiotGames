namespace Kunc.RiotGames.Api.LolClashV1;

public interface ILolClashV1
{
    /// <summary>
    /// Get players by PUUID.
    /// </summary>
    /// <remarks>
    /// This endpoint returns a list of active Clash players for a given PUUID.
    /// If a summoner registers for multiple tournaments at the same time (e.g., Saturday and Sunday) then both registrations would appear in this list.
    /// </remarks>
    /// <param name="region"></param>
    /// <param name="puuid"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<PlayerDto[]> GetPlayersByPuuidAsync(string region, string puuid, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get team by ID.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="teamId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TeamDto?> GetTeamByIdAsync(string region, string teamId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get all active or upcoming tournaments.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TournamentDto[]> GetAllActiveOrUpcomingTournamentsAsync(string region, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get tournament by team ID.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="teamId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TournamentDto?> GetTournamentByTeamIdAsync(string region, string teamId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get tournament by ID.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="tournamentId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TournamentDto?> GetTournamentByIdAsync(string region, string tournamentId, CancellationToken cancellationToken = default);
}
