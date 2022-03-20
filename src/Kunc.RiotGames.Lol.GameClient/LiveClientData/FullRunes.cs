using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

public record FullRunes : Runes
{
    [JsonPropertyName("generalRunes")]
    public Generalrune[] GeneralRunes { get; init; } = default!;

    [JsonPropertyName("statRunes")]
    public StatRune[] StatRunes { get; init; } = default!;
}
