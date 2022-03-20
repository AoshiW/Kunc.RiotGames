using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon;

public record Rune : BaseDto
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("Key")]
    public string Key { get; init; } = default!;

    [JsonPropertyName("icon")]
    public string Icon { get; init; } = default!;

    [JsonPropertyName("name")]
    public string Name { get; init; } = default!;

    [JsonPropertyName("shortDesc")]
    public string ShortDesc { get; init; } = default!;

    [JsonPropertyName("longDesc")]
    public string LongDesc { get; init; } = default!;
}