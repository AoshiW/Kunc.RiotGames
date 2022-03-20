using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon;

public record LevelTip : BaseDto
{
    [JsonPropertyName("label")]
    public string[] Label { get; init; } = default!;

    [JsonPropertyName("effect")]
    public string[] Effect { get; init; } = default!;
}