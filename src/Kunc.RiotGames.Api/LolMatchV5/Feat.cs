using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolMatchV5;

public class Feat : BaseDto
{
    [JsonPropertyName("featState")]
    public int FeatState { get; set; }
}
