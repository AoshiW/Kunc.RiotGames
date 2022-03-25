namespace Kunc.RiotGames.Lol.Api.League;

public interface ILolLeagueV4
{
    Task<LeagueEntry[]> GetAllLeagueEntriesAsync(Platform routing, LolQueue queue, Tier tier, Division division, CancellationToken cancellationToken = default);
    Task<LeagueList> GetChallengerLeagueAsync(Platform routing, LolQueue queue, CancellationToken cancellationToken = default);
    Task<LeagueList> GetGrandmasterLeagueAsync(Platform routing, LolQueue queue, CancellationToken cancellationToken = default);
    Task<LeagueList> GetLeagueAsync(Platform routing, string leagueId, CancellationToken cancellationToken = default);
    Task<LeagueList> GetMasterLeagueAsync(Platform routing, LolQueue queue, CancellationToken cancellationToken = default);
    Task<LeagueEntry[]> GetSummonerLeagueEntriesAsync(Platform routing, string summonerId, CancellationToken cancellationToken = default);
}
