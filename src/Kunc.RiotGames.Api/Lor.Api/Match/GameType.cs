namespace Kunc.RiotGames.Lor.Api.Match;

public enum GameType
{
    /// <summary>
    /// Tutorial.
    /// </summary>
    Tutorial,

    /// <summary>
    /// AI.
    /// </summary>
    AI,

    /// <summary>
    /// Normal.
    /// </summary>
    Normal,

    /// <summary>
    /// Ranked.
    /// </summary>
    Ranked,

    /// <summary>
    /// Standard gauntlet.
    /// </summary>
    StandardGauntlet,

    /// <summary>
    /// Singleton.
    /// </summary>
    Singleton,

    VanillaTrial,

    Lab,
}
//internal class JsonListStringListFactionConverter : JsonConverter<List<Faction>>
//{
//    private static readonly IReadOnlyDictionary<string, Faction> keyValuePairs = new Dictionary<string, Faction>()
//    {
//        ["faction_Demacia_Name"] = Faction.Demacia,
//        ["faction_Freljord_Name"] = Faction.Freljord,
//        ["faction_Ionia_Name"] = Faction.Ionia,
//        ["faction_Noxus_Name"] = Faction.Noxus,
//        ["faction_Piltover_Name"] = Faction.PiltoverZaun,
//        ["faction_ShadowIsles_Name"] = Faction.ShadowIsles,
//        ["faction_Bilgewater_Name"] = Faction.Bilgewater,
//        ["faction_Shurima_Name"] = Faction.Shurima,
//        //["faction__Name"] = Faction.,
//        ["faction_MtTargon_Name"] = Faction.Targon,
//    };

//    public override List<Faction> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
//    {
//        if (reader.TokenType != JsonTokenType.StartArray || !reader.Read())
//        {
//            throw new JsonException();
//        }
//        var elements = new List<Faction>();
//        while (reader.TokenType != JsonTokenType.EndArray)
//        {
//            if (!keyValuePairs.TryGetValue(reader.GetString()!, out var faction))
//            {
//                throw new NotImplementedException("New faction value isnt implemented");
//            }
//            elements.Add(faction);
//            if (!reader.Read())
//            {
//                throw new JsonException();
//            }
//        }
//        return elements;
//    }

//    public override void Write(Utf8JsonWriter writer, List<Faction> value, JsonSerializerOptions options)
//    {
//        writer.WriteStartArray();
//        for (var i = 0; i < value.Count; i++)
//        {
//            writer.WriteStringValue(keyValuePairs.First(x => x.Value == value[i]).Key);
//        }
//        writer.WriteEndArray();
//    }
//}
/*
 * public static class LeagueEntryExtension
{
    // distribution of values
    //     |  I  |  II | III |  IV |
    // -----------------------------
    // CHA | 27  |     |     |     |
    // GM  | 26  |     |     |     |
    // MAS | 25  |     |     |     |
    // DIA | 24  | 23  | 22  | 21  | 
    // PLA | 20  | 19  | 18  | 17  |
    // GOL | 16  | 15  | 14  | 13  |
    // SIL | 12  | 11  | 10  |  9  |
    // BRO |  8  |  7  |  6  |  5  |
    // IRO |  4  |  3  |  2  |  1  |
    // UNR |  0  |     |     |     |

    static public IReadOnlyDictionary<(Tier Tier, Division Division), int> TierDivision { get; }

    static LeagueEntryExtension()
    {
        var divisions = Enum.GetValues(typeof(Division)).Cast<Division>();
        var dic = new Dictionary<(Tier,Division),int> ();
        int num = 0;
        foreach (var tier in Enum.GetValues(typeof(Tier)).Cast<Tier>())
            if (tier.IsHighTier() || tier == Tier.Unranked)
                dic.Add((tier, Division.I), num++);
            else
                foreach (var division in divisions)
                    dic.Add((tier, division), num++);
        TierDivision = dic;
    }

    /// <summary>
    /// Computes the average of a Match Making Rating of <see cref="LeagueEntry"/> and  values.
    /// </summary>
    /// <param name="source">A sequence of <see cref="LeagueEntry"/> values to calculate the average of.</param>
    /// <param name="skipUnranked"></param>
    /// <returns></returns>
    /// <exception cref="KeyNotFoundException"> If the <see cref="LeagueEntry"/> has an invalid combination of <see cref="Tier"/> and <see cref="Division"/>  </exception>
    public static (Tier Tier, Division Division) AverageRank(this IEnumerable<LeagueEntry> source, bool skipUnranked = true)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        double sum = 0;
        int count = 0;
        foreach (var item in source)
        {
            if (item.Tier == Tier.Unranked && skipUnranked)
            {
                continue;
            }
            sum += TierDivision[(item.Tier, item.Division)];
            ++count;
        }
        sum = Math.Round(sum / count);
        return TierDivision.First(x => x.Value == sum).Key;
    }
}
*/