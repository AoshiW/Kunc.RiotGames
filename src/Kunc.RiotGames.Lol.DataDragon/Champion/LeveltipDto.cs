using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon.Champion;

public class LeveltipDto : BaseDto
{
    [JsonPropertyName("label")]
    public string[] Label { get; set; } = [];

    [JsonPropertyName("effect")]
    public string[] Effect { get; set; } = [];
}
