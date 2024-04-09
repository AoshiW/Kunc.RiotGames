namespace Kunc.RiotGames.Api.SharedStatus;

public interface ILorStatusV1
{
    /// <summary>
    /// Get Legends of Runeterra status for the given platform.
    /// </summary>
    Task<PlatformDataDto> GetStatus(string region, CancellationToken cancellationToken = default);
}
