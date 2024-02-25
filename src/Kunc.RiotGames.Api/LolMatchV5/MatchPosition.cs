using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolMatchV5;

public class MatchPosition : BaseDto
{
    [JsonPropertyName("x")]
    public int X { get; set; }

    [JsonPropertyName("y")]
    public int Y { get; set; }
}
