using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Tft.Api.League;

public record LeagueItem : BaseDto
{
    [JsonPropertyName("freshBlood")]
    public bool FreshBlood { get; init; }

    /// <summary>
    /// First placement.
    /// </summary>
    [JsonPropertyName("wins")]
    public int Wins { get; init; }

    [JsonPropertyName("summonerName")]
    public string SummonerName { get; init; } = default!;

    [JsonPropertyName("miniSeries")]
    public MiniSeries? MiniSeries { get; init; }

    [JsonPropertyName("inactive")]
    public bool IsInactive { get; init; }

    [JsonPropertyName("veteran")]
    public bool IsVeteran { get; init; }

    [JsonPropertyName("hotStreak")]
    public bool HotStreak { get; init; }

    [JsonPropertyName("rank")]
    public int Rank { get; init; }

    [JsonPropertyName("leaguePoints")]
    public int LeaguePoints { get; init; }

    /// <summary>
    /// Second through eighth placement.
    /// </summary>
    [JsonPropertyName("losses")]
    public int Losses { get; init; }

    /// <summary>
    /// Player's encrypted summonerId.
    /// </summary>
    [JsonPropertyName("summonerId")]
    public string SummonerId { get; init; } = default!;
}
