using System.Text.Json.Serialization;
using Kunc.RiotGames.Lol;

namespace Kunc.RiotGames.Api.LolSpectatorV5;

public class ParticipantDto : BaseDto
{
    /// <summary>
    /// Flag indicating whether or not this participant is a bot.
    /// </summary>
    [JsonPropertyName("bot")]
    public bool IsBot { get; set; }

    /// <summary>
    /// The ID of the profile icon used by this participant.
    /// </summary>
    [JsonPropertyName("profileIconId")]
    public long ProfileIconId { get; set; }

    /// <summary>
    /// Encrypted puuid of this participant.
    /// </summary>
    [JsonPropertyName("puuid")]
    public string Puuid { get; set; } = string.Empty;

    /// <summary>
    /// The encrypted summoner ID of this participant.
    /// </summary>
    [JsonPropertyName("summonerId")]
    public string SummonerId { get; set; } = string.Empty;

    /// <summary>
    /// The ID of the champion played by this participant.
    /// </summary>
    [JsonPropertyName("championId")]
    public long ChampionId { get; set; }

    /// <summary>
    /// The team ID of this participant, indicating the participant's team.
    /// </summary>
    [JsonPropertyName("teamId")]
    public TeamId TeamId { get; set; }

    /// <summary>
    /// The ID of the first summoner spell used by this participant.
    /// </summary>
    [JsonPropertyName("spell1Id")]
    public long Spell1Id { get; set; }

    /// <summary>
    /// The ID of the second summoner spell used by this participant.
    /// </summary>
    [JsonPropertyName("spell2Id")]
    public long Spell2Id { get; set; }
}
