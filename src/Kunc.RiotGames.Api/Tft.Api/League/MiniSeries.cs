using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Tft.Api.League;

public record MiniSeries : BaseDto
{
    [JsonPropertyName("losses")]
    public int Losses { get; init; }

    [JsonPropertyName("progress")]
    public int Progress { get; init; } = default!;

    [JsonPropertyName("target")]
    public int Target { get; init; }

    [JsonPropertyName("wins")]
    public int Wins { get; init; }
}
