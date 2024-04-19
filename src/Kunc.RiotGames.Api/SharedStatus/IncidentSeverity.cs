using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.SharedStatus;

[JsonConverter(typeof(JsonStringEnumConverter<PublishLocation>))]
public enum IncidentSeverity
{
    Info,
    Warning,
    Critical
}
