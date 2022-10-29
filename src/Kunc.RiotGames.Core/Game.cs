using System.Text.Json.Serialization;

namespace Kunc.RiotGames;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Game
{
    /// <summary>
    /// League of Legends
    /// </summary>
    Lol,

    /// <summary>
    /// Legends of Runeterra
    /// </summary>
    Lor,

    /// <summary>
    /// Teamfight Tactics
    /// </summary>
    Tft,

    /// <summary>
    /// Valorant
    /// </summary>
    Val,
}
