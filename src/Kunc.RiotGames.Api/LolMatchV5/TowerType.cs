using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Api.LolMatchV5;

[JsonConverter(typeof(JsonStringEnumConverterWithAltNames<TowerType>))]
public enum TowerType
{
    [JsonEnumName("OUTER_TURRET")]
    OuterTurret,

    [JsonEnumName("INNER_TURRET")]
    InnerTurret,

    [JsonEnumName("BASE_TURRET")]
    BaseTurret,

    [JsonEnumName("NEXUS_TURRET")]
    NexusTurret,
}
