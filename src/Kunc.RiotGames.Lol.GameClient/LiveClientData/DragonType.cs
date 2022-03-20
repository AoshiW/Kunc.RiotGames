using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

[JsonConverter(typeof(JsonStringEnumMemberConverter)), JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: UnknownEnumValue)]
public enum DragonType
{
    /// <summary>
    /// Represent unknow enum value.
    /// </summary>
    UnknownEnumValue,

    /// <summary>
    /// Cloud Drake
    /// </summary>
    Air,

    /// <summary>
    /// Infernal Drake
    /// </summary>
    Fire,

    /// <summary>
    /// Mountain Drake,
    /// </summary>
    Earth,

    /// <summary>
    /// Ocean Drake
    /// </summary>
    Water,

    /// <summary>
    /// Hextech Drake
    /// </summary>
    Hextech,

    /// <summary>
    /// Elder Dragon
    /// </summary>
    Elder,
}
