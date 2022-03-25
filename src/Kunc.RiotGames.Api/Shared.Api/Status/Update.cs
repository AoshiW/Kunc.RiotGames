using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Shared.Api.Status;

public record Update : BaseDto
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("author")]
    public string Author { get; init; }

    [JsonPropertyName("publish")]
    public bool Publish { get; init; }

    [JsonPropertyName("publish_locations")]
    public PublishLocation[] PublishLocations { get; init; }

    [JsonPropertyName("translations")]
    public ContentDto[] Translations { get; init; }

    [JsonPropertyName("created_at")]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    public DateTimeOffset UpdatedAt { get; init; }
}
