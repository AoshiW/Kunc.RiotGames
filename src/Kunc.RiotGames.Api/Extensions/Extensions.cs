using Kunc.RiotGames.Lol.Api;
using Kunc.RiotGames.Tft.Api;

namespace Kunc.RiotGames.Extensions;

public static class EnumExtensions
{
    public static string ToApiString(this TftQueue queue)
    {
        return queue switch
        {
            TftQueue.Ranked => "RANKED_TFT",
            TftQueue.RankedTurbo => "RANKED_TFT_TURBO",
            _ => throw new NotImplementedException(),
        };
    }

    public static string ToApiString(this LolQueue queue)
        => queue switch
        {
            LolQueue.RankedSolo => "RANKED_SOLO_5x5",
            LolQueue.RankedFlex => "RANKED_FLEX_SR",
            _ => throw new NotImplementedException(),
        };

    public static Region ToRegion(this Platform platform)
    {
        return platform switch
        {
            Platform.NA1 or Platform.BR1 or Platform.LA1 or Platform.LA2 or Platform.OC1 => Region.Americas,
            Platform.KR or Platform.JP1 => Region.Asia,
            Platform.TR1 or Platform.EUN1 or Platform.EUW1 or Platform.RU => Region.Europe,
            _ => throw new NotImplementedException(),
        };
    }

    public static string ToStringPerf(this Division division)
    {
        return division switch
        {
            Division.I => "I",
            Division.II => "II",
            Division.III => "III",
            Division.IV => "IV",
            //Division.V => "V",
            _ => throw new NotImplementedException(),
        };
    }

    public static string ToLowerString(this Platform platform)
    {
        return platform switch
        {
            Platform.TR1 => "tr1",
            Platform.BR1 => "br1",
            Platform.EUN1 => "eun1",
            Platform.EUW1 => "euw1",
            Platform.JP1 => "jp1",
            Platform.KR => "kr",
            Platform.LA1 => "la1",
            Platform.LA2 => "la2",
            Platform.NA1 => "na1",
            Platform.OC1 => "oc1",
            Platform.RU => "ru",
            Platform.PBE => "pbe",
            _ => throw new NotImplementedException(),
        };
    }

    public static string ToLowerString(this Region region)
    {
        return region switch
        {
            Region.Americas => "americas",
            Region.Asia => "asia",
            Region.Esports => "esports",
            Region.Europe => "europe",
            Region.Sea => "sea",
            _ => throw new NotImplementedException(),
        };
    }
}
