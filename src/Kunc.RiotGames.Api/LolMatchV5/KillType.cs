using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolMatchV5;

[JsonConverter(typeof(JsonStringEnumConverter<KillType>))]
public enum KillType
{
    [JsonStringEnumMemberName("KILL_FIRST_BLOOD")]
    FirstBlood,

    [JsonStringEnumMemberName("KILL_MULTI")]
    Multi,

    [JsonStringEnumMemberName("KILL_ACE")]
    Ace
}
