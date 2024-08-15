using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Api.LolMatchV5;

[JsonConverter(typeof(JsonStringEnumConverterWithAltNames<MonsterType>))]
public enum MonsterType
{
    Horde,
    RiftHerald,
    Dragon,

    [JsonStringEnumMemberName("BARON_NASHOR")]
    BaronNashor,
}
