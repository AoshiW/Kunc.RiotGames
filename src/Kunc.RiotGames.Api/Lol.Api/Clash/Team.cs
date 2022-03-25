using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api.Clash;

public record Team : BaseDto
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = default!;

    [JsonPropertyName("tournamentId")]
    public int TournamentId { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; } = default!;

    [JsonPropertyName("iconId")]
    public int IconId { get; init; }

    [JsonPropertyName("tier")]
    public int Tier { get; init; }

    /// <summary>
    /// Summoner ID of the team captain.
    /// </summary>
    [JsonPropertyName("captain")]
    public string Captain { get; init; } = default!;

    [JsonPropertyName("abbreviation")]
    public string Abbreviation { get; init; } = default!;

    [JsonPropertyName("players")]
    public PlayerBase[] Players { get; init; } = default!;
}