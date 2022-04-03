using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Shared.Api.Status;

public record Update : BaseDto
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("author")]
    public string Author { get; init; } = default!;

    [JsonPropertyName("publish")]
    public bool IsPublish { get; init; }

    [JsonPropertyName("publish_locations")]
    public PublishLocation[] PublishLocations { get; init; } = default!;

    [JsonPropertyName("translations")]
    public ContentDto[] Translations { get; init; } = default!;

    [JsonPropertyName("created_at")]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    public DateTimeOffset UpdatedAt { get; init; }
}
