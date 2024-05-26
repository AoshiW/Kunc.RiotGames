using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

public class PlayerDto : BaseDto
{
    [JsonPropertyName("championName")]
    public string ChampionName { get; set; } = string.Empty;

    [MemberNotNullWhen(true, nameof(Runes))]
    [JsonPropertyName("isBot")]
    public bool IsBot { get; set; }

    [JsonPropertyName("isDead")]
    public bool IsDead { get; set; }

    [JsonPropertyName("items")]
    public PlayerItemDto[] Items { get; set; } = [];

    [JsonPropertyName("level")]
    public int Level { get; set; }

    [JsonPropertyName("position")]
    public string Position { get; set; } // todo enum

    [JsonPropertyName("rawChampionName")]
    public string RawChampionName { get; set; } = string.Empty;

    [JsonPropertyName("rawSkinName")]
    public string RawSkinName { get; set; } = string.Empty;

    [JsonPropertyName("respawnTimer")]
    [JsonConverter(typeof(JsonTimeSpanSecondsConverter))]
    public TimeSpan RespawnTimer { get; set; }

    [JsonPropertyName("riotId")]
    public RiotId RiotId { get; set; } = default!;

    [JsonPropertyName("riotIdGameName")]
    public string RiotIdGameName { get; set; } = string.Empty;

    [JsonPropertyName("riotIdTagLine")]
    public string RiotIdTagLine { get; set; } = string.Empty;

    [JsonPropertyName("runes")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public MainRunesDto? Runes { get; set; } = new();

    [JsonPropertyName("scores")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public PlayerScoresDto Scores { get; set; } = new();

    [JsonPropertyName("skinID")]
    public int SkinID { get; set; }

    [JsonPropertyName("skinName")]
    public string SkinName { get; set; } = string.Empty;

    [JsonPropertyName("summonerName")]
    public string SummonerName { get; set; } = string.Empty;

    [JsonPropertyName("summonerSpells")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public SummonerSpellsDto SummonerSpells { get; set; } = new();

    [JsonPropertyName("team")]
    public TeamId Team { get; set; }
}
