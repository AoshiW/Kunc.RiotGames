using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

public record Keystone : BaseDto
{
    [JsonPropertyName("displayName")]
    public string DisplayName { get; init; } = default!;

    [JsonPropertyName("Id")]
    public int Id { get; init; }

    [JsonPropertyName("rawDescription")]
    public string RawDescription { get; init; } = default!;

    [JsonPropertyName("rawDisplayName")]
    public string RawDisplayName { get; init; } = default!;
}

public record Generalrune : BaseDto
{
    [JsonPropertyName("displayName")]
    public string DisplayName { get; init; } = default!;

    [JsonPropertyName("Id")]
    public int Id { get; init; }

    [JsonPropertyName("rawDescription")]
    public string RawDescription { get; init; } = default!;

    [JsonPropertyName("rawDisplayName")]
    public string RawDisplayName { get; init; } = default!;
}

public record RuneTree : BaseDto
{
    [JsonPropertyName("displayName")]
    public string DisplayName { get; init; } = default!;

    [JsonPropertyName("Id")]
    public int Id { get; init; }

    [JsonPropertyName("rawDescription")]
    public string RawDescription { get; init; } = default!;

    [JsonPropertyName("rawDisplayName")]
    public string RawDisplayName { get; init; } = default!;
}
