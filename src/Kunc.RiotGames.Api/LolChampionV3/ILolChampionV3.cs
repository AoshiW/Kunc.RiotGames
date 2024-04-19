
namespace Kunc.RiotGames.Api.LolChampionV3;

public interface ILolChampionV3
{
    /// <summary>
    /// Returns champion rotations, including free-to-play and low-level free-to-play rotations.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ChampionInfoDto> GetChampionFreeRotationsAsync(string region, CancellationToken cancellationToken = default);
}
