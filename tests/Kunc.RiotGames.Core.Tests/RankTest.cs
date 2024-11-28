using Kunc.RiotGames.Lol;

namespace Kunc.RiotGames.Core.Tests;

[TestClass]
public class RankTest
{
    [TestMethod]
    public void SortTest()
    {
        var data = new Rank[] // sorted but in reverse order
        {
            new(Tier.Challenger, Division.I),
            new(Tier.Grandmaster, Division.I),


            new(Tier.Diamond, Division.I),
            new(Tier.Diamond, Division.II),
            new(Tier.Diamond, Division.III),
            new(Tier.Diamond, Division.IV),

            new(Tier.Gold, Division.III, 99),
            new(Tier.Gold, Division.III, 50),
        };

        var copy = data.ToArray();
        Array.Sort(data);

        Array.Reverse(data);
        Assert.IsTrue(data.SequenceEqual(copy));
    }

    [TestMethod]
    [DataRow(Rank.UnrankedString)]
    [DataRow("Gold I 5lp")]
    [DataRow("Gold 1 5lp")]
    [DataRow("iron IV 5Lp")]
    public void Parse_Success(string str)
    {
        Rank.Parse(str, null);
    }

    [TestMethod]
    [DataRow("GoldI 5lp")]
    [DataRow("Gold I asdLP")]
    [DataRow("Gold IIII 5Lp")]
    [DataRow("Wood I 5LP")]
    [DataRow("Gold V 5LP")]
    [DataRow("Gold I 5")]
    [DataRow("")]
    public void Parse_Fail(string str)
    {
        Assert.IsFalse(Rank.TryParse(str, null, out _));
    }
}
