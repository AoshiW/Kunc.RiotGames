using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Tft.Api.League;

public record LeagueList : BaseDto
{
    [JsonPropertyName("leagueId")]
    public string LeagueId { get; init; } = default!;

    [JsonPropertyName("entries")]
    public LeagueItem[] Entries { get; init; } = default!;

    [JsonPropertyName("tier")]
    public int Tier { get; init; } = default!;

    [JsonPropertyName("name")]
    public string Name { get; init; } = default!;

    [JsonPropertyName("queue")]
    public int Queue { get; init; } = default!;
}
