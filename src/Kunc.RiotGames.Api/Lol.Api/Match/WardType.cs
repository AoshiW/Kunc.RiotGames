using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api.Match;

[JsonConverter(typeof(JsonStringEnumMemberConverter)), JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: UnknownEnumValue)]
public enum WardType
{
    /// <summary>
    /// Represent unknow enum value.
    /// </summary>
    UnknownEnumValue,

    Undefined,

    [EnumMember(Value = "YELLOW_TRINKET")]
    YellowTrinket,
    
    [EnumMember(Value = "BLUE_TRINKET")]
    BlueTrinket,
    
    [EnumMember(Value = "CONTROL_WARD")]
    ControlWard,
    
    [EnumMember(Value = "TEEMO_MUSHROOM")]
    TeemoMushroom,
    
    [EnumMember(Value = "SIGHT_WARD")]
    SightWard,
}
