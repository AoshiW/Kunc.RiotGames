using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolMatchV5;

[JsonConverter(typeof(JsonStringEnumConverter<WardType>))]
public enum WardType
{
    CONTROL_WARD,
    YELLOW_TRINKET,
    BLUE_TRINKET,
    TEEMO_MUSHROOM,
    UNDEFINED,
}
