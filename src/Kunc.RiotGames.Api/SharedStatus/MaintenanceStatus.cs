using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.SharedStatus;

[JsonConverter(typeof(JsonStringEnumConverter<PublishLocation>))]
public enum MaintenanceStatus
{
    Scheduled,

    [JsonStringEnumMemberName("in_progress")]
    InProgress,

    Complete,
}
