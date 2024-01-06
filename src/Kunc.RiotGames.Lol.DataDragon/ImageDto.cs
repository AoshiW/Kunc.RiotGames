using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon;

public class ImageDto : BaseDto
{
    [JsonPropertyName("full")]
    public string Full { get; set; } = string.Empty;

    [JsonPropertyName("sprite")]
    public string Sprite { get; set; } = string.Empty;

    [JsonPropertyName("group")]
    public string Group { get; set; } = string.Empty;

    [JsonPropertyName("x")]
    public int X { get; set; }

    [JsonPropertyName("y")]
    public int Y { get; set; }

    [JsonPropertyName("w")]
    public int Width { get; set; }

    [JsonPropertyName("h")]
    public int Height { get; set; }

    public string GetUriPath(string version)
    {
        ArgumentNullException.ThrowIfNull(version);
        return $"cdn/{version}/img/{Group}/{Full}";
    }
}
