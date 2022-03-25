using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api.Match;

public record Team : BaseDto
{
    [JsonPropertyName("bans")]
    public Ban[] Bans { get; init; } = default!;

    [JsonPropertyName("objectives")]
    public Objectives Objectives { get; init; } = default!;

    [JsonPropertyName("teamId")]
    public int TeamId { get; init; }

    [JsonPropertyName("win")]
    public bool Win { get; init; }
}
