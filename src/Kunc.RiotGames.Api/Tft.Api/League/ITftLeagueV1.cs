using Kunc.RiotGames.Lol.Api;

namespace Kunc.RiotGames.Tft.Api.League;

public interface ITftLeagueV1
{
    Task<LeagueEntry[]> GetAllLeagueEntriesAsync(Platform routing, Tier tier, Division division, CancellationToken cancellationToken = default);
    Task<LeagueList> GetChallengerLeagueAsync(Platform routing, CancellationToken cancellationToken = default);
    Task<LeagueList> GetGrandmasterLeagueAsync(Platform routing, CancellationToken cancellationToken = default);
    Task<LeagueList> GetLeagueAsync(Platform routing, string leagueId, CancellationToken cancellationToken = default);
    Task<LeagueList> GetMasterLeagueAsync(Platform routing, CancellationToken cancellationToken = default);
    Task<LeagueEntry[]> GetSummonerLeagueEntriesAsync(Platform routing, string summonerId, CancellationToken cancellationToken = default);
    Task<TopRatedLadderEntry[]> GetTopRatedLadderAsync(Platform routing, TftQueue queue, CancellationToken cancellationToken = default);
}
