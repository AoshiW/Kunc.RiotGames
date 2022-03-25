using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lor.Api.Match;

public record Player
{
    public string Puuid { get; init; } = default!;

    [JsonPropertyName("deck_id")]
    public string DeckId { get; init; } = default!;

    /// <summary>
    /// Code for the deck played.
    /// </summary>
    [JsonPropertyName("deck_code")]
    public string DeckCode { get; init; } = default!;

    public string[] Factions { get; init; } = default!;

    [JsonPropertyName("game_outcome")]
    public GameOutcome GameOutcome { get; init; }

    /// <summary>
    /// The order in which the players took turns.
    /// </summary>
    [JsonPropertyName("order_of_play")]
    public int OrderOfPlay { get; init; }
}
