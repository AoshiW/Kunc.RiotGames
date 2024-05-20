using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Api.LolChampionMasteryV4;

/// <summary>
/// This object contains single Champion Mastery information for player and champion combination.
/// </summary>
public class ChampionMasteryDto : BaseDto
{
    /// <summary>
    /// Player Universal Unique Identifier. Exact length of 78 characters. (Encrypted)
    /// </summary>
    [JsonPropertyName("puuid")]
    public string Puuid { get; set; } = string.Empty;

    /// <summary>
    /// Number of points needed to achieve next level. Zero if player reached maximum champion level for this champion.
    /// </summary>
    [JsonPropertyName("championPointsUntilNextLevel")]
    public long ChampionPointsUntilNextLevel { get; set; }

    /// <summary>
    /// Is chest granted for this champion or not in current season.
    /// </summary>
    [JsonPropertyName("chestGranted")]
    public bool IsChestGranted { get; set; }

    /// <summary>
    /// Champion ID for this entry.
    /// </summary>
    [JsonPropertyName("championId")]
    public int ChampionId { get; set; }

    /// <summary>
    /// Last time this champion was played by this player.
    /// </summary>
    [JsonPropertyName("lastPlayTime")]
    [JsonConverter(typeof(UnixTimestampDateTimeOffsetMsConverter))]
    public DateTimeOffset LastPlayTime { get; set; }

    /// <summary>
    /// Champion level for specified player and champion combination.
    /// </summary>
    [JsonPropertyName("championLevel")]
    public int ChampionLevel { get; set; }

    /// <summary>
    /// Total number of champion points for this player and champion combination - they are used to determine championLevel.
    /// </summary>
    [JsonPropertyName("championPoints")]
    public int ChampionPoints { get; set; }

    /// <summary>
    /// Number of points earned since current level has been achieved.
    /// </summary>
    [JsonPropertyName("championPointsSinceLastLevel")]
    public long ChampionPointsSinceLastLevel { get; set; }

    /// <summary>
    /// The token earned for this champion at the current championLevel. When the championLevel is advanced the tokensEarned resets to 0.
    /// </summary>
    [JsonPropertyName("tokensEarned")]
    public int TokensEarned { get; set; }
}
