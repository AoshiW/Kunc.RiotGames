using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolChampionV3;

public class ChampionInfoDto : BaseDto
{
    /// <summary>
    /// A list of champion IDs available to players under summoner level 11.
    /// </summary>
    [JsonPropertyName("newplayer")]
    public int[] NewPlayer { get; set; } = [];

    /// <summary>
    /// A list of champion IDs available to all players on Summoner's Rift.
    /// </summary>
    [JsonPropertyName("sr")]
    public int[] SummonersRift { get; set; } = [];
}
