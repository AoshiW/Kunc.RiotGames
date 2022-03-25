using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api.Match;

public record DamageStats : BaseDto
{
    [JsonPropertyName("magicDamageDone")]
    public int MagicDamageDone { get; init; }

    [JsonPropertyName("magicDamageDoneToChampions")]
    public int MagicDamageDoneToChampions { get; init; }

    [JsonPropertyName("magicDamageTaken")]
    public int MagicDamageTaken { get; init; }

    [JsonPropertyName("physicalDamageDone")]
    public int PhysicalDamageDone { get; init; }

    [JsonPropertyName("physicalDamageDoneToChampions")]
    public int PhysicalDamageDoneToChampions { get; init; }

    [JsonPropertyName("physicalDamageTaken")]
    public int PhysicalDamageTaken { get; init; }

    [JsonPropertyName("totalDamageDone")]
    public int TotalDamageDone { get; init; }

    [JsonPropertyName("totalDamageDoneToChampions")]
    public int TotalDamageDoneToChampions { get; init; }

    [JsonPropertyName("totalDamageTaken")]
    public int TotalDamageTaken { get; init; }

    [JsonPropertyName("trueDamageDone")]
    public int TrueDamageDone { get; init; }

    [JsonPropertyName("trueDamageDoneToChampions")]
    public int TrueDamageDoneToChampions { get; init; }

    [JsonPropertyName("trueDamageTaken")]
    public int TrueDamageTaken { get; init; }
}
