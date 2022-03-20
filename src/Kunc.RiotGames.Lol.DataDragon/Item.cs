using Kunc.RiotGames.JsonConverters;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon;

public record Item : BaseDto
{
    [JsonPropertyName("name")]
    public string Name { get; init; } = default!;

    [JsonPropertyName("description")]
    public string Description { get; init; } = default!;

    [JsonPropertyName("colloq")]
    public string Colloq { get; init; } = default!;

    [JsonPropertyName("plaintext")]
    public string PlainText { get; init; } = default!;

    [JsonPropertyName("stacks"), JsonConverter(typeof(Int32Converter))]
    public int? Stacks { get; init; }

    [JsonPropertyName("consumed")]
    public bool? Consumed { get; init; }

    /// <summary>
    /// Wrapper for <see cref="Consumed"/>.
    /// </summary>
    [JsonIgnore]
    public bool IsConsumed => Consumed ?? false;

    [JsonPropertyName("consumeOnFull")]
    public bool? ConsumeOnFull { get; init; }

    /// <summary>
    /// Wrapper for <see cref="ConsumeOnFull"/>.
    /// </summary>
    [JsonIgnore]
    public bool IsConsumeOnFull => ConsumeOnFull ?? false;

    [JsonPropertyName("inStore")]
    public bool? InStore { get; init; }

    /// <summary>
    /// Wrapper for <see cref="InStore"/>.
    /// </summary>
    [JsonIgnore]
    public bool IsInStore => InStore ?? true;

    [JsonPropertyName("hideFromAll")]
    public bool? HideFromAll { get; init; }
    
    /// <summary>
    /// Wrapper for <see cref="HideFromAll"/>.
    /// </summary>
    [JsonIgnore]
    public bool IsHideFromAll => HideFromAll ?? false;

    [JsonPropertyName("from")]
    public string[]? From { get; init; }

    [JsonPropertyName("into")]
    public string[]? Into { get; init; }

    [JsonPropertyName("specialRecipe"), JsonConverter(typeof(Int32Converter))]
    public int? SpecialRecipe { get; init; }

    [JsonPropertyName("image")]
    public Image Image { get; init; } = default!;

    [JsonPropertyName("gold")]
    public GoldInfo Gold { get; init; } = default!;

    [JsonPropertyName("tags")]
    public ItemTag[] Tags { get; init; } = default!;

    [JsonPropertyName("maps")]
    public Dictionary<string, bool> Maps { get; init; } = default!;

    [JsonPropertyName("stats")]
    public ItemStats Stats { get; init; } = default!;

    [JsonPropertyName("effect")]
    public Dictionary<string, string>? Effect { get; init; }

    [JsonPropertyName("depth")]
    public int? Depth { get; init; }

    [JsonPropertyName("requiredChampion")]
    public string? RequiredChampion { get; set; }
}
