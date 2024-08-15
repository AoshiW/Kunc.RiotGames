using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Api.LolMatchV5;

[JsonConverter(typeof(JsonStringEnumConverterWithAltNames<KillType>))]
public enum KillType
{
    [JsonStringEnumMemberName("KILL_FIRST_BLOOD")]
    FirstBlood,

    [JsonStringEnumMemberName("KILL_MULTI")]
    Multi,

    [JsonStringEnumMemberName("KILL_ACE")]
    Ace
}
