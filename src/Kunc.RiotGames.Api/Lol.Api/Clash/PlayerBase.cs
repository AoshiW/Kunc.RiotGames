using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api.Clash;

public record PlayerBase : BaseDto
{
    [JsonPropertyName("summonerId")]
    public string SummonerId { get; init; } = default!;

    [JsonPropertyName("position")]
    public Positions Position { get; init; }

    [JsonPropertyName("role")]
    public ClashRole Role { get; init; }
}
