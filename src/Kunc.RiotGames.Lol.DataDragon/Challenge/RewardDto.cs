using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon.Challenge;

public class RewardDto : BaseDto
{
    [JsonPropertyName("category")]
    public string Category { get; set; } = string.Empty;

    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;
}
