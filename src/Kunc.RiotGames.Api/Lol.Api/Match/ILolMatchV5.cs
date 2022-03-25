namespace Kunc.RiotGames.Lol.Api.Match;

public interface ILolMatchV5
{
    /// <summary>
    /// Get a list of match ids by puuid.
    /// </summary>
    /// <remarks>
    /// The matchlist started storing timestamps on June 16th, 2021. Any matches played before June 16th, 2021 won't be included in the results if the startTime filter is set.
    /// </remarks>
    /// <param name="rouing"></param>
    /// <param name="puuid"></param>
    /// <param name="startTime"></param>
    /// <param name="endTime"></param>
    /// <param name="queue">Filter the list of match ids by a specific queue id.</param>
    /// <param name="type">Filter the list of match ids by the type of match.</param>
    /// <param name="start">Start index.</param>
    /// <param name="count">Number of match ids to return.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns></returns>
    /// <exception cref="TaskCanceledException">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</exception>
    /// <exception cref="HttpRequestException"></exception>
    Task<string[]> GetListMatchIdsAsync(Region rouing, string puuid, long? startTime = null, long? endTime = null, int? queue = null, string? type = null, int? start = null, int? count = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a match by match id.
    /// </summary>
    /// <param name="rouing"></param>
    /// <param name="matchId"></param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns></returns>
    /// <exception cref="TaskCanceledException">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</exception>
    /// <exception cref="HttpRequestException"></exception>
    Task<Match?> GetMatchAsync(Region rouing, string matchId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a match timeline by match id.
    /// </summary>
    /// <param name="rouing"></param>
    /// <param name="matchId"></param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns></returns>
    /// <exception cref="TaskCanceledException">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</exception>
    /// <exception cref="HttpRequestException"></exception>
    Task<MatchTimeline?> GetMatchTimelineAsync(Region rouing, string matchId, CancellationToken cancellationToken = default);
}
