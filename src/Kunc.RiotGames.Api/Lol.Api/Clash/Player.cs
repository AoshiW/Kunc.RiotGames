using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api.Clash;
public record Player : BaseDto
{
    [JsonPropertyName("teamId")]
    public string? TeamId { get; init; } = default!;
}
