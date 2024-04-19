using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Api.LolMatchV5;

[JsonConverter(typeof(JsonStringEnumConverterWithAltNames<KillType>))]
public enum KillType
{
    [JsonEnumName("KILL_FIRST_BLOOD")]
    FirstBlood,

    [JsonEnumName("KILL_MULTI")]
    Multi,

    [JsonEnumName("KILL_ACE")]
    Ace
}
