using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon;

public record Image : BaseDto
{
    [JsonPropertyName("full")]
    public string Full { get; init; } = default!;

    [JsonPropertyName("sprite")]
    public string Sprite { get; init; } = default!;

    [JsonPropertyName("group")]
    public string Group { get; init; } = default!;

    [JsonPropertyName("x")]
    public int X { get; init; }

    [JsonPropertyName("y")]
    public int Y { get; init; }

    [JsonPropertyName("w")]
    public int W { get; init; }

    [JsonPropertyName("h")]
    public int H { get; init; }
}