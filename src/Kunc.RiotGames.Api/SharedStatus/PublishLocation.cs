using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.SharedStatus;

[JsonConverter(typeof(JsonStringEnumConverter<PublishLocation>))]
public enum PublishLocation
{
    RiotClient,
    RiotStatus,
    Game,
}
