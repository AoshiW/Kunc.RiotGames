using System.Text.Json.Serialization;

namespace Kunc.RiotGames;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Game
{
    /// <summary>
    /// Legends of Runeterra
    /// </summary>
    Lor,

    /// <summary>
    /// Valorant
    /// </summary>
    Val,
}
