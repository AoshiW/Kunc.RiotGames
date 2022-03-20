namespace Kunc.RiotGames.Lol.DataDragon;

public record ItemStats : BaseDto
{
    public double FlatArmorMod { get; init; }
    public double FlatHPPoolMod { get; init; }
    public double FlatMPPoolMod { get; init; }
    public double FlatPhysicalDamageMod { get; init; }
    public double FlatSpellBlockMod { get; init; }
    public double FlatMagicDamageMod { get; init; }
    public double FlatMovementSpeedMod { get; init; }
    public double FlatCritChanceMod { get; init; }
    public double FlatHPRegenMod { get; init; }
    public double PercentAttackSpeedMod { get; init; }
    public double PercentLifeStealMod { get; init; }
    public double PercentMovementSpeedMod { get; init; }
}
