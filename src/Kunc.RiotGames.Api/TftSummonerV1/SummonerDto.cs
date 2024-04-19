using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Api.TftSummonerV1;

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
    /// Encrypted summoner ID. Max length 63 characters.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Encrypted PUUID.Exact length of 78 characters.
    /// </summary>
    [JsonPropertyName("puuid")]
    public string Puuid { get; set; } = string.Empty;

    /// <summary>
    /// Summoner level associated with the summoner.
    /// </summary>
    [JsonPropertyName("summonerLevel")]
    public long Level { get; set; }
}
