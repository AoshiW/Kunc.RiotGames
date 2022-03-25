using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Shared.Api.Status;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum IncidentSeverity
{
    /// <summary>
    /// Represent unknow enum value.
    /// </summary>
    UnknownEnumValue,

    Info,
    Warning, 
    Critical
}