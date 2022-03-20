using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

public record Passive : BaseDto
{
    [JsonPropertyName("displayName")]
    public string DisplayName { get; init; } = default!;

    [JsonPropertyName("id")]
    public string Id { get; init; } = default!;

    [JsonPropertyName("rawDescription")]
    public string RawDescription { get; init; } = default!;

    [JsonPropertyName("rawDisplayName")]
    public string RawDisplayName { get; init; } = default!;
}
