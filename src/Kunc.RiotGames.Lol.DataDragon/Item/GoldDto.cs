using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon.Item;

public class GoldDto : BaseDto
{
    [JsonPropertyName("base")]
    public int Base { get; set; }

    [JsonPropertyName("purchasable")]
    public bool IsPurchasable { get; set; }

    [JsonPropertyName("total")]
    public int Total { get; set; }

    [JsonPropertyName("sell")]
    public int Sell { get; set; }
}
