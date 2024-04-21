using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LorMatchV1;

public class PlayerDto : BaseDto
{
    /// <summary>
    /// Player Universal Unique Identifier.
    /// </summary>
    [JsonPropertyName("puuid")]
    public string Puuid { get; set; } = string.Empty;

    //todo to guid?
    [JsonPropertyName("deck_id")]
    public string DeckId { get; set; } = string.Empty;

    [JsonPropertyName("deck_code")]
    public string DeckCode { get; set; } = string.Empty;

    [JsonPropertyName("factions")]
    public string[] Factions { get; set; } = [];

    [JsonPropertyName("game_outcome")]
    public GameOutcome GameOutcome { get; set; }

    [JsonPropertyName("order_of_play")]
    public int OrderOfPlay { get; set; }
}
