namespace Kunc.RiotGames.Api.LolSpectatorV5;

public interface ILolSpectatorV5
{
    /// <summary>
    /// Get current game information for the given puuid.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="puuid"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<CurrentGameInfoDto?> GetCurrentGameInformationForPuuidAsync(string region, string puuid, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get list of featured games
    /// </summary>
    /// <param name="region"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<FeaturedGamesDto> GetFeaturedGamesAsync(string region, CancellationToken cancellationToken = default);
}
