﻿using System.Text.Json.Serialization;
using Kunc.RiotGames;

public class PlayerItemDto : BaseDto
{
    [JsonPropertyName("canUse")]
    public bool CanUse { get; set; }

    [JsonPropertyName("consumable")]
    public bool IsConsumable { get; set; }

    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("displayName")]
    public string DisplayName { get; set; } = string.Empty;

    [JsonPropertyName("itemID")]
    public int ItemId { get; set; }

    [JsonPropertyName("price")]
    public int Price { get; set; }

    [JsonPropertyName("rawDescription")]
    public string RawDescription { get; set; } = string.Empty;

    [JsonPropertyName("rawDisplayName")]
    public string RawDisplayName { get; set; } = string.Empty;

    [JsonPropertyName("slot")]
    public int Slot { get; set; }
}
