using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

/// <summary>
/// Team identification
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter)), JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: UnknownEnumValue)]
public enum Team
{
    /// <summary>
    /// Represent unknow enum value.
    /// </summary>
    UnknownEnumValue = -1,

    /// <summary>
    /// Blue team
    /// </summary>
    Order = 100,

    /// <summary>
    /// Red team
    /// </summary>
    Chaos = 200,

    //??
    All = -100,
    Unknown = 0,
    Neutral = 300,
}
