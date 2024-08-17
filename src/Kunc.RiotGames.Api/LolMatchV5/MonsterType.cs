using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolMatchV5;

[JsonConverter(typeof(JsonStringEnumConverter<MonsterType>))]
public enum MonsterType
{
    Horde,
    RiftHerald,
    Dragon,

    [JsonStringEnumMemberName("BARON_NASHOR")]
    BaronNashor,
}
