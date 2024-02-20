namespace Kunc.RiotGames.Api.TftMatchV1;

public interface ITftMatchV1
{
    /// <summary>
    /// Get a list of match ids by PUUID
    /// </summary>
    /// <param name="region"></param>
    /// <param name="puuid"></param>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<string[]> GetListOfMatchIdsAsync(string region, string puuid, ListOfMatchIdsQuery? query = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a match by id.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="matchId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<MatchDto?> GetMatchAsync(string region, string matchId, CancellationToken cancellationToken = default);
}
