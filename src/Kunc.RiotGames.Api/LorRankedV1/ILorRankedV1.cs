namespace Kunc.RiotGames.Api.LorRankedV1;

public interface ILorRankedV1
{
    /// <summary>
    /// leaderboardsGet the players in Master tier.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<LeaderboardDto> GetLeaderboardAsync(string region, CancellationToken cancellationToken = default);
}
