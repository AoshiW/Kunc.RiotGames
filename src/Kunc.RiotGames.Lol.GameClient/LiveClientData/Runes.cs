using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

public record Runes : BaseDto
{
    [JsonPropertyName("keystone")]
    public Keystone Keystone { get; init; } = default!;

    [JsonPropertyName("primaryRuneTree")]
    public RuneTree PrimaryRuneTree { get; init; } = default!;

    [JsonPropertyName("secondaryRuneTree")]
    public RuneTree SecondaryRuneTree { get; init; } = default!;
}
