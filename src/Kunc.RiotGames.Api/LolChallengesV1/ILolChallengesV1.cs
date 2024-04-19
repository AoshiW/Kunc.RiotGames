namespace Kunc.RiotGames.Api.LolChallengesV1;

public interface ILolChallengesV1
{
    /// <summary>
    /// List of all basic challenge configuration information (includes all translations for names and descriptions).
    /// </summary>
    /// <param name="region"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ChallengeConfigInfoDto[]> GetListOfAllBasicChallengeConfigurationInformationAsync(string region, CancellationToken cancellationToken = default);

    /// <summary>
    /// Map of level to percentile of players who have achieved it - keys: ChallengeId -> Season -> Level -> percentile of players who achieved it.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Dictionary<long, Dictionary<string, double>>> GetMapOfLevelToPercentileOfPlayersAsync(string region, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get challenge configuration.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="challengeId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ChallengeConfigInfoDto?> GetChallengeConfigurationAsync(string region, long challengeId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Return top players for each level. Level must be MASTER, GRANDMASTER or CHALLENGER.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="challengeId"></param>
    /// <param name="level"></param>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ApexPlayerInfoDto[]?> GetTopPlayersAsync(string region, long challengeId, string level, TopPlayersQuery? query = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Map of level to percentile of players who have achieved it.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="challengeId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Dictionary<string, double>?> GetMapOfLevelToPercentileAsync(string region, long challengeId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns player information with list of all progressed challenges.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="puuid"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<PlayerInfoDto> GetPlayerInformationAsync(string region, string puuid, CancellationToken cancellationToken = default);
}
