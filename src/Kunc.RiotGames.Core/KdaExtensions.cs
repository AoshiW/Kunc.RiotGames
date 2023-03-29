namespace Kunc.RiotGames;

/// <summary>
/// Provides extension methods for the <see cref="IKda"/>.
/// </summary>
public static class KdaExtensions
{
    /// <summary>
    /// Calculates the ratio of kills and assists to deaths.
    /// </summary>
    /// <param name="kda"></param>
    /// <returns>A number greater than or equal to 0.</returns>
    public static double GetKdaRatio(this IKda kda)
    {
        ArgumentNullException.ThrowIfNull(kda);
        double ka = kda.Kills + kda.Assists;
        return kda.Deaths == 0 ? ka : ka / kda.Deaths;
    }
}
