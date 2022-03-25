using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api.Spectator;

public record Participant : BaseDto
{
    /// <summary>
    /// Flag indicating whether or not this participant is a bot.
    /// </summary>
    [JsonPropertyName("bot")]
    public bool IsBot { get; init; }

    /// <summary>
    /// The ID of the second summoner spell used by this participant.
    /// </summary>
    [JsonPropertyName("spell2Id")]
    public long Spell2Id { get; init; }

    /// <summary>
    /// The ID of the profile icon used by this participant.
    /// </summary>
    [JsonPropertyName("profileIconId")]
    public long ProfileIconId { get; init; }

    /// <summary>
    /// The summoner name of this participant.
    /// </summary>
    [JsonPropertyName("summonerName")]
    public string SummonerName { get; init; } = default!;

    /// <summary>
    /// The ID of the champion played by this participant.
    /// </summary>
    [JsonPropertyName("championId")]
    public long ChampionId { get; init; }

    /// <summary>
    /// The team ID of this participant, indicating the participant's team.
    /// </summary>
    [JsonPropertyName("teamId")]
    public long TeamId { get; init; }

    /// <summary>
    /// The ID of the first summoner spell used by this participant.
    /// </summary>
    [JsonPropertyName("spell1Id")]
    public long Spell1Id { get; init; }
}
