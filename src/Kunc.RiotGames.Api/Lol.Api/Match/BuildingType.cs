using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api.Match;

[JsonConverter(typeof(JsonStringEnumMemberConverter)), JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: UnknownEnumValue)]
public enum BuildingType
{
    /// <summary>
    /// Represent unknow enum value.
    /// </summary>
    UnknownEnumValue,

    [EnumMember(Value = "TOWER_BUILDING")]
    TowerBuilding,

    [EnumMember(Value = "INHIBITOR_BUILDING")]
    InhibitorBuilding,
}
