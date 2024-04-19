using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.SharedStatus;

[JsonConverter(typeof(JsonStringEnumConverter<PublishLocation>))]
public enum Platform
{
    Windows,
    macOS,
    Android,
    iOS,
    PS4,
    xbone,
    Switch
}
