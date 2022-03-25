using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api.Clash;

public record Tournament : BaseDto
{
    [JsonPropertyName("id")]
    public int Id { get; init; } = default!;

    [JsonPropertyName("themeId")]
    public int ThemeId { get; init; } = default!;

    [JsonPropertyName("nameKey")]
    public string NameKey { get; init; } = default!;
    
    [JsonPropertyName("nameKeySecondary")]
    public string NameKeySecondary { get; init; } = default!;

    /// <summary>
    /// Tournament phase.
    /// </summary>
    [JsonPropertyName("schedule")]
    public TournamentPhase[] Schedule { get; init; } = default!;
}
