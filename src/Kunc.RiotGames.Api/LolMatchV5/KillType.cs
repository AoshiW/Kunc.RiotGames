using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolMatchV5;

[JsonConverter(typeof(JsonStringEnumConverter<KillType>))]
public enum KillType
{
    KILL_FIRST_BLOOD,
    KILL_MULTI,
    KILL_ACE
}
