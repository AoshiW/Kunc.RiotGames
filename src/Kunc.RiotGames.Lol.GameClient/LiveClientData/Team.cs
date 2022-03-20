using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

[JsonConverter(typeof(JsonStringEnumMemberConverter)), JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: UnknownEnumValue)]
public enum Team
{
    /// <summary>
    /// Represent unknow enum value.
    /// </summary>
    UnknownEnumValue,

    /// <summary>
    /// Red team
    /// </summary>
    Chaos,

    /// <summary>
    /// Blue team
    /// </summary>
    Order,
    //All, Unknown, Neutral
}
