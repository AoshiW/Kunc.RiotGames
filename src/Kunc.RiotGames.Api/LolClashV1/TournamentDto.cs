using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolClashV1;

public class TournamentDto : BaseDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("themeId")]
    public int ThemeId { get; set; }

    [JsonPropertyName("nameKey")]
    public string NameKey { get; set; } = string.Empty;

    [JsonPropertyName("nameKeySecondary")]
    public string NameKeySecondary { get; set; } = string.Empty;

    [JsonPropertyName("schedule")]
    public TournamentPhaseDto[] Schedule { get; set; } = [];
}
