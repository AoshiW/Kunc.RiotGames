﻿using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Api.LolMatchV5;

public class ParticipantFrameDto : BaseDto
{
    [JsonPropertyName("championStats")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public ChampionStatsDto ChampionStats { get; set; } = new();

    [JsonPropertyName("currentGold")]
    public int CurrentGold { get; set; }

    [JsonPropertyName("damageStats")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public DamageStatsDto DamageStats { get; set; } = new();

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
    public PositionDto Position { get; set; } = new();

    [JsonPropertyName("timeEnemySpentControlled")]
    [JsonConverter(typeof(JsonTimeSpanMillisecondsConverter))]
    public TimeSpan TimeEnemySpentControlled { get; set; }

    [JsonPropertyName("totalGold")]
    public int TotalGold { get; set; }

    [JsonPropertyName("xp")]
    public int XP { get; set; }
}
