using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Tft.Api.Match;

public record Companion : BaseDto
{
    [JsonPropertyName("content_ID")]
    public string ContentID { get; init; } = default!;

    [JsonPropertyName("skin_ID")]
    public int SkinID { get; init; }

    [JsonPropertyName("species")]
    public string Species { get; init; } = default!;
}