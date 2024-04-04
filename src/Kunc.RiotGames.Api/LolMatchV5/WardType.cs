using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Api.LolMatchV5;

[JsonConverter(typeof(JsonStringEnumConverterWithAltNames<WardType>))]
public enum WardType
{
    [JsonEnumName("CONTROL_WARD")]
    ControlWard,

    [JsonEnumName("YELLOW_TRINKET")]
    YellowTrinket,

    [JsonEnumName("BLUE_TRINKET")]
    BlueTrinket,

    [JsonEnumName("SIGHT_WARD")]
    SightWard,

    [JsonEnumName("TEEMO_MUSHROOM")]
    TeemoMushroom,

    Undefined,
}
