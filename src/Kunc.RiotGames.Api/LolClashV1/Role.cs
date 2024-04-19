using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolClashV1;

[JsonConverter(typeof(JsonStringEnumConverter<Role>))]
public enum Role
{
    Captain,
    Member,
}
