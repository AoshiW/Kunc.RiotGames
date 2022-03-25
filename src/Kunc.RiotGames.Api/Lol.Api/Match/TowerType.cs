using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol;

[JsonConverter(typeof(JsonStringEnumMemberConverter)), JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: UnknownEnumValue)]
public enum TowerType
{
    /// <summary>
    /// Represent unknow enum value.
    /// </summary>
    UnknownEnumValue,

    [EnumMember(Value = "NEXUS_TURRET")]
    NexusTurret,

    [EnumMember(Value = "OUTER_TURRET")]
    OuterTurret,

    [EnumMember(Value = "INNER_TURRET")]
    InnerTurret,

    [EnumMember(Value = "BASE_TURRET")]
    BaseTurret,
}
