using System.Text.Json.Serialization;

using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Tft.Api.Match;

public record Participant : BaseDto
{
    /// <summary>
    /// Participant's companion.
    /// </summary>
    [JsonPropertyName("companion")]
    public Companion Companion { get; init; } = default!;

    /// <summary>
    /// Gold left after participant was eliminated.
    /// </summary>
    [JsonPropertyName("gold_left")]
    public int GoldLeft { get; init; }

    /// <summary>
    /// The round the participant was eliminated in.
    /// Note: If the player was eliminated in stage 2-1 their last_round would be 5.
    /// </summary>
    [JsonPropertyName("last_round")]
    public int LastRound { get; init; }

    /// <summary>
    /// Participant Little Legend level.
    /// </summary>
    [JsonPropertyName("level")]
    public int Level { get; init; }

    /// <summary>
    /// Participant placement upon elimination.
    /// </summary>
    [JsonPropertyName("placement")]
    public int Placement { get; init; }

    /// <summary>
    /// Number of players the participant eliminated.
    /// </summary>
    [JsonPropertyName("players_eliminated")]
    public int PlayersEliminated { get; init; }

    [JsonPropertyName("puuid")]
    public string Puuid { get; init; } = default!;

    /// <summary>
    /// The number of seconds before the participant was eliminated.
    /// </summary>
    [JsonPropertyName("time_eliminated"), JsonTimeSpanConverter(BaseTimeUnit.Seconds)]
    public TimeSpan TimeEliminated { get; init; }

    /// <summary>
    /// Damage the participant dealt to other players.
    /// </summary>
    [JsonPropertyName("total_damage_to_players")]
    public int TotalDamageToPlayers { get; init; }

    /// <summary>
    /// A complete list of traits for the participant's active units.
    /// </summary>
    [JsonPropertyName("traits")]
    public Trait[] Traits { get; init; } = default!;

    /// <summary>
    /// A list of active units for the participant.
    /// </summary>
    [JsonPropertyName("units")]
    public Unit[] Units { get; init; } = default!;
}
