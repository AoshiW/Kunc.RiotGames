namespace Kunc.RiotGames.Tft.Api.Match;

public interface ITftMatchV1
{
    /// <summary>
    /// Get a list of match ids by PUUID.
    /// </summary>
    /// <param name="routing"></param>
    /// <param name="puuid"></param>
    /// <param name="count"></param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns></returns>
    /// <exception cref="TaskCanceledException">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</exception>
    /// <exception cref="HttpRequestException"></exception>
    /// <exception cref="ArgumentNullException">The <paramref name="puuid"/> is null.</exception>
    Task<string[]> GetListOfMatcIdsAsync(Region routing, string puuid, int? count = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a match by match id.
    /// </summary>
    /// <param name="routing"></param>
    /// <param name="matchId"></param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns></returns>
    /// <exception cref="TaskCanceledException">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</exception>
    /// <exception cref="HttpRequestException"></exception>
    /// <exception cref="ArgumentNullException">The <paramref name="matchId"/> is null.</exception>
    Task<Match?> GetMatchAsync(Region routing, string matchId, CancellationToken cancellationToken = default);
}
