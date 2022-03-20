using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon;

public record Skin : BaseDto
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = default!;

    [JsonPropertyName("num")]
    public int Num { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = default!;

    [JsonPropertyName("chromas")]
    public bool Chromas { get; set; }
}
