#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol;

#if NET8_0_OR_GREATER
[JsonConverter(typeof(JsonStringEnumConverter<Tier>))]
#else
[JsonConverter(typeof(JsonStringEnumConverter))]
#endif
public enum Tier
{
    Unranked,
    Iron,
    Bronze,
    Silver,
    Gold,
    Platinum,
    Emerald,
    Diamond,
    Master,
    Grandmaster,
    Challenger
}

internal static class TierExtensions
{
    public static string ToUpperString(this Tier tier)
    {
        return tier switch
        {
            Tier.Unranked => "UNRANKED",
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
            _ => tier.ToString().ToUpperInvariant()
        };
    }

    public static void ThrowIfNotBetweenIronAndDiamond(this Tier tier, [CallerArgumentExpression(nameof(tier))] string? paramName = null)
    {
        if (tier < Tier.Iron || tier > Tier.Diamond)
            throw new ArgumentOutOfRangeException(paramName, $"Value '{tier}' is not valid. Valid values are between 'Iron' and 'Diamond'.");
    }
}
