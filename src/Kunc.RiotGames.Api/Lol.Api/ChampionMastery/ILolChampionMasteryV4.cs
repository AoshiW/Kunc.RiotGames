namespace Kunc.RiotGames.Lol.Api.ChampionMastery;

public interface ILolChampionMasteryV4
{
    /// <summary>
    ///  Get all champion mastery entries sorted by number of champion points descending.
    /// </summary>
    /// <param name="rouing"><see cref="Platform"/> to execute request.</param>
    /// <param name="encryptedSummonerId">Summoner ID associated with the player</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">When <paramref name="encryptedSummonerId"/> is null.</exception>
    /// <exception cref="TaskCanceledException">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</exception>
    /// <exception cref="HttpRequestException"></exception>
    Task<ChampionMastery[]> GetAllChampionMasteriesAsync(Platform rouing, string encryptedSummonerId, CancellationToken cancellationToken = default);


    /// <summary>
    /// Get a champion mastery by summoner ID and champion ID.
    /// </summary>
    /// <param name="rouing"><see cref="Platform"/> to execute request.</param>
    /// <param name="encryptedSummonerId">Summoner ID associated with the player</param>
    /// <param name="championID">Champion ID to retrieve Champion Mastery for</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>null if data was not found, otherwise an instance of <see cref="ChampionMastery"/>.</returns>
    /// <exception cref="ArgumentNullException">When <paramref name="encryptedSummonerId"/> is null.</exception>
    /// <exception cref="TaskCanceledException">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</exception>
    /// <exception cref="HttpRequestException"></exception>
    Task<ChampionMastery?> GetChampionMasteriesAsync(Platform rouing, string encryptedSummonerId, long championID, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a player's total champion mastery score, which is the sum of individual champion mastery levels.
    /// </summary>
    /// <param name="rouing"><see cref="Platform"/> to execute request.</param>
    /// <param name="encryptedSummonerId">Summoner ID associated with the player</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">When <paramref name="encryptedSummonerId"/> is null.</exception>
    /// <exception cref="TaskCanceledException">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</exception>
    /// <exception cref="HttpRequestException"></exception>
    Task<int> GetTotalMasteryPointAsync(Platform rouing, string encryptedSummonerId, CancellationToken cancellationToken = default);
}
