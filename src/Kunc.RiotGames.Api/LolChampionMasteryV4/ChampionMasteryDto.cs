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
    /// The marks earned for this champion.
    /// </summary>
    [JsonPropertyName("tokensEarned")]
    public int MarksEarned { get; set; }

    [JsonPropertyName("markRequiredForNextLevel")]
    public int MarkRequiredForNextLevel { get; set; }

    [JsonPropertyName("championSeasonMilestone")]
    public int ChampionSeasonMilestone { get; set; }

    // if NextSeasonMilestone.IsBonus is false the default value is null,
    // if NextSeasonMilestone.IsBonus is true the default value is an empty array
    // for better consistency the type will not be nullable and the default value will be an empty array
    [JsonPropertyName("milestoneGrades")]
    public string[] MilestoneGrades { get; set; } = [];

    [JsonPropertyName("nextSeasonMilestone")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public SeasonMilestoneDto NextSeasonMilestone { get; set; } = new();
}
