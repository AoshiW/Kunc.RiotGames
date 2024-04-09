namespace Kunc.RiotGames.Api.SharedStatus;

public interface ITftStatusV1
{
    /// <summary>
    /// Get Teamfight Tactics status for the given platform.
    /// </summary>
    Task<PlatformDataDto> GetStatus(string region, CancellationToken cancellationToken = default);
}
