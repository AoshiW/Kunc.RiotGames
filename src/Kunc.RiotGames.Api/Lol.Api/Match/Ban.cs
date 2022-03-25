using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api.Match;

public record Ban : BaseDto
{
    [JsonPropertyName("championId")]
    public int ChampionId { get; init; }

    [JsonPropertyName("pickTurn")]
    public int PickTurn { get; init; }
}
