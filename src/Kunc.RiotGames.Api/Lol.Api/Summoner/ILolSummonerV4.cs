namespace Kunc.RiotGames.Lol.Api.Summoner;

public interface ILolSummonerV4
{
    /// <summary>
    /// Get a summoner by account ID.
    /// </summary>
    /// <param name="routing">Platform to execute request.</param>
    /// <param name="encryptedAccountID"></param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>null if data was not found, otherwise an instance of <see cref="SummonerDto"/>.</returns>
    /// <exception cref="ArgumentNullException">When <paramref name="encryptedAccountID"/> is null.</exception>
    /// <exception cref="TaskCanceledException">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</exception>
    /// <exception cref="HttpRequestException"></exception>
    Task<SummonerDto?> GetSummonerByAccountIDAsync(Platform routing, string encryptedAccountID, CancellationToken cancellationToken = default);

    /// <summary>
    ///  Get a summoner by PUUID.
    /// </summary>
    /// <param name="routing">Platform to execute request.</param>
    /// <param name="encryptedPUUID">Summoner ID.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>null if data was not found, otherwise an instance of <see cref="SummonerDto"/>.</returns>
    /// <exception cref="ArgumentNullException">When <paramref name="encryptedPUUID"/> is null.</exception>
    /// <exception cref="TaskCanceledException">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</exception>
    /// <exception cref="HttpRequestException"></exception>
    Task<SummonerDto?> GetSummonerByPuuidAsync(Platform routing, string encryptedPUUID, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a summoner by summoner ID.
    /// </summary>
    /// <param name="routing">Platform to execute request.</param>
    /// <param name="encryptedSummonerId">Summoner ID</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>null if data was not found, otherwise an instance of <see cref="SummonerDto"/>.</returns>
    /// <exception cref="ArgumentNullException">When <paramref name="encryptedSummonerId"/> is null.</exception>
    /// <exception cref="TaskCanceledException">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</exception>
    /// <exception cref="HttpRequestException"></exception>
    Task<SummonerDto?> GetSummonerBySummonerIDAsync(Platform routing, string encryptedSummonerId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a summoner by summoner name.
    /// </summary>
    /// <param name="routing">Platform to execute request.</param>
    /// <param name="summonerName">Summoner Name</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>null if data was not found, otherwise an instance of <see cref="SummonerDto"/>.</returns>
    /// <exception cref="ArgumentNullException">When <paramref name="summonerName"/> is null.</exception>
    /// <exception cref="TaskCanceledException">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</exception>
    /// <exception cref="HttpRequestException"></exception>
    Task<SummonerDto?> GetSummonerBySummonerNameAsync(Platform routing, string summonerName, CancellationToken cancellationToken = default);
}
