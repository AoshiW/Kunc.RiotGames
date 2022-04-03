using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lor.Api.Match;

public record Info
{
    [JsonPropertyName("game_mode")]
    public GameMode GameMode { get; init; }

    // todo
    [JsonPropertyName("game_type")]
    public string GameType { get; init; } = default!;

    [JsonPropertyName("game_start_time_utc")]
    public DateTimeOffset GameStartTimeUtc { get; init; }

    [JsonPropertyName("game_version")]
    public string GameVersion { get; init; } = default!;

    public Player[] Players { get; init; } = default!;

    /// <summary>
    /// Total turns taken by both players.
    /// </summary>
    [JsonPropertyName("total_turn_count")]
    public int TotalTurnCount { get; init; }
}
