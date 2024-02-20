
namespace Kunc.RiotGames.Api.LolMatchV5;

public interface ILolMatchV5
{
    /// <summary>
    /// Get a list of match ids by puuid.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="puuid"></param>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<string[]> GetListOfMatchIdsAsync(string region, string puuid, ListOfMatchIdsQuery? query = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a match by match id.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="matchId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<MatchDto?> GetMatchAsync(string region, string matchId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a match timeline by match id.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="matchId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<MatchTimelineDto?> GetMatchTimelineAsync(string region, string matchId, CancellationToken cancellationToken = default);
}
