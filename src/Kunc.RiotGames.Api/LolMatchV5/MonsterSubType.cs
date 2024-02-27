using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolMatchV5;

[JsonConverter(typeof(JsonStringEnumConverter<MonsterSubType>))]
public enum MonsterSubType
{
    FIRE_DRAGON,
    EARTH_DRAGON,
    WATER_DRAGON,
    AIR_DRAGON,
    CHEMTECH_DRAGON, 
    HEXTECH_DRAGON,
    ELDER_DRAGON,
}
