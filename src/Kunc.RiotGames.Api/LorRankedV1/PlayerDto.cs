using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LorRankedV1;

public class PlayerDto : BaseDto
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("rank")]
    public int Rank { get; set; }

    /// <summary>
    /// 	League points.
    /// </summary>
    [JsonPropertyName("lp")]
    public int Lp { get; set; }
}
