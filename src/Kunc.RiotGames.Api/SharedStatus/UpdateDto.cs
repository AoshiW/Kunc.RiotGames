using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.SharedStatus;

public class UpdateDto : BaseDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("author")]
    public string Author { get; set; } = string.Empty;

    [JsonPropertyName("publish")]
    public bool IsPublish { get; set; }

    [JsonPropertyName("publish_locations")]
    public PublishLocation[] PublishLocations { get; set; } = [];

    [JsonPropertyName("translations")]
    public ContentDto[] Itranslations { get; set; } = [];

    [JsonPropertyName("created_at")]
    public DateTimeOffset CreatedAt { get; set; }

    [JsonPropertyName("archive_at")]
    public DateTimeOffset? ArchiveAt { get; set; }
}
