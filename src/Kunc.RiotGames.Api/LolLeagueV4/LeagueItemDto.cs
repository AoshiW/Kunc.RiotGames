using System.Text.Json.Serialization;
using Kunc.RiotGames.Lol;

namespace Kunc.RiotGames.Api.LolLeagueV4;

public class LeagueItemDto : BaseDto
{
    [JsonPropertyName("freshBlood")]
    public bool IsFreshBlood { get; set; }

    [JsonPropertyName("wins")]
    public int Wins { get; set; }

    [JsonPropertyName("inactive")]
    public bool IsInactive { get; set; }

    [JsonPropertyName("veteran")]
    public bool IsVeteran { get; set; }

    [JsonPropertyName("hotStreak")]
    public bool HasHotStreak { get; set; }

    [JsonPropertyName("rank")]
    public Division Division { get; set; }

    [JsonPropertyName("leaguePoints")]
    public int LeaguePoints { get; set; }

    [JsonPropertyName("losses")]
    public int Losses { get; set; }

    /// <summary>
    /// Player's encrypted summonerId.
    /// </summary>
    [JsonPropertyName("summonerId")]
    public string SummonerId { get; set; } = string.Empty;
}
