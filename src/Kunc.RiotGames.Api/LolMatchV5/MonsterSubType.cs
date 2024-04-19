using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Api.LolMatchV5;

[JsonConverter(typeof(JsonStringEnumConverterWithAltNames<MonsterSubType>))]
public enum MonsterSubType
{
    [JsonEnumName("FIRE_DRAGON")]
    FireDragon,

    [JsonEnumName("EARTH_DRAGON")]
    EarthDragon,

    [JsonEnumName("WATER_DRAGON")]
    WaterDragon,

    [JsonEnumName("AIR_DRAGON")]
    AirDragon,

    [JsonEnumName("CHEMTECH_DRAGON")]
    ChemtechDragon,

    [JsonEnumName("HEXTECH_DRAGON")]
    HextechDragon,

    [JsonEnumName("ELDER_DRAGON")]
    ElderDragon,
}
