namespace Kunc.RiotGames.Api.LolSpectatorV4;

public interface ILolSpectatorV4
{
    /// <summary>
    /// Get current game information for the given summoner ID.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="summonerId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<CurrentGameInfoDto?> GetCurrentGameInformationForSummonerAsync(string region, string summonerId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get list of featured games
    /// </summary>
    /// <param name="region"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<FeaturedGamesDto> GetListOfFeaturedGamesAsync(string region, CancellationToken cancellationToken = default);
}
