using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api.Match;

public record PerkStyle : BaseDto
{
    [JsonPropertyName("description")]
    public string Description { get; init; } = default!;

    [JsonPropertyName("selections")]
    public PerkStyleSelection[] Selections { get; init; } = default!;

    [JsonPropertyName("style")]
    public int Style { get; init; }
}
