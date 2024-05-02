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

    [JsonPropertyName("summonerName")]
    public RiotId SummonerName { get; set; } = default!;

    [JsonPropertyName("teamRelativeColors")]
    public bool TeamRelativeColors { get; set; }
}
