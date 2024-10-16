﻿using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LorMatchV1;

public class InfoDto : BaseDto
{
    //todo enum? Constructed ThePathOfChampions Tutorial
    [JsonPropertyName("game_mode")]
    public string GameMode { get; set; } = string.Empty;

    [JsonPropertyName("game_type")]
    public GameType GameType { get; set; }

    [JsonPropertyName("game_start_time_utc")]
    public DateTimeOffset GameStartTime { get; set; }

    [JsonPropertyName("game_version")]
    public string GameVersion { get; set; } = string.Empty;

    [JsonPropertyName("game_format")]
    public GameFormat GameFormat { get; set; }

    [JsonPropertyName("players")]
    public PlayerDto[] Players { get; set; } = [];

    [JsonPropertyName("total_turn_count")]
    public int TotalTurnCount { get; set; }
}
