using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lor.GameClient;

/// <summary>
/// Game screen resolution
/// </summary>
public record Screen : BaseDto
{
    /// <summary>
    /// Screen width
    /// </summary>
    [JsonPropertyName("ScreenWidth")]
    public int Width { get; init; }

    /// <summary>
    /// Screen height
    /// </summary>
    [JsonPropertyName("ScreenHeight")]
    public int Height { get; init; }
}
