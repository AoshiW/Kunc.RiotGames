using Kunc.RiotGames.Lol.Api.Summoner;

namespace Kunc.RiotGames.Tft.Api.Summoner;

public interface ITftSummonerV1
{
    /// <summary>
    /// Get a summoner by account ID.
    /// </summary>
    /// <param name="routing">Platform to execute request.</param>
    /// <param name="encryptedAccountID"></param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns></returns>
    /// <exception cref="TaskCanceledException">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</exception>
    /// <exception cref="HttpRequestException"></exception>
    /// <exception cref="ArgumentNullException">The <paramref name="encryptedAccountID"/> is null.</exception>
    Task<SummonerDto?> GetSummonerByAccountIDAsync(Platform routing, string encryptedAccountID, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a summoner by PUUID.
    /// </summary>
    /// <param name="routing">Platform to execute request.</param>
    /// <param name="encryptedPUUID"></param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns></returns>
    /// <exception cref="TaskCanceledException">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</exception>
    /// <exception cref="HttpRequestException"></exception>
    /// <exception cref="ArgumentNullException">The <paramref name="encryptedPUUID"/> is null.</exception>
    Task<SummonerDto?> GetSummonerByPuuidAsync(Platform routing, string encryptedPUUID, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a summoner by summoner ID.
    /// </summary>
    /// <param name="routing">Platform to execute request.</param>
    /// <param name="encryptedSummonerId">Summoner ID</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns></returns>
    /// <exception cref="TaskCanceledException">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</exception>
    /// <exception cref="HttpRequestException"></exception>
    /// <exception cref="ArgumentNullException">The <paramref name="encryptedSummonerId"/> is null.</exception>
    Task<SummonerDto?> GetSummonerBySummonerIDAsync(Platform routing, string encryptedSummonerId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a summoner by summoner name.
    /// </summary>
    /// <param name="routing">Platform to execute request.</param>
    /// <param name="summonerName">Summoner Name</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns></returns>
    /// <exception cref="TaskCanceledException">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</exception>
    /// <exception cref="HttpRequestException"></exception>
    /// <exception cref="ArgumentNullException">The <paramref name="summonerName"/> is null.</exception>
    Task<SummonerDto?> GetSummonerBySummonerNameAsync(Platform routing, string summonerName, CancellationToken cancellationToken = default);
}
