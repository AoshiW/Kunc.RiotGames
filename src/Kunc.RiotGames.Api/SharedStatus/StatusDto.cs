using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.SharedStatus;

public class StatusDto : BaseDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("maintenance_status")]
    public MaintenanceStatus? MaintenanceStatus { get; set; }

    [JsonPropertyName("incident_severity")]
    public IncidentSeverity? IncidentSeverity { get; set; }

    [JsonPropertyName("titles")]
    public ContentDto[] Titles { get; set; } = [];

    [JsonPropertyName("updates")]
    public UpdateDto[] Updates { get; set; } = [];

    [JsonPropertyName("created_at")]
    public DateTimeOffset CreatedAt { get; set; }

    [JsonPropertyName("archive_at")]
    public DateTimeOffset? ArchiveAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTimeOffset? UpdatedAt { get; set; }

    [JsonPropertyName("platforms")]
    public Platform[] Platforms { get; set; } = [];
}
