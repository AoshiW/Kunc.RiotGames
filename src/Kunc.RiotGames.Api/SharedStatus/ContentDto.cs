using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.SharedStatus;

public class ContentDto : BaseDto
{
    [JsonPropertyName("locale")]
    public string Locale { get; set; } = string.Empty;

    [JsonPropertyName("content")]
    public string Content { get; set; } = string.Empty;
}
