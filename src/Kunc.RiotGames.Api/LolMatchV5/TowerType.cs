using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolMatchV5;

[JsonConverter(typeof(JsonStringEnumConverter<TowerType>))]
public enum TowerType
{
    OUTER_TURRET,
    INNER_TURRET,
    BASE_TURRET,
    NEXUS_TURRET,
}
