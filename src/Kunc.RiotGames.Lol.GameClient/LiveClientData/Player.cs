using System.Text.Json.Serialization;

using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

public record Player : BaseDto
{
    [JsonPropertyName("rawSkinName")]
    public string RawSkinName { get; init; } = default!; // todo nullabe?

    [JsonPropertyName("skinName")]
    public string SkinName { get; init; } = default!; // todo nullabe?

    [JsonPropertyName("championName")]
    public string ChampionName { get; init; } = default!;

    /// <summary>
    /// Gets a value indicating whether the player is bot.
    /// </summary>
    [JsonPropertyName("isBot")]
    public bool IsBot { get; init; }

    /// <summary>
    /// Gets a value indicating whether the champion is death.
    /// </summary>
    [JsonPropertyName("isDead")]
    public bool IsDead { get; init; }

    [JsonPropertyName("items")]
    public Item[] Items { get; init; } = default!;

    /// <summary>
    /// Champion level. 
    /// </summary>
    [JsonPropertyName("level")]
    public int Level { get; init; }

    // todo enum position
    [JsonPropertyName("position")]
    public string Position { get; init; } = default!;

    [JsonPropertyName("rawChampionName")]
    public string RawChampionName { get; init; } = default!;

    /// <summary>
    /// Get time as long as you have to wait before you are revived.
    /// </summary>
    [JsonPropertyName("respawnTimer"), JsonTimeSpanConverter(BaseTimeUnit.Seconds)]
    public TimeSpan RespawnTimer { get; init; }

    [JsonPropertyName("runes")]
    public Runes Runes { get; init; } = default!;

    [JsonPropertyName("scores")]
    public Scores Scores { get; init; } = default!;

    [JsonPropertyName("skinID")]
    public int SkinID { get; init; }

    [JsonPropertyName("summonerName")]
    public string SummonerName { get; init; } = default!;

    [JsonPropertyName("summonerSpells")]
    public SummonerSpells SummonerSpells { get; init; } = default!;

    [JsonPropertyName("team")]
    public Team Team { get; init; }
}
