using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LorRankedV1;

public class LeaderboardDto : BaseDto
{
    /// <summary>
    /// A list of players in Master tier.
    /// </summary>
    [JsonPropertyName("players")]
    public PlayerDto[] Players { get; set; } = [];
}
