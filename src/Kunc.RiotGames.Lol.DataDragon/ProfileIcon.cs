using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon;

public record ProfileIcon : BaseDto
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("image")]
    public Image Image { get; init; } = default!;
}
