using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolMatchV5;

[JsonConverter(typeof(JsonStringEnumConverter<MonsterSubType>))]
public enum MonsterSubType
{
    [JsonStringEnumMemberName("FIRE_DRAGON")]
    FireDragon,

    [JsonStringEnumMemberName("EARTH_DRAGON")]
    EarthDragon,

    [JsonStringEnumMemberName("WATER_DRAGON")]
    WaterDragon,

    [JsonStringEnumMemberName("AIR_DRAGON")]
    AirDragon,

    [JsonStringEnumMemberName("CHEMTECH_DRAGON")]
    ChemtechDragon,

    [JsonStringEnumMemberName("HEXTECH_DRAGON")]
    HextechDragon,

    [JsonStringEnumMemberName("ELDER_DRAGON")]
    ElderDragon,
}
