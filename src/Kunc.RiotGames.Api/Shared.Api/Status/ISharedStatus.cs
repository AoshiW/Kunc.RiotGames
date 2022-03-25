namespace Kunc.RiotGames.Shared.Api.Status;

public interface ISharedStatus
{
    /// <summary>
    /// Get game status for the given platform.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="TaskCanceledException">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</exception>
    /// <exception cref="HttpRequestException"></exception>
    Task<PlatformData> GetStatusAsync(string region, CancellationToken cancellationToken = default);
}
