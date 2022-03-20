using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon;

public record Passive : BaseDto
{
    [JsonPropertyName("name")]
    public string Name { get; init; } = default!;

    [JsonPropertyName("description")]
    public string Description { get; init; } = default!;

    [JsonPropertyName("image")]
    public Image Image { get; init; } = default!;
}
