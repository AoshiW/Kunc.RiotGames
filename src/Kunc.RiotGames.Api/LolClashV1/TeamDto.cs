using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolClashV1;

public class TeamDto : BaseDto
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("tournamentId")]
    public int TournamentId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("iconId")]
    public int IconId { get; set; }

    [JsonPropertyName("tier")]
    public int Tier { get; set; }

    [JsonPropertyName("captain")]
    public string Captain { get; set; } = string.Empty;

    [JsonPropertyName("abbreviation")]
    public string Abbreviation { get; set; } = string.Empty;

    [JsonPropertyName("players")]
    public PlayerDto[] Players { get; set; } = [];
}
