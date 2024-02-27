using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolMatchV5;

[JsonConverter(typeof(JsonStringEnumConverter<BuildingType>))]
public enum BuildingType
{
    TOWER_BUILDING,
    INHIBITOR_BUILDING,
}
