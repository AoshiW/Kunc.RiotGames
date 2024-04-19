namespace Kunc.RiotGames.Api.SharedStatus;

public interface ILolStatusV4
{
    /// <summary>
    /// Get League of Legends status for the given platform.
    /// </summary>
    Task<PlatformDataDto> GetStatus(string region, CancellationToken cancellationToken = default);
}
