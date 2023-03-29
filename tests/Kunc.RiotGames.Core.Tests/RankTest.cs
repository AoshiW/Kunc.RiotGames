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
}
