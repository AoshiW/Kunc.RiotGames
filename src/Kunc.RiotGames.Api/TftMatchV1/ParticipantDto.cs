using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Api.TftMatchV1;

public class ParticipantDto : BaseDto
{
    /// <summary>
    /// Participant's companion.
    /// </summary>
    [JsonPropertyName("companion")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public CompanionDto Companion { get; set; } = new();

    /// <summary>
    /// Gold left after participant was eliminated.
    /// </summary>
    [JsonPropertyName("gold_left")]
    public int GoldLeft { get; set; }

    /// <summary>
    /// The round the participant was eliminated in.
    /// </summary>
    /// <remarks>
    /// If the player was eliminated in stage 2-1 their <see cref="LastRound"/> would be 5.
    /// </remarks>
    [JsonPropertyName("last_round")]
    public int LastRound { get; set; }

    /// <summary>
    /// Participant Little Legend level.
    /// </summary>
    /// <remarks>
    /// This is not the number of active units.
    /// </remarks>
    [JsonPropertyName("level")]
    public int Level { get; set; }

    /// <summary>
    /// Participant placement upon elimination.
    /// </summary>
    [JsonPropertyName("placement")]
    public int Placement { get; set; }

    /// <summary>
    /// Number of players the participant eliminated.
    /// </summary>
    [JsonPropertyName("players_eliminated")]
    public int PlayersEliminated { get; set; }

    [JsonPropertyName("puuid")]
    public string Puuid { get; set; } = string.Empty;

    /// <summary>
    /// Time before the participant was eliminated.
    /// </summary>
    [JsonPropertyName("time_eliminated")]
    [JsonConverter(typeof(JsonTimeSpanSecondsConverter))]
    public TimeSpan TimeEliminated { get; set; }

    /// <summary>
    /// Damage the participant dealt to other players.
    /// </summary>
    [JsonPropertyName("total_damage_to_players")]
    public int TotalDamageToPlayers { get; set; }

    /// <summary>
    ///  A complete list of traits for the participant's active units.
    /// </summary>
    [JsonPropertyName("traits")]
    public TraitDto[] Traits { get; set; } = [];

    /// <summary>
    /// A list of active units for the participant.
    /// </summary>
    [JsonPropertyName("units")]
    public UnitDto[] Units { get; set; } = [];
}
