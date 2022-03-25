using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api.Spectator;

public record GameCustomizationObject : BaseDto
{
    /// <summary>
    /// Category identifier for Game Customization.
    /// </summary>
    [JsonPropertyName("category")]
    public string Category { get; set; } = default!;

    /// <summary>
    /// Game Customization content.
    /// </summary>
    [JsonPropertyName("content")]
    public string Content { get; init; } = default!;
}
