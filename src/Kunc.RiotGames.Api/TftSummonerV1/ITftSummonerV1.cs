namespace Kunc.RiotGames.Api.TftSummonerV1;

public interface ITftSummonerV1
{
    /// <summary>
    /// Get a summoner by PUUID.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="puuid"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SummonerDto> GetSummonerByPuuidAsync(string region, string puuid, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a summoner by summoner ID.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="summonerId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SummonerDto> GetSummonerBySummonerIdAsync(string region, string summonerId, CancellationToken cancellationToken = default);
}
