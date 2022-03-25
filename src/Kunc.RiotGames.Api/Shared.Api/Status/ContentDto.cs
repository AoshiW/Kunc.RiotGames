using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Shared.Api.Status;

public record ContentDto : BaseDto
{
    [JsonPropertyName("content")]
    public string Content { get; init; } = default!;

    [JsonPropertyName("locale")]
    public string Locale { get; init; } = default!;
}
