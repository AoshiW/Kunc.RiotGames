using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolSpectatorV5;

public class GameCustomizationObjectDto : BaseDto
{
    /// <summary>
    /// Category identifier for Game Customization
    /// </summary>
    [JsonPropertyName("category")]
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Game Customization content
    /// </summary>
    [JsonPropertyName("content")]
    public string Content { get; set; } = string.Empty;
}

