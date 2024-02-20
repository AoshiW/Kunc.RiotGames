namespace Kunc.RiotGames.Api.RiotAccountV1;

public interface IRiotAccountV1
{
    /// <summary>
    /// Get account by puuid.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="puuid"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<AccountDto> GetAccountByPuuidAsync(string region, string puuid, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get account by riot id.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="gameName"></param>
    /// <param name="tagLine"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<AccountDto?> GetAccountByRiotIdAsync(string region, string gameName, string tagLine, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get active shard for a player.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="game"></param>
    /// <param name="puuid"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<ActiveShardDto> GetActiveShardForPlayerAsync(string region, Game game, string puuid, CancellationToken cancellationToken = default);

}
