using System.Drawing;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api.Match;

//todo replace => Point
public record MapPoint : BaseDto
{
    [JsonPropertyName("x")]
    public int X { get; init; }

    [JsonPropertyName("y")]
    public int Y { get; init; }
}