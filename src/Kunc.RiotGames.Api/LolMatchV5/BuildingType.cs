using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Api.LolMatchV5;

[JsonConverter(typeof(JsonStringEnumConverterWithAltNames<BuildingType>))]
public enum BuildingType
{
    [JsonStringEnumMemberName("TOWER_BUILDING")]
    Tower,

    [JsonStringEnumMemberName("INHIBITOR_BUILDING")]
    Inhibitor,
}
