using System.Text.Json.Serialization;

namespace Kunc.RiotGames;

/// <summary>
/// Platform routing values.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Platform
{
    /// <summary>
    /// Brazil
    /// </summary>
    BR1,

    /// <summary>
    /// EU Nordic and East
    /// </summary>
    EUN1,

    /// <summary>
    /// EU West
    /// </summary>
    EUW1,

    /// <summary>
    /// Japan
    /// </summary>
    JP1,

    /// <summary>
    /// Republic of Korea
    /// </summary>
    KR,

    /// <summary>
    /// Latin America North
    /// </summary>
    LA1,

    /// <summary>
    /// Latin America South
    /// </summary>
    LA2,

    /// <summary>
    /// North America
    /// </summary>
    NA1,

    /// <summary>
    /// Oceania
    /// </summary>
    OC1,

    /// <summary>
    /// Turkey
    /// </summary>
    TR1,

    /// <summary>
    /// Russia
    /// </summary>
    RU,

    /// <summary>
    /// Public Beta Environment
    /// </summary>
    PBE,
}
