using Microsoft.Extensions.Configuration;

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

    [TestMethod]
    public async Task GetPlayersByPuuidAsync()
    {
        var summoner = GetConfiguration("Summoner").Get<AccountInfo>()!;

        var players = await Api.LolClashV1.GetPlayersByPuuidAsync(summoner.Region, summoner.Puuid);

        _ = players;
        Assert.Inconclusive("This test is only to verify that the endpoint does not throw exception.");
    }
}
