namespace Kunc.RiotGames.Api.LorMatchV1;

public interface ILorMatchV1
{
    /// <summary>
    /// Get a list of match ids by PUUID
    /// </summary>
    /// <param name="region"></param>
    /// <param name="puuid"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<string[]> GetMatchIdsAsync(string region, string puuid, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a match by id.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="matchId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<MatchDto?> GetMatchAsync(string region, string matchId, CancellationToken cancellationToken = default);
}
