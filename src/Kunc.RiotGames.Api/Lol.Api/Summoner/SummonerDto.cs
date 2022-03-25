using System.Text.Json.Serialization;

using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Lol.Api.Summoner;

/// <summary>
/// Represents a summoner.
/// </summary>
public record SummonerDto : BaseDto
{
    /// <summary>
    /// Encrypted account ID.
    /// </summary>
    [JsonPropertyName("accountId")]
    public string AccountId { get; init; } = default!;

    /// <summary>
    /// ID of the summoner icon associated with the summoner.
    /// </summary>
    [JsonPropertyName("profileIconId")]
    public int ProfileIconId { get; init; }

    /// <summary>
    /// Date summoner was last modified. The following events will update this date:
    /// profile icon change, playing the tutorial or advanced tutorial, finishing a game, summoner name change
    /// </summary>
    [JsonPropertyName("revisionDate"), JsonConverter(typeof(UnixTimestampDateTimeOffsetMsConverter))]
    public DateTimeOffset RevisionDate { get; init; }

    /// <summary>
    /// Summoner name.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; init; } = default!;

    /// <summary>
    /// Encrypted summoner ID.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; init; } = default!;

    /// <summary>
    /// Encrypted PUUID.
    /// </summary>
    [JsonPropertyName("puuid")]
    public string Puuid { get; init; } = default!;

    /// <summary>
    /// Summoner level associated with the summoner.
    /// </summary>
    [JsonPropertyName("summonerLevel")]
    public long SummonerLevel { get; init; }

    public Platform Platform { get => _platform; init => _platform = value; }
#pragma warning disable IDE0032 // Use auto property
    private Platform _platform;
#pragma warning restore IDE0032 // Use auto property

    internal void SetPlatform(Platform value) => _platform = value;
}
