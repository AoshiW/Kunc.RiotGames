using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

public class ActivePlayerDto : BaseDto
{
    [JsonPropertyName("abilities")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public AbilitiesDto Abilities { get; set; } = new();

    [JsonPropertyName("championStats")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public ChampionStatsDto ChampionStats { get; set; } = new();

    [JsonPropertyName("currentGold")]
    public double CurrentGold { get; set; }

    [JsonPropertyName("fullRunes")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public FullRunesDto FullRunes { get; set; } = new();

    [JsonPropertyName("level")]
    public int Level { get; set; }

    [JsonPropertyName("riotId")]
    public RiotId RiotId { get; set; } = default!;

    [JsonPropertyName("riotIdGameName")]
    public string RiotIdGameName { get; set; } = string.Empty;

    [JsonPropertyName("riotIdTagLine")]
    public string RiotIdTagLine { get; set; } = string.Empty;

    [JsonPropertyName("summonerName")]
    public string SummonerName { get; set; } = string.Empty;

    [JsonPropertyName("teamRelativeColors")]
    public bool TeamRelativeColors { get; set; }
}
