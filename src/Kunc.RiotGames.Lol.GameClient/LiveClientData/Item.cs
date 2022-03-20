using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

public record Item : BaseDto
{
    [JsonPropertyName("canUse")]
    public bool CanUse { get; init; }

    [JsonPropertyName("consumable")]
    public bool IsConsumable { get; init; }

    [JsonPropertyName("count")]
    public int Count { get; init; }

    [JsonPropertyName("displayName")]
    public string DisplayName { get; init; } = default!;

    [JsonPropertyName("itemID")]
    public int ItemID { get; init; }

    [JsonPropertyName("price")]
    public int Price { get; init; }

    [JsonPropertyName("rawDescription")]
    public string RawDescription { get; init; } = default!;

    [JsonPropertyName("rawDisplayName")]
    public string RawDisplayName { get; init; } = default!;

    [JsonPropertyName("slot")]
    public int Slot { get; init; }
}
