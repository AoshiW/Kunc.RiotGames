namespace Kunc.RiotGames.Api.Tests;

[TestClass]
public class LolClashV1Test : ApiBase<TGame.LOL>
{
    [TestMethod]
    public async Task GetAllActiveOrUpcomingTournamentsAsync()
    {
        var tournaments = await Api.LolClashV1.GetAllActiveOrUpcomingTournamentsAsync(Regions.EUN1);

        Assert.IsNotNull(tournaments);
        if (tournaments.Length == 0)
            Assert.Inconclusive();
    }
}
