using Microsoft.Extensions.Configuration;

namespace Kunc.RiotGames.Api.Tests;

[TestClass]
public class LolLeagueV4Test : ApiBase<TGame.LOL>
{
    [TestMethod]
    public async Task GetChallengerLeagueAsync()
    {
        var leagueList = await Api.LolLeagueV4.GetChallengerLeagueAsync(Regions.LA2, Lol.QueueType.RankedSolo5x5);

        Assert.IsNotNull(leagueList);
    }

    [TestMethod]
    public async Task GetGrandmasterLeagueAsync()
    {
        var leagueList = await Api.LolLeagueV4.GetGrandmasterLeagueAsync(Regions.LA1, Lol.QueueType.RankedFlexSR);

        Assert.IsNotNull(leagueList);
    }

    [TestMethod]
    public async Task GetMasterLeagueAsync()
    {
        var leagueList = await Api.LolLeagueV4.GetMasterLeagueAsync(Regions.EUN1, Lol.QueueType.RankedSolo5x5);

        Assert.IsNotNull(leagueList);
    }

    [TestMethod]
    public async Task LeagueEntriesForSummonerAsync()
    {
        var acc = GetConfiguration("Summoner").Get<AccountInfo>()!;
        var summonerId = GetConfiguration("Summoner:Id").Get<string>()!;

        var entries = await Api.LolLeagueV4.LeagueEntriesForSummonerAsync(acc.Region, summonerId);

        Assert.IsNotNull(entries);
        if (entries.Length == 0)
        {
            Assert.Inconclusive("Summoner without rank.");
        }
    }
}
