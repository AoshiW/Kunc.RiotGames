using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api.Spectator;

public record BannedChampion : BaseDto
{
    /// <summary>
    /// The turn during which the champion was banned.
    /// </summary>
    [JsonPropertyName("pickTurn")]
    public int PickTurn { get; init; }

    /// <summary>
    /// The ID of the banned champion.
    /// </summary>
    [JsonPropertyName("championId")]
    public long ChampionId { get; init; }

    /// <summary>
    /// The ID of the team that banned the champion.
    /// </summary>
    [JsonPropertyName("teamId")]
    public long TeamId { get; init; }
}