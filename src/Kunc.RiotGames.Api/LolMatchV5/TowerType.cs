using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Api.LolMatchV5;

[JsonConverter(typeof(JsonStringEnumConverterWithAltNames<TowerType>))]
public enum TowerType
{
    [JsonStringEnumMemberName("OUTER_TURRET")]
    OuterTurret,

    [JsonStringEnumMemberName("INNER_TURRET")]
    InnerTurret,

    [JsonStringEnumMemberName("BASE_TURRET")]
    BaseTurret,

    [JsonStringEnumMemberName("NEXUS_TURRET")]
    NexusTurret,
}
