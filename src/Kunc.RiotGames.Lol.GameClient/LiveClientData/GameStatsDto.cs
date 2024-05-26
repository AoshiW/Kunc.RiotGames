using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

public class GameStatsDto : BaseDto
{
    [JsonPropertyName("gameMode")]
    public GameMode GameMode { get; set; }

    [JsonPropertyName("gameTime")]
    [JsonConverter(typeof(JsonTimeSpanSecondsConverter))]
    public TimeSpan GameTime { get; set; }

    [JsonPropertyName("mapName")]
    public string MapName { get; set; } = string.Empty;

    [JsonPropertyName("mapNumber")]
    public int MapNumber { get; set; }

    [JsonPropertyName("mapTerrain")]
    public MapTerrain Terrain { get; set; }
}
