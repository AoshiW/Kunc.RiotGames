using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Api.LolMatchV5;

[JsonConverter(typeof(JsonStringEnumConverterWithAltNames<BuildingType>))]
public enum BuildingType
{
    [JsonEnumName("TOWER_BUILDING")]
    Tower,

    [JsonEnumName("INHIBITOR_BUILDING")]
    Inhibitor,
}
