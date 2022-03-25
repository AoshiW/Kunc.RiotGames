namespace Kunc.RiotGames.Shared.Api.Account;

public interface IRiotAccountV1
{
    /// <summary>
    /// Get account by puuid.
    /// </summary>
    /// <remarks>When querying for a player by their riot id, the gameName and tagLine query params are required. However not all accounts have a gameName and tagLine associated so these fields may not be included in the response.
    /// </remarks>
    /// <param name="routing">You can query for any account in any region.</param>
    /// <param name="puuid">Account's puuid.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns></returns>
    /// <exception cref="TaskCanceledException">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</exception>
    /// <exception cref="HttpRequestException"></exception>
    /// <exception cref="ArgumentNullException">The <paramref name="puuid"/> is null.</exception>
    Task<Account> GetAccountAsync(Region routing, string puuid, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get account by riot id.
    /// </summary>
    /// <remarks>
    /// When querying for a player by their riot id, the gameName and tagLine query params are required. However not all accounts have a gameName and tagLine associated so these fields may not be included in the response.
    /// </remarks>
    /// <param name="routing">You can query for any account in any region.</param>
    /// <param name="gameName">Account's game name.</param>
    /// <param name="tagLine">Account's tagline.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns></returns>
    /// <exception cref="TaskCanceledException">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</exception>
    /// <exception cref="HttpRequestException"></exception>
    /// <exception cref="ArgumentNullException">The <paramref name="gameName"/> or <paramref name="tagLine"/> is null.</exception>
    Task<Account?> GetAccountAsync(Region routing, string gameName, string tagLine, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get active shard for a player.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="routing">You can query for any account in any region.</param>
    /// <param name="game">Riot game.</param>
    /// <param name="puuid">Account's puuid.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns></returns>
    /// <exception cref="TaskCanceledException">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</exception>
    /// <exception cref="HttpRequestException"></exception>
    /// <exception cref="ArgumentNullException">The <paramref name="puuid"/> is null.</exception>
    Task<ActiveShardDto<T>> GetActiveShardAsync<T>(Region routing, Game game, string puuid, CancellationToken cancellationToken = default);
}