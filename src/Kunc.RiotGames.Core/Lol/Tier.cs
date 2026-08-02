#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol;

[JsonConverter(typeof(JsonStringEnumConverter<Tier>))]
public enum Tier
{
    Unranked,
    Salt,
    Wood,
    Iron,
    Bronze,
    Silver,
    Gold,
    Platinum,
    Emerald,
    Diamond,
    Master,
    Grandmaster,
    Challenger,
    Legend,
}

internal static class TierExtensions
{
    public static string ToUpperString(this Tier tier)
    {
        return tier switch
        {
            Tier.Unranked => "UNRANKED",
            Tier.Salt => "SALT",
            Tier.Wood => "WOOD",
            Tier.Iron => "IRON",
            Tier.Bronze => "BRONZE",
            Tier.Silver => "SILVER",
            Tier.Gold => "GOLD",
            Tier.Platinum => "PLATINUM",
            Tier.Emerald => "EMERALD",
            Tier.Diamond => "DIAMOND",
            Tier.Master => "MASTER",
            Tier.Grandmaster => "GRANDMASTER",
            Tier.Challenger => "CHALLENGER",
            Tier.Legend => "LEGEND",
            _ => tier.ToString().ToUpperInvariant()
        };
    }

    public static void ThrowIfNotBetweenIronAndDiamond(this Tier tier, [CallerArgumentExpression(nameof(tier))] string? paramName = null)
    {
        if (tier < Tier.Iron || tier > Tier.Diamond)
            throw new ArgumentOutOfRangeException(paramName, $"Value '{tier}' is not valid. Valid values are between 'Iron' and 'Diamond'.");
    }
}
