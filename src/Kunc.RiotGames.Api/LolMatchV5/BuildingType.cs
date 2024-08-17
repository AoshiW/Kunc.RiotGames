using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolMatchV5;

[JsonConverter(typeof(JsonStringEnumConverter<BuildingType>))]
public enum BuildingType
{
    [JsonStringEnumMemberName("TOWER_BUILDING")]
    Tower,

    [JsonStringEnumMemberName("INHIBITOR_BUILDING")]
    Inhibitor,
}
