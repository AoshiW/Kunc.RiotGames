using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolMatchV5;

public class ReplayDto : BaseDto
{
    /// <summary>
    /// Total of replay files
    /// </summary>
    [JsonPropertyName("total")]
    public int Total { get; set; }

    /// <summary>
    /// Replay files URL (.rofl)
    /// </summary>
    [JsonPropertyName("matchFileURLs")]
    public string[] MatchFileURLs { get; set; } = null!;
}
