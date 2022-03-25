using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Shared.Api.Status;

public record PlatformData : BaseDto
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = default!;

    [JsonPropertyName("name")]
    public string Name { get; init; } = default!;

    [JsonPropertyName("locales")]
    public string[] Locales { get; init; } = default!;

    [JsonPropertyName("maintenances")]
    public Status[] Maintenances { get; init; } = default!;

    [JsonPropertyName("incidents")]
    public Status[] Incidents { get; init; } = default!;
}
