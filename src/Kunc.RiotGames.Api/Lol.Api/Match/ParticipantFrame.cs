using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api.Match;

public record ParticipantFrame : BaseDto
{
    [JsonPropertyName("championStats")]
    public ChampionStats ChampionStats { get; init; }

    [JsonPropertyName("currentGold")]
    public int CurrentGold { get; init; }

    [JsonPropertyName("damageStats")]
    public DamageStats DamageStats { get; init; }

    [JsonPropertyName("goldPerSecond")]
    public int GoldPerSecond { get; init; }

    [JsonPropertyName("jungleMinionsKilled")]
    public int JungleMinionsKilled { get; init; }

    [JsonPropertyName("level")]
    public int Level { get; init; }

    [JsonPropertyName("minionsKilled")]
    public int MinionsKilled { get; init; }

    [JsonPropertyName("participantId")]
    public int ParticipantId { get; init; }

    [JsonPropertyName("position")]
    public MapPoint Position { get; init; }

    [JsonPropertyName("timeEnemySpentControlled")]
    public int TimeEnemySpentControlled { get; init; }

    [JsonPropertyName("totalGold")]
    public int TotalGold { get; init; }

    [JsonPropertyName("xp")]
    public int Xp { get; init; }
}
