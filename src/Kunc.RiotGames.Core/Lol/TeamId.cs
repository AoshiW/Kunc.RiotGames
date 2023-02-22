using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TeamId
{
    All = -100,

    Unknown = 0,

    /// <summary>   
    /// Blue team
    /// </summary>
    Order = 100,

    /// <summary>
    /// Red team
    /// </summary>
    Chaos = 200,

    /// <remarks>
    /// When Baron kill herald.
    /// </remarks>
    Neutral = 300,
}
