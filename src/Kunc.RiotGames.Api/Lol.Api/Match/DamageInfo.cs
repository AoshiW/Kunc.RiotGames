using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api.Match;

public record DamageInfo : BaseDto
{
    [JsonPropertyName("basic")]
    public bool IsBasic { get; init; }

    [JsonPropertyName("magicDamage")]
    public int MagicDamage { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; } = default!;

    [JsonPropertyName("participantId")]
    public int ParticipantId { get; init; }

    [JsonPropertyName("physicalDamage")]
    public int PhysicalDamage { get; init; }

    [JsonPropertyName("spellName")]
    public string SpellName { get; init; } = default!;

    [JsonPropertyName("spellSlot")]
    public int SpellSlot { get; init; }

    [JsonPropertyName("trueDamage")]
    public int TrueDamage { get; init; }

    [JsonPropertyName("type")]
    public DamageType Type { get; init; } = default!;
}
