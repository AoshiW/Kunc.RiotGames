using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon.Champion;

public class ChampionStatsDto : BaseDto
{
    [JsonPropertyName("hp")]
    public double HP { get; set; }

    [JsonPropertyName("hpperlevel")]
    public double HPPerLevel { get; set; }

    [JsonPropertyName("mp")]
    public double MP { get; set; }

    [JsonPropertyName("mpperlevel")]
    public double MPPerLevel { get; set; }

    [JsonPropertyName("movespeed")]
    public double MoveSpeed { get; set; }

    [JsonPropertyName("armor")]
    public double Armor { get; set; }

    [JsonPropertyName("armorperlevel")]
    public double ArmorPerLevel { get; set; }

    [JsonPropertyName("spellblock")]
    public double SpellBlock { get; set; }

    [JsonPropertyName("spellblockperlevel")]
    public double SpellBlockPerLevel { get; set; }

    [JsonPropertyName("attackrange")]
    public double AttackRange { get; set; }

    [JsonPropertyName("hpregen")]
    public double HPRegen { get; set; }

    [JsonPropertyName("hpregenperlevel")]
    public double HPRegenPerLevel { get; set; }

    [JsonPropertyName("mpregen")]
    public double MPRegen { get; set; }

    [JsonPropertyName("mpregenperlevel")]
    public double MPRegenPerLevel { get; set; }

    [JsonPropertyName("crit")]
    public double Crit { get; set; }

    [JsonPropertyName("critperlevel")]
    public double Critperlevel { get; set; }

    [JsonPropertyName("attackdamage")]
    public double AttackDamage { get; set; }

    [JsonPropertyName("attackdamageperlevel")]
    public double AttackDamagePerLevel { get; set; }

    [JsonPropertyName("attackspeed")]
    public double AttackSpeed { get; set; }

    [JsonPropertyName("attackspeedperlevel")]
    public double AttackSpeedPerLevel { get; set; }

    /// <summary>
    /// https://leagueoflegends.fandom.com/wiki/Champion_statistic
    /// </summary>
    /// <param name="base">Base champion stats.</param>
    /// <param name="growth">Growth stats per level.</param>
    /// <param name="level"></param>
    /// <returns></returns>
    public static double StatsAtLevel(double @base, double growth, int level)
    {
        int num = level - 1;
        return @base + growth * num * (0.7025 + 0.0175 * num);
    }
}
