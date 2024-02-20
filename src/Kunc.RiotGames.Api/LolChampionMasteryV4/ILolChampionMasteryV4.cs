namespace Kunc.RiotGames.Api.LolChampionMasteryV4;

public interface ILolChampionMasteryV4
{
    /// <summary>
    /// Get all champion mastery entries sorted by number of champion points descendin.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="puuid"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ChampionMasteryDto[]> GetAllChampionMasteryEntriesAsync(string region, string puuid, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a champion mastery by puuid and champion ID.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="puuid"></param>
    /// <param name="championId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ChampionMasteryDto?> GetChampionMasteryByPuuidAsync(string region, string puuid, long championId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get specified number of top champion mastery entries sorted by number of champion points descending.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="puuid"></param>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ChampionMasteryDto[]> GetTopChampionMasteryEntriesAsync(string region, string puuid, TopChampionMasteryEntriesQuery? query = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a player's total champion mastery score, which is the sum of individual champion mastery levels.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="puuid"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<int> GetPlayersTotalChampionMasteryScoreAsync(string region, string puuid, CancellationToken cancellationToken = default);
}
