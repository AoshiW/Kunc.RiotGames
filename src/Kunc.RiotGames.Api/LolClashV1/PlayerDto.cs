using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolClashV1;

public class PlayerDto : BaseDto
{
    [JsonPropertyName("puuid")]
    public string Puuid { get; set; } = string.Empty;

    [JsonPropertyName("teamId")]
    public string? TeamId { get; set; }

    [JsonPropertyName("position")]
    public Position Position { get; set; }

    [JsonPropertyName("role")]
    public Role Role { get; set; }
}
