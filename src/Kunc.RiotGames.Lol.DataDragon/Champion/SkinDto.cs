using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon.Champion;

public class SkinDto : BaseDto
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("num")]
    public int Num { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("chromas")]
    public bool HasChromas { get; set; }
}
