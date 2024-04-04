using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Api.LorRankedV1;

public class PlayerDto : BaseDto
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("rank")]
    public int Rank { get; set; }

    /// <summary>
    /// League points.
    /// </summary>
    [JsonPropertyName("lp")]
    [JsonConverter(typeof(Int32Converter))]
    public int LP { get; set; }
}
