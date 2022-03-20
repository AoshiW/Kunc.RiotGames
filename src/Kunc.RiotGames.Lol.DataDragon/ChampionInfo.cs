using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon;

public record ChampionInfo : BaseDto
{
    [JsonPropertyName("attack")]
    public int Attack { get; init; }

    [JsonPropertyName("defense")]
    public int Defense { get; init; }

    [JsonPropertyName("magic")]
    public int Magic { get; init; }

    [JsonPropertyName("difficulty")]
    public int Difficulty { get; init; }
}
