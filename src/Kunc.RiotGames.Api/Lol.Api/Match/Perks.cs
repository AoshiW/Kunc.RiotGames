using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api.Match;

public record Perks : BaseDto
{
    [JsonPropertyName("statPerks")]
    public PerkStats StatPerks { get; init; } = default!;

    [JsonPropertyName("styles")]
    public PerkStyle[] styles { get; init; } = default!;
}
