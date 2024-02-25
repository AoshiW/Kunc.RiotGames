using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Api.LolMatchV5;

public class MatchParticipantFrameDto : BaseDto
{
    [JsonPropertyName("championStats")]
    public ChampionStatsDto ChampionStats { get; set; }

    [JsonPropertyName("currentGold")]
    public int CurrentGold { get; set; }

    [JsonPropertyName("damageStats")]
    public DamageStatsDto DamageStats { get; set; }

    [JsonPropertyName("goldPerSecond")]
    public int GoldPerSecond { get; set; }

    [JsonPropertyName("jungleMinionsKilled")]
    public int JungleMinionsKilled { get; set; }

    [JsonPropertyName("level")]
    public int Level { get; set; }

    [JsonPropertyName("minionsKilled")]
    public int MinionsKilled { get; set; }

    [JsonPropertyName("participantId")]
    public int ParticipantId { get; set; }

    [JsonPropertyName("position")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public MatchPosition Position { get; set; } = new();

    [JsonPropertyName("timeEnemySpentControlled")]
    [JsonConverter(typeof(JsonTimeSpanMillisecondsConverter))]
    public TimeSpan TimeEnemySpentControlled { get; set; }

    [JsonPropertyName("totalGold")]
    public int TotalGold { get; set; }

    [JsonPropertyName("xp")]
    public int XP { get; set; }
}
