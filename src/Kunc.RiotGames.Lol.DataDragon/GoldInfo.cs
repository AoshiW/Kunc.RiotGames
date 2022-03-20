using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon;

public record GoldInfo : BaseDto
{
    [JsonPropertyName("base")]
    public int Base { get; init; }

    [JsonPropertyName("purchasable")]
    public bool IsPurchasable { get; init; }

    [JsonPropertyName("total")]
    public int Total { get; init; }

    [JsonPropertyName("sell")]
    public int Sell { get; init; }
}
