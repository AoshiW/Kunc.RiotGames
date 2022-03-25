using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api.Match;

public record ChampionStats : BaseDto
{
    [JsonPropertyName("abilityHaste")]
    public int AbilityHaste { get; init; }

    [JsonPropertyName("abilityPower")]
    public int AbilityPower { get; init; }

    [JsonPropertyName("armor")]
    public int Armor { get; init; }

    [JsonPropertyName("armorPen")]
    public int ArmorPen { get; init; }

    [JsonPropertyName("armorPenPercent")]
    public int ArmorPenPercent { get; init; }

    [JsonPropertyName("attackDamage")]
    public int AttackDamage { get; init; }

    [JsonPropertyName("attackSpeed")]
    public int AttackSpeed { get; init; }

    [JsonPropertyName("bonusArmorPenPercent")]
    public int BonusArmorPenPercent { get; init; }

    [JsonPropertyName("bonusMagicPenPercent")]
    public int BonusMagicPenPercent { get; init; }

    [JsonPropertyName("ccReduction")]
    public int CcReduction { get; init; }
    
    [Obsolete($"use {nameof(AbilityHaste)}")]
    [JsonPropertyName("cooldownReduction")]
    public int CooldownReduction { get; init; }

    [JsonPropertyName("health")]
    public int Health { get; init; }

    [JsonPropertyName("healthMax")]
    public int HealthMax { get; init; }

    [JsonPropertyName("healthRegen")]
    public int HealthRegen { get; init; }

    [JsonPropertyName("lifesteal")]
    public int Lifesteal { get; init; }

    [JsonPropertyName("magicPen")]
    public int MagicPen { get; init; }

    [JsonPropertyName("magicPenPercent")]
    public int MagicPenPercent { get; init; }

    [JsonPropertyName("magicResist")]
    public int MagicResist { get; init; }

    [JsonPropertyName("movementSpeed")]
    public int MovementSpeed { get; init; }

    [JsonPropertyName("omnivamp")]
    public int Omnivamp { get; init; }

    [JsonPropertyName("physicalVamp")]
    public int PhysicalVamp { get; init; }

    [JsonPropertyName("power")]
    public int Power { get; init; }

    [JsonPropertyName("powerMax")]
    public int PowerMax { get; init; }

    [JsonPropertyName("powerRegen")]
    public int PowerRegen { get; init; }

    [JsonPropertyName("spellVamp")]
    public int SpellVamp { get; init; }
}
