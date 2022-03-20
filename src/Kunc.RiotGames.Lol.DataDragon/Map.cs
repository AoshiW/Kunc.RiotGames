using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon;

public record Map : BaseDto
{
    public string MapName { get; init; } = default!;

    public string MapId { get; init; } = default!;

    [JsonPropertyName("image")]
    public Image Image { get; init; } = default!;
}
