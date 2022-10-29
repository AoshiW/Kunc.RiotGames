namespace Kunc.RiotGames;

public interface IKda
{
    /// <summary>
    /// Number of assists.
    /// </summary>
    public int Assists { get; }

    /// <summary>
    /// Number of deaths.
    /// </summary>
    public int Deaths { get; }

    /// <summary>
    /// Number of kills.
    /// </summary>
    public int Kills { get; }
}
