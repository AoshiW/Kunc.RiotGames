using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api.Match;

public record Objectives : BaseDto
{
    [JsonPropertyName("baron")]
    public Objective Baron { get; init; } = default;

    [JsonPropertyName("champion")]
    public Objective Champion { get; init; } = default;

    [JsonPropertyName("dragon")]
    public Objective Dragon { get; init; } = default;

    [JsonPropertyName("inhibitor")]
    public Objective Inhibitor { get; init; } = default;

    [JsonPropertyName("riftHerald")]
    public Objective RiftHerald { get; init; } = default;

    [JsonPropertyName("tower")]
    public Objective Tower { get; init; } = default;
}
