namespace Kunc.RiotGames.Lol.Api.Spectator;

public interface ILolSpectatorV4
{
    /// <summary>
    /// Get current game information for the given summoner ID.
    /// </summary>
    /// <param name="rouing"></param>
    /// <param name="encryptedSummonerId"></param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns></returns>
    /// <exception cref="TaskCanceledException">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</exception>
    /// <exception cref="HttpRequestException"></exception>
    /// <exception cref="ArgumentNullException">When <paramref name="encryptedSummonerId"/> is null.</exception>
    Task<CurrentGameInfo?> GetCurrentGameInformationForSummonerAsync(Platform rouing, string encryptedSummonerId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get list of featured games.
    /// </summary>
    /// <param name="rouing"></param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns></returns>
    /// <exception cref="TaskCanceledException">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</exception>
    /// <exception cref="HttpRequestException"></exception>
    Task<FeaturedGames> GetFeaturedGamesAsync(Platform rouing, CancellationToken cancellationToken = default);
}
