using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolSpectatorV4;

public class BannedChampionDto : BaseDto
{
    /// <summary>
    /// The turn during which the champion was banned.
    /// </summary>
    [JsonPropertyName("pickTurn")]
    public int PickTurn { get; set; }

    /// <summary>
    /// The ID of the banned champion.
    /// </summary>
    [JsonPropertyName("championId")]
    public long ChampionId { get; set; }

    /// <summary>
    /// The ID of the team that banned the champion.
    /// </summary>
    [JsonPropertyName("teamId")]
    public long TeamId { get; set; }
}
