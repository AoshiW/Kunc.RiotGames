using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api.Match;

public record Objective : BaseDto
{
    [JsonPropertyName("first")]
    public bool First { get; init; }

    [JsonPropertyName("kills")]
    public int Kills { get; init; }
}