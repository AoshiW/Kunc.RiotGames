using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api.Match;

[JsonConverter(typeof(JsonStringEnumMemberConverter)), JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: UnknownEnumValue)]
public enum KillType
{
    /// <summary>
    /// Represent unknow enum value.
    /// </summary>
    UnknownEnumValue,

    [EnumMember(Value = "KILL_FIRST_BLOOD")]
    KillFirstBlood,

    [EnumMember(Value = "KILL_MULTI")]
    KillMulti,

    [EnumMember(Value = "KILL_ACE")]
    KillAce,
}
