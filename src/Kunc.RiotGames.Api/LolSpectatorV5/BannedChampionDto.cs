using System.Text.Json.Serialization;
using Kunc.RiotGames.Lol;

namespace Kunc.RiotGames.Api.LolSpectatorV5;

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
    public TeamId TeamId { get; set; }
}
