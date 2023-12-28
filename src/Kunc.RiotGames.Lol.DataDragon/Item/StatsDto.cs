namespace Kunc.RiotGames.Lol.DataDragon.Item;

public class StatsDto : BaseDto
{
    public double FlatMovementSpeedMod { get; set; }
    public double FlatHPPoolMod { get; set; }
    public double FlatCritChanceMod { get; set; }
    public double FlatMagicDamageMod { get; set; }
    public double FlatMPPoolMod { get; set; }
    public double FlatArmorMod { get; set; }
    public double FlatSpellBlockMod { get; set; }
    public double FlatPhysicalDamageMod { get; set; }
    public double PercentAttackSpeedMod { get; set; }
    public double PercentLifeStealMod { get; set; }
    public double FlatHPRegenMod { get; set; }
    public double PercentMovementSpeedMod { get; set; }
}
