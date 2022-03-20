using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

public record ChampionStats : BaseDto
{
    [JsonPropertyName("abilityHaste")]
    public double AbilityHaste { get; init; }

    [JsonPropertyName("abilityPower")]
    public double AbilityPower { get; init; }

    [JsonPropertyName("armor")]
    public double Armor { get; init; }

    [JsonPropertyName("armorPenetrationFlat")]
    public double ArmorPenetrationFlat { get; init; }

    [JsonPropertyName("armorPenetrationPercent")]
    public double ArmorPenetrationPercent { get; init; }

    [JsonPropertyName("attackDamage")]
    public double AttackDamage { get; init; }

    [JsonPropertyName("attackRange")]
    public double AttackRange { get; init; }

    [JsonPropertyName("attackSpeed")]
    public double AttackSpeed { get; init; }

    [JsonPropertyName("bonusArmorPenetrationPercent")]
    public double BonusArmorPenetrationPercent { get; init; }

    [JsonPropertyName("bonusMagicPenetrationPercent")]
    public double BonusMagicPenetrationPercent { get; init; }

    [JsonPropertyName("critChance")]
    public double CritChance { get; init; }

    [JsonPropertyName("critDamage")]
    public double CritDamage { get; init; }

    [JsonPropertyName("currentHealth")]
    public double CurrentHealth { get; init; }

    [JsonPropertyName("healShieldPower")]
    public double HealShieldPower { get; init; }

    [JsonPropertyName("healthRegenRate")]
    public double HealthRegenRate { get; init; }

    [JsonPropertyName("lifeSteal")]
    public double LifeSteal { get; init; }

    [JsonPropertyName("magicLethality")]
    public double MagicLethality { get; init; }

    [JsonPropertyName("magicPenetrationFlat")]
    public double MagicPenetrationFlat { get; init; }

    [JsonPropertyName("magicPenetrationPercent")]
    public double MagicPenetrationPercent { get; init; }

    [JsonPropertyName("magicResist")]
    public double MagicResist { get; init; }

    [JsonPropertyName("maxHealth")]
    public double MaxHealth { get; init; }

    [JsonPropertyName("moveSpeed")]
    public double MoveSpeed { get; init; }

    [JsonPropertyName("omnivamp")]
    public double Omnivamp { get; init; }

    [JsonPropertyName("physicalLethality")]
    public double PhysicalLethality { get; init; }

    [JsonPropertyName("physicalVamp")]
    public double PhysicalVamp { get; init; }

    [JsonPropertyName("resourceMax")]
    public double ResourceMax { get; init; }

    [JsonPropertyName("resourceRegenRate")]
    public double ResourceRegenRate { get; init; }

    [JsonPropertyName("resourceType")]
    public ResourceType ResourceType { get; init; }

    [JsonPropertyName("resourceValue")]
    public double ResourceValue { get; init; }

    [JsonPropertyName("spellVamp")]
    public double SpellVamp { get; init; }

    [JsonPropertyName("tenacity")]
    public double Tenacity { get; init; }
}
