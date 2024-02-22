using Kunc.RiotGames.Lol;

namespace Kunc.RiotGames.Api.TftLeagueV1;

public interface ITftLeagueV1
{
    /// <summary>
    /// Get the challenger league.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<LeagueListDto> GetChallengerLeagueAsync(string region, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get league entries for a given summoner ID.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="summonerId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<LeagueEntryDto[]> LeagueEntriesForSummonerAsync(string region, string summonerId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get all the league entries.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="tier"></param>
    /// <param name="division"></param>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<LeagueEntryDto[]> GetAllLeaguesEntriesAsync(string region, Tier tier, Division division, AllLeaguesEntriesQuery? query = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get the grandmaster league.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<LeagueListDto> GetGrandmasterLeagueAsync(string region, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get league with given ID, including inactive entries.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="leagueId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<LeagueListDto?> GetLeagueByIdAsync(string ?region, Guid leagueId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get the master league.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<LeagueListDto> GetMasterLeagueAsync(string region, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get the top rated ladder for given queue.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="queue"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TopRatedLadderEntryDto[]> GetTopRatedLadderAsync(string region, QueueType queue, CancellationToken cancellationToken);
}
