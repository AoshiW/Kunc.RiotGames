using Kunc.RiotGames.Lol.Api;

namespace Kunc.RiotGames.Extensions;

public static class TierExtensions
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
            Tier.Diamond => "DIAMOND",
            Tier.Master => "MASTER",
            Tier.Grandmater => "GRANDMASTER",
            Tier.Challenger => "CHALLENGER",
            _ => throw new NotImplementedException(),
        };
    }

    public static bool IsUnranked(this Tier tier) => tier == Tier.Unranked;
}
