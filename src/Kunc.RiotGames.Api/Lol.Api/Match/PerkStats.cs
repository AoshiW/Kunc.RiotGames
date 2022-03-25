using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api.Match;

public record PerkStats : BaseDto
{
    [JsonPropertyName("defense")]
    public int Defense { get; init; }

    [JsonPropertyName("flex")]
    public int Flex { get; init; }

    [JsonPropertyName("offense")]
    public int Offense { get; init; }
}
