namespace Kunc.RiotGames;

public static class KdaExtensions
{
    public static double GetKdaRatio(this IKda kda)
    {
        ArgumentNullException.ThrowIfNull(kda);
        double ka = kda.Kills + kda.Assists;
        return kda.Deaths == 0 ? ka : ka / kda.Deaths;
    }
}
