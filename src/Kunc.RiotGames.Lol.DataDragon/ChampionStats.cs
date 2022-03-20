using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon;

public record ChampionStats : BaseDto
{
    // todo StatsAtLevel
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// https://leagueoflegends.fandom.com/wiki/Champion_statistic
    /// </remarks>
    /// <param name="base">Base champion stats.</param>
    /// <param name="growth">Growth stats per level.</param>
    /// <param name="level"></param>
    /// <returns></returns>
    static double StatsAtLevel(double @base, double growth, int level)
    {
        var levelMinusOne = level - 1;
        return @base + growth * levelMinusOne * (0.7025 + 0.0175 * levelMinusOne);
    }

    [JsonPropertyName("hp")]
    public double HP { get; init; }

    [JsonPropertyName("hpperlevel")]
    public double HPPerLevel { get; init; }

    [JsonPropertyName("mp")]
    public double MP { get; init; }

    [JsonPropertyName("mpperlevel")]
    public double MPPerLevel { get; init; }

    [JsonPropertyName("movespeed")]
    public double MoveSpeed { get; init; }

    [JsonPropertyName("armor")]
    public double Armor { get; init; }

    [JsonPropertyName("armorperlevel")]
    public double ArmorPerLevel { get; init; }

    [JsonPropertyName("spellblock")]
    public double SpellBlock { get; init; }

    [JsonPropertyName("spellblockperlevel")]
    public double SpellBlockPerLevel { get; init; }

    [JsonPropertyName("attackrange")]
    public double AttackRange { get; init; }

    [JsonPropertyName("hpregen")]
    public double HPRegen { get; init; }

    [JsonPropertyName("hpregenperlevel")]
    public double HPRegenPerLevel { get; init; }

    [JsonPropertyName("mpregen")]
    public double MPRegen { get; init; }

    [JsonPropertyName("mpregenperlevel")]
    public double MPRegenPerLevel { get; init; }

    [JsonPropertyName("crit")]
    public double Crit { get; init; }

    [JsonPropertyName("critperlevel")]
    public double CritPerLevel { get; init; }

    [JsonPropertyName("attackdamage")]
    public double AttackDamage { get; init; }

    [JsonPropertyName("attackdamageperlevel")]
    public double AttackDamagePerLevel { get; init; }

    [JsonPropertyName("attackspeed")]
    public double AttackSpeed { get; init; }

    [JsonPropertyName("attackspeedperlevel")]
    public double AttackSpeedPerLevel { get; init; }
}
