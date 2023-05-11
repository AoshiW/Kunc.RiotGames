using Kunc.RiotGames.Lol;

namespace Kunc.RiotGames.Core.Tests;

[TestClass]
public class EnumToStringTest
{
    [TestMethod]
    public void Tier_ToUpperString()
    {
        var values = Enum.GetValues<Tier>();

        foreach (var value in values)
        {
            Assert.AreEqual(value.ToString().ToUpperInvariant(), value.ToUpperString());
        }
    }

    [TestMethod]
    public void Division_ToFastString()
    {
        var values = Enum.GetValues<Division>();

        foreach (var value in values)
        {
            Assert.AreEqual(value.ToString(), value.ToFastString());
        }
    }

    [TestMethod]
    public void Game_ToLowerString()
    {
        var values = Enum.GetValues<Game>();

        foreach (var value in values)
        {
            Assert.AreEqual(value.ToString().ToLowerInvariant(), value.ToLowerString());
        }
    }
}
