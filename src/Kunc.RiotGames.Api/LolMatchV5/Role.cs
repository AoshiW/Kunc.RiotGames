using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolMatchV5;

[JsonConverter(typeof(JsonStringEnumConverter<Role>))]
public enum Role
{
    None,
    Solo,
    Carry,
    Support,
    Duo,
}
