using System.Text.Json.Serialization;

using Kunc.RiotGames.Lol.Api;

namespace Kunc.RiotGames.Tft.Api.League;

public record LeagueEntry : BaseDto
{
    /// <inheritdoc/>
    [JsonPropertyName("leagueId")]
    public string? LeagueId { get; init; }

    /// <inheritdoc/>
    [JsonPropertyName("summonerId")]
    public string SummonerId { get; init; } = default!;

    /// <inheritdoc/>
    [JsonPropertyName("summonerName")]
    public string SummonerName { get; init; } = default!;

    /// <inheritdoc/>
    [JsonPropertyName("queueType")]
    public TftQueue QueueType { get; init; }

    /// <inheritdoc/>
    [JsonPropertyName("ratedTier")]
    public RatedTier? RatedTier { get; init; }

    /// <inheritdoc/>
    [JsonPropertyName("ratedRating")]
    public int? RatedRating { get; init; }

    /// <inheritdoc/>
    [JsonPropertyName("tier")]
    public Tier? Tier { get; init; }

    /// <inheritdoc/>
    [JsonPropertyName("rank")]
    public Division? Rank { get; init; }

    /// <inheritdoc/>
    [JsonPropertyName("leaguePoints")]
    public int? LeaguePoints { get; init; }

    /// <inheritdoc/>
    [JsonPropertyName("wins")]
    public int Wins { get; init; }

    /// <inheritdoc/>
    [JsonPropertyName("losses")]
    public int Losses { get; init; }

    /// <inheritdoc/>
    [JsonPropertyName("hotStreak")]
    public bool? HotStreak { get; init; }

    /// <inheritdoc/>
    [JsonPropertyName("veteran")]
    public bool? IsVeteran { get; init; }

    /// <inheritdoc/>
    [JsonPropertyName("freshBlood")]
    public bool? IsFreshBlood { get; init; }

    /// <inheritdoc/>
    [JsonPropertyName("inactive")]
    public bool? IsInactive { get; init; }

    /// <inheritdoc/>
    [JsonPropertyName("miniSeries")]
    public MiniSeries? MiniSeries { get; init; }
}
