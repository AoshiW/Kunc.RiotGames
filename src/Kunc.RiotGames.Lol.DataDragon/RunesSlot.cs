using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon;

public record RunesSlot : BaseDto
{
    [JsonPropertyName("runes")]
    public Rune[] Runes { get; set; } = default!;
}
