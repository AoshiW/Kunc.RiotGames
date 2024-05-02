using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

public class FullRunesDto : MainRunesDto
{
    [JsonPropertyName("generalRunes")]
    public RuneDto[] GeneralRunes { get; set; } = [];

    [JsonPropertyName("statRunes")]
    public StatRuneDto[] StatRunes { get; set; } = [];
}
