using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Api.LolSummonerV4;

public class SummonerDto : BaseDto
{
    /// <summary>
    /// ID of the summoner icon associated with the summoner.
    /// </summary>
    [JsonPropertyName("profileIconId")]
    public int ProfileIconId { get; set; }

    /// <summary>
    /// Date summoner was last modified.
    /// </summary>
    /// <remarks>
    /// The following events will update this date: summoner name change, summoner level change, or profile icon change.</remarks>
    [JsonPropertyName("revisionDate")]
    [JsonConverter(typeof(UnixTimestampDateTimeOffsetMsConverter))]
    public DateTimeOffset RevisionDate { get; set; }

    /// <summary>
    /// Player Universal Unique Identifier.
    /// </summary>
    [JsonPropertyName("puuid")]
    public string Puuid { get; set; } = string.Empty;

    /// <summary>
    /// Summoner level associated with the summoner.
    /// </summary>
    [JsonPropertyName("summonerLevel")]
    public long Level { get; set; }
}
