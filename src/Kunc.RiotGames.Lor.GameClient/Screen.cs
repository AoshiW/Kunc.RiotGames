﻿using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lor.GameClient;

/// <summary>
/// Game screen resolution
/// </summary>
public class Screen : BaseDto
{
    /// <summary>
    /// Screen width
    /// </summary>
    [JsonPropertyName("ScreenWidth")]
    public int Width { get; set; }

    /// <summary>
    /// Screen height
    /// </summary>
    [JsonPropertyName("ScreenHeight")]
    public int Height { get; set; }
}
