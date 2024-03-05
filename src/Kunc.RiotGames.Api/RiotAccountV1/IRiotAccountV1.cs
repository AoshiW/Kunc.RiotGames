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
    Task<AccountDto> GetAccountByPuuidAsync(string region, string puuid, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get account by riot id.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="gameName"></param>
    /// <param name="tagLine"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<AccountDto?> GetAccountByRiotIdAsync(string region, string gameName, string tagLine, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get account by riot id.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="riotId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<AccountDto?> GetAccountByRiotIdAsync(string region, string riotId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(region);
        ArgumentNullException.ThrowIfNull(riotId);
        var indexSplit = riotId.IndexOf('#');
        if (indexSplit == -1)
            throw new ArgumentException($"{nameof(riotId)} must contain char '#'.", nameof(riotId));

        var gameName = riotId.Substring(0, indexSplit);
        var tagLine = riotId.Substring(indexSplit + 1);
        return GetAccountByRiotIdAsync(region, gameName, tagLine, cancellationToken);
    }

    /// <summary>
    /// Get active shard for a player.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="game"></param>
    /// <param name="puuid"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ActiveShardDto> GetActiveShardForPlayerAsync(string region, Game game, string puuid, CancellationToken cancellationToken = default);
}
