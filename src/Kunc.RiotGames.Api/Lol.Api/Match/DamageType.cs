using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api.Match;

[JsonConverter(typeof(JsonStringEnumMemberConverter)), JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: UnknownEnumValue)]
public enum DamageType
{
    /// <summary>
    /// Represent unknow enum value.
    /// </summary>
    UnknownEnumValue,

    Other,
    Tower,
    Minion,
    Monster
}
