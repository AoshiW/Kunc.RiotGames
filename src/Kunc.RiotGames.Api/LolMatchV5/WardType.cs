using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolMatchV5;

[JsonConverter(typeof(JsonStringEnumConverter<WardType>))]
public enum WardType
{
    [JsonStringEnumMemberName("CONTROL_WARD")]
    ControlWard,

    [JsonStringEnumMemberName("YELLOW_TRINKET")]
    YellowTrinket,

    [JsonStringEnumMemberName("BLUE_TRINKET")]
    BlueTrinket,

    [JsonStringEnumMemberName("SIGHT_WARD")]
    SightWard,

    [JsonStringEnumMemberName("TEEMO_MUSHROOM")]
    TeemoMushroom,

    Undefined,
}
