namespace Kunc.RiotGames.Lol.Api.Champion;

public interface ILolChampionV3
{
    /// <summary>
    /// Returns champion rotations, including free-to-play and low-level free-to-play rotations.
    /// </summary>
    /// <param name="routing"></param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns></returns>
    /// <exception cref="TaskCanceledException">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</exception>
    /// <exception cref="HttpRequestException"></exception>
    Task<ChampionRotation> GetSummonerByAccountIDAsync(Platform routing, CancellationToken cancellationToken = default);
}
