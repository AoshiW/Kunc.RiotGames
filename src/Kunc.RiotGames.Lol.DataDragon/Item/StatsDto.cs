namespace Kunc.RiotGames.Lol.DataDragon.Item;

public class StatsDto : BaseDto
{
    public double FlatMovementSpeedMod { get; set; }
    public int FlatHPPoolMod { get; set; }
    public double FlatCritChanceMod { get; set; }
    public int FlatMagicDamageMod { get; set; }
    public int FlatMPPoolMod { get; set; }
    public int FlatArmorMod { get; set; }
    public int FlatSpellBlockMod { get; set; }
    public int FlatPhysicalDamageMod { get; set; }
    public double PercentAttackSpeedMod { get; set; }
    public double PercentLifeStealMod { get; set; }
    public double FlatHPRegenMod { get; set; }
    public double PercentMovementSpeedMod { get; set; }
}
