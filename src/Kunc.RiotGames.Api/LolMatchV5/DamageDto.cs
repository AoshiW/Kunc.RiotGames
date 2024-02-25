using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolMatchV5;

public class DamageDto : BaseDto
{
    [JsonPropertyName("basic")]
    public bool IsBasic { get; set; }

    [JsonPropertyName("magicDamage")]
    public int MagicDamage { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("participantId")]
    public int ParticipantId { get; set; }

    [JsonPropertyName("physicalDamage")]
    public int PhysicalDamage { get; set; }

    [JsonPropertyName("spellName")]
    public string SpellName { get; set; } = string.Empty;

    [JsonPropertyName("spellSlot")]
    public int SpellSlot { get; set; }

    [JsonPropertyName("trueDamage")]
    public int TrueDamage { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;
    // MINION OTHER
}
