using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.TftLeagueV1;

public class TopRatedLadderEntryDto : BaseDto
{
    [JsonPropertyName("summonerId")]
    public string SummonerId { get; set; } = string.Empty;

    [JsonPropertyName("ratedTier")]
    public RatedTier RatedTier { get; set; }

    [JsonPropertyName("ratedRating")]
    public int RatedRating { get; set; }

    [JsonPropertyName("wins")]
    public int Wins { get; set; }

    [JsonPropertyName("previousUpdateLadderPosition")]
    public int PreviousUpdateLadderPosition { get; set; }
}
