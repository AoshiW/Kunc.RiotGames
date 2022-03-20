using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

public record ActivePlayer : BaseDto
{
    [JsonPropertyName("abilities")]
    public Abilities Abilities { get; init; } = default!;

    [JsonPropertyName("championStats")]
    public ChampionStats ChampionStats { get; init; } = default!;

    [JsonPropertyName("currentGold")]
    public float CurrentGold { get; init; }

    [JsonPropertyName("fullRunes")]
    public FullRunes FullRunes { get; init; } = default!;

    /// <summary>
    /// Champion level.
    /// </summary>
    [JsonPropertyName("level")]
    public int Level { get; init; }

    [JsonPropertyName("summonerName")]
    public string SummonerName { get; init; } = default!;

    [JsonPropertyName("teamRelativeColors")]
    public bool TeamRelativeColors { get; init; }
}
