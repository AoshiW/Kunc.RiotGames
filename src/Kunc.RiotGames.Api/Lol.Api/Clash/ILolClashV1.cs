namespace Kunc.RiotGames.Lol.Api.Clash;

public interface ILolClashV1
{
    Task<Tournament[]> GetAllActiveOrUpcomingTournamentsAsync(Platform routing, CancellationToken cancellationToken = default);
    Task<Player[]> GetPlayerAsync(Platform routing, string summonerId, CancellationToken cancellationToken = default);
    Task<Team?> GetTeamAsync(Platform routing, string teamId, CancellationToken cancellationToken = default);
    Task<Tournament?> GetTournamentByIdAsync(Platform routing, string tournamentId, CancellationToken cancellationToken = default);
    Task<Tournament?> GetTournamentByTeamIdAsync(Platform routing, string teamId, CancellationToken cancellationToken = default);
}
