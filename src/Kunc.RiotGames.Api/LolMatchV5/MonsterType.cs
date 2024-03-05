using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolMatchV5;

[JsonConverter(typeof(JsonStringEnumConverter<MonsterType>))]
public enum MonsterType
{
    HORDE,
    RIFTHERALD,
    DRAGON,
    BARON_NASHOR,
}
