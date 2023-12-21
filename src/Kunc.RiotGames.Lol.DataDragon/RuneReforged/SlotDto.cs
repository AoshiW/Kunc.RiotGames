using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon.RuneReforged;

public class SlotDto : BaseDto
{
    [JsonPropertyName("runes")]
    public RuneDto[] Runes { get; set; } = [];
}
