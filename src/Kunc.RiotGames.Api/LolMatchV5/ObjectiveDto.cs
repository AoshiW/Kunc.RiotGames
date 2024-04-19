using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolMatchV5;

public class ObjectiveDto : BaseDto
{
    [JsonPropertyName("first")]
    public bool First { get; set; }

    [JsonPropertyName("kills")]
    public int Kills { get; set; }
}
