using System.Text.Json.Serialization;
using Kunc.RiotGames.Lol;

namespace Kunc.RiotGames.Api.TftLeagueV1;

//todo rewrite?
public class LeagueEntryDto : BaseDto
{
    /// <summary>
    /// Player Universal Unique Identifier. 
    /// </summary>
    [JsonPropertyName("puuid")]
    public string Puuid { get; set; } = string.Empty;

    [JsonPropertyName("leagueId")]
    public Guid? LeagueId { get; set; }

    /// <summary>
    /// Player's encrypted summonerId.
    /// </summary>
    [JsonPropertyName("summonerId")]
    public string SummonerId { get; set; } = string.Empty;

    [JsonPropertyName("queueType")]
    public QueueType QueueType { get; set; }

    [JsonPropertyName("ratedTier")]
    public RatedTier? RatedTier { get; set; }

    [JsonPropertyName("ratedRating")]
    public int? RatedRating { get; set; }

    [JsonPropertyName("tier")]
    public Tier? Tier { get; set; }

    [JsonPropertyName("rank")]
    public Division? Division { get; set; }

    [JsonPropertyName("leaguePoints")]
    public int? LeaguePoints { get; set; }

    [JsonPropertyName("wins")]
    public int Wins { get; set; }

    [JsonPropertyName("losses")]
    public int Losses { get; set; }

    [JsonPropertyName("hotStreak")]
    public bool? HasHotStreak { get; set; }

    [JsonPropertyName("veteran")]
    public bool? IsVeteran { get; set; }

    [JsonPropertyName("freshBlood")]
    public bool? IsFreshBlood { get; set; }

    [JsonPropertyName("inactive")]
    public bool? IsInactive { get; set; }
}
