﻿using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LorMatchV1;

public class InfoDto : BaseDto
{
    //todo enum
    [JsonPropertyName("game_mode")]
    public string GameMode { get; set; }

    //todo enum
    [JsonPropertyName("game_type")]
    public string GameType { get; set; }

    [JsonPropertyName("game_start_time_utc")]
    public DateTimeOffset GameStartTime { get; set; }

    [JsonPropertyName("game_version")]
    public string GameVersion { get; set; }

    [JsonPropertyName("players")]
    public PlayerDto[] Players { get; set; } = [];

    [JsonPropertyName("total_turn_count")]
    public int TotalTurnCount { get; set; }
}