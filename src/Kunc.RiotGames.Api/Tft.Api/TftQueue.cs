using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Tft.Api;

[JsonConverter(typeof(JsonStringEnumMemberConverter)), JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: UnknownEnumValue)]
public enum TftQueue
{
    /// <summary>
    /// Represent unknow enum value.
    /// </summary>
    UnknownEnumValue,

    [EnumMember(Value = "RANKED_TFT")]
    Ranked,

    [EnumMember(Value = "RANKED_TFT_TURBO")]
    RankedTurbo,
}