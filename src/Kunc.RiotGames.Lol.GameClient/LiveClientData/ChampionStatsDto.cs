using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

public class ChampionStatsDto : BaseDto
{
    [JsonPropertyName("abilityHaste")]
    public double AbilityHaste { get; set; }

    [JsonPropertyName("abilityPower")]
    public double AbilityPower { get; set; }

    [JsonPropertyName("armor")]
    public double Armor { get; set; }

    [JsonPropertyName("armorPenetrationFlat")]
    public double ArmorPenetrationFlat { get; set; }

    [JsonPropertyName("armorPenetrationPercent")]
    public double ArmorPenetrationPercent { get; set; }

    [JsonPropertyName("attackDamage")]
    public double AttackDamage { get; set; }

    [JsonPropertyName("attackRange")]
    public double AttackRange { get; set; }

    [JsonPropertyName("attackSpeed")]
    public double AttackSpeed { get; set; }

    [JsonPropertyName("bonusArmorPenetrationPercent")]
    public double BonusArmorPenetrationPercent { get; set; }

    [JsonPropertyName("bonusMagicPenetrationPercent")]
    public double BonusMagicPenetrationPercent { get; set; }

    [JsonPropertyName("critChance")]
    public double CritChance { get; set; }

    [JsonPropertyName("critDamage")]
    public double CritDamage { get; set; }

    [JsonPropertyName("currentHealth")]
    public double CurrentHealth { get; set; }

    [JsonPropertyName("healShieldPower")]
    public double HealShieldPower { get; set; }

    [JsonPropertyName("healthRegenRate")]
    public double HealthRegenRate { get; set; }

    [JsonPropertyName("lifeSteal")]
    public double LifeSteal { get; set; }

    [JsonPropertyName("magicLethality")]
    public double MagicLethality { get; set; }

    [JsonPropertyName("magicPenetrationFlat")]
    public double MagicPenetrationFlat { get; set; }

    [JsonPropertyName("magicPenetrationPercent")]
    public double MagicPenetrationPercent { get; set; }

    [JsonPropertyName("magicResist")]
    public double MagicResist { get; set; }

    [JsonPropertyName("maxHealth")]
    public double MaxHealth { get; set; }

    [JsonPropertyName("moveSpeed")]
    public double MoveSpeed { get; set; }

    [JsonPropertyName("omnivamp")]
    public double Omnivamp { get; set; }

    [JsonPropertyName("physicalLethality")]
    public double PhysicalLethality { get; set; }

    [JsonPropertyName("physicalVamp")]
    public double PhysicalVamp { get; set; }

    [JsonPropertyName("resourceMax")]
    public double ResourceMax { get; set; }

    [JsonPropertyName("resourceRegenRate")]
    public double ResourceRegenRate { get; set; }

    [JsonPropertyName("resourceType")]
    public string ResourceType { get; set; } = string.Empty;

    [JsonPropertyName("resourceValue")]
    public double ResourceValue { get; set; }

    [JsonPropertyName("spellVamp")]
    public double SpellVamp { get; set; }

    [JsonPropertyName("tenacity")]
    public double Tenacity { get; set; }
}
