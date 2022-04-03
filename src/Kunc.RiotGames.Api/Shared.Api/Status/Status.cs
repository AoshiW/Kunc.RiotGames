using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Shared.Api.Status;

public record Status : BaseDto
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = default!;

    [JsonPropertyName("maintenance_status")]
    public MaintenanceStatus MaintenanceStatus { get; init; }//todo null

    [JsonPropertyName("incident_severity")]
    public IncidentSeverity IncidentSeverity { get; init; } //todo null

    [JsonPropertyName("titles")]
    public ContentDto[] Titles { get; init; } = default!;

    [JsonPropertyName("updates")]
    public ContentDto[] Updates { get; init; } = default!;

    [JsonPropertyName("created_at")]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("archive_at")]
    public DateTimeOffset? ArchiveAt { get; init; }

    [JsonPropertyName("updated_at")]
    public DateTimeOffset? UpdatedAt { get; init; }

    [JsonPropertyName("platforms")]
    public Platform[] Platforms { get; init; } = default!;
}
