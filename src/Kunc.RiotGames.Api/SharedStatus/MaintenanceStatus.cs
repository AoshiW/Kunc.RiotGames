using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Api.SharedStatus;

[JsonConverter(typeof(JsonStringEnumConverterWithAltNames<PublishLocation>))]
public enum MaintenanceStatus
{
    Scheduled,

    [JsonEnumName("in_progress")]
    InProgress,

    Complete,
}
