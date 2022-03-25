namespace Kunc.RiotGames.Lor.Api.Match;

public interface ILorMatchV1
{
    /// <summary>
    /// Get a list of match ids by PUUID.
    /// </summary>
    /// <param name="routing"></param>
    /// <param name="puuid"></param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns></returns>
    /// <exception cref="TaskCanceledException">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</exception>
    /// <exception cref="HttpRequestException"></exception>
    /// <exception cref="ArgumentNullException">The <paramref name="puuid"/> is null.</exception>
    public Task<string[]> GetListOfMatchIdsAsync(Region routing, string puuid, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get match by id.
    /// </summary>
    /// <param name="routing"></param>
    /// <param name="matchId"></param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns></returns>
    /// <exception cref="TaskCanceledException">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</exception>
    /// <exception cref="HttpRequestException"></exception>
    /// <exception cref="ArgumentNullException">The <paramref name="matchId"/> is null.</exception>
    public Task<Match?> GetMatchAsync(Region routing, string matchId, CancellationToken cancellationToken = default);
}
