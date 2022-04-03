using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lor.Api.Match;

/// <summary>
/// Result of game.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum GameOutcome
{
    /// <summary>
    /// Loss.
    /// </summary>
    Loss,

    /// <summary>
    /// Draw.
    /// </summary>
    Tie,

    /// <summary>
    /// Win.
    /// </summary>
    Win
}
