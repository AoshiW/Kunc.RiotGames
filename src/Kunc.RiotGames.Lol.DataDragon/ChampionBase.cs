using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon;

public record ChampionBase : BaseDto
{
    [JsonPropertyName("version")]
    public string? Version { get; init; }

    [JsonPropertyName("id")]
    public string Id { get; init; } = default!;

    [JsonPropertyName("key"), JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public int Key { get; init; } = default!;

    [JsonPropertyName("name")]
    public string Name { get; init; } = default!;

    [JsonPropertyName("title")]
    public string Title { get; init; } = default!;

    // cca 245-254 chars
    [JsonPropertyName("blurb")]
    public string Blurb { get; init; } = default!;

    [JsonPropertyName("info")]
    public ChampionInfo Info { get; init; } = default!;

    [JsonPropertyName("image")]
    public Image Image { get; init; } = default!;

    [JsonPropertyName("tags")]
    public ChampionTag[] Tags { get; init; } = default!;

    //localized
    [JsonPropertyName("partype")]
    public string Partype { get; init; } = default!;

    [JsonPropertyName("stats")]
    public ChampionStats Stats { get; init; } = default!;
}
