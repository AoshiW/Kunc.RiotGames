using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api.Match;

[JsonConverter(typeof(JsonStringEnumMemberConverter)), JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: UnknownEnumValue)]
public enum LaneType
{
    /// <summary>
    /// Represent unknow enum value.
    /// </summary>
    UnknownEnumValue,

    [EnumMember(Value = "TOP_LANE")]
    TopLane,

    [EnumMember(Value = "MID_LANE")]
    MidLane,

    [EnumMember(Value = "BOT_LANE")]
    BotLane
}