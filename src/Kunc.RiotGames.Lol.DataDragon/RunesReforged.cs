using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon;

public record RunesReforged : BaseDto
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("Key")]
    public string Key { get; init; } = default!;

    [JsonPropertyName("icon")]
    public string Icon { get; init; } = default!;

    [JsonPropertyName("name")]
    public string Name { get; init; } = default!;

    [JsonPropertyName("slots")]
    public RunesSlot[] Slots { get; init; } = default!;
}
