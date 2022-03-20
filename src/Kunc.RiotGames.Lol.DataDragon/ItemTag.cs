using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon;

[JsonConverter(typeof(JsonStringEnumMemberConverter)), JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: UnknownEnumValue)]
public enum ItemTag
{
    /// <summary>
    /// Represent unknow enum value.
    /// </summary>
    UnknownEnumValue,

    Boots,
    ManaRegen,
    HealthRegen,
    Health,
    CriticalStrike,
    SpellDamage,
    Mana,
    Armor,
    SpellBlock,
    LifeSteal,
    SpellVamp,
    Jungle,
    Damage,
    Lane,
    AttackSpeed,
    OnHit,
    Consumable,
    Active,
    Stealth,
    Vision,
    CooldownReduction,
    NonbootsMovement,
    AbilityHaste,
    Tenacity,
    MagicPenetration,
    ArmorPenetration,
    Aura,
    Slow,
    Trinket,
    GoldPer,
    Bilgewater,
    Movement,
}
