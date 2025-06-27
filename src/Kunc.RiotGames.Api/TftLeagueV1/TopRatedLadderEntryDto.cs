using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.TftLeagueV1;

public class TopRatedLadderEntryDto : BaseDto
{
    /// <summary>
    /// Player's encrypted puuid.
    /// </summary>
    [JsonPropertyName("puuid")]
    public string Puuid { get; set; } = string.Empty;

    [JsonPropertyName("ratedTier")]
    public RatedTier RatedTier { get; set; }

    [JsonPropertyName("ratedRating")]
    public int RatedRating { get; set; }

    [JsonPropertyName("wins")]
    public int Wins { get; set; }

    [JsonPropertyName("previousUpdateLadderPosition")]
    public int PreviousUpdateLadderPosition { get; set; }
}
