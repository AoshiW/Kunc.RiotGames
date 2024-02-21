namespace Kunc.RiotGames.Api.Tests;

[TestClass]
public class LolClashV1Test : ApiBase
{
    [TestMethod]
    public async Task GetChampionFreeRotationsAsync()
    {
        var tournaments = await api.LolClashV1.GetAllActiveOrUpcomingTournamentsAsync(Regions.EUN1);

        Assert.IsNotNull(tournaments);
    }
}
