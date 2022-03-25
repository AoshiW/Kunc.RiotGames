using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Tft.Api.League;

public record TopRatedLadderEntry : BaseDto
{
    [JsonPropertyName("summonerId")]
    public string SummonerId { get; init; } = default!;

    [JsonPropertyName("summonerName")]
    public string SummonerName { get; init; } = default!;

    [JsonPropertyName("ratedTier")]
    public RatedTier RatedTier { get; init; }

    [JsonPropertyName("ratedRating")]
    public int RatedRating { get; init; }

    [JsonPropertyName("wins")]
    public int Wins { get; init; }

    [JsonPropertyName("previousUpdateLadderPosition")]
    public int PreviousUpdateLadderPosition { get; init; }
}
