using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolMatchV5;

public class PositionDto : BaseDto
{
    [JsonPropertyName("x")]
    public int X { get; set; }

    [JsonPropertyName("y")]
    public int Y { get; set; }

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"{{X={X},Y={Y}}}";
    }
}
