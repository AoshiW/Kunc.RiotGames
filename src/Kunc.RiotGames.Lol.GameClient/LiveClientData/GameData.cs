using Kunc.RiotGames.JsonConverters;

using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

public record GameData : BaseDto
{
    [JsonPropertyName("gameMode")]
    public GameMode GameMode { get; init; }

    [JsonPropertyName("gameTime"), JsonTimeSpanConverter(BaseTimeUnit.Seconds)]
    public TimeSpan GameTime { get; init; }

    [JsonPropertyName("mapName")]
    public string MapName { get; init; } = default!;

    [JsonPropertyName("mapNumber")]
    public MapId Map{ get; init; }

    [JsonPropertyName("mapTerrain")]
    public MapTerrain MapTerrain { get; init; }
}
