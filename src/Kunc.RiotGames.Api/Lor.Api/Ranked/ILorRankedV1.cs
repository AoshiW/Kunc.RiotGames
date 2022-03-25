namespace Kunc.RiotGames.Lor.Api.Ranked;

public interface ILorRankedV1
{
    /// <summary>
    /// Get the players in Master tier.
    /// </summary>
    /// <remarks>
    /// The leaderboard is updated once an hour.
    /// </remarks>
    /// <param name="routing"></param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns></returns>
    /// <exception cref="TaskCanceledException">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</exception>
    /// <exception cref="HttpRequestException"></exception>
    Task<Leaderboard> GetLeaderboardAsync(Region routing, CancellationToken cancellationToken = default);
}
