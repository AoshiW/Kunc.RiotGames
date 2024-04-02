using Kunc.RiotGames.Lol;
using Microsoft.Extensions.Configuration;

namespace Kunc.RiotGames.Api.Tests;

[TestClass]
public class TftLeagueV1Test : ApiBase<TGame.TFT>
{
    [TestMethod]
    public async Task GetChallengerLeagueAsync()
    {
        var leagueList = await Api.TftLeagueV1.GetChallengerLeagueAsync(Regions.BR1);

        Assert.IsNotNull(leagueList);
    }

    [TestMethod]
    public async Task GetGrandmasterLeagueAsync()
    {
        var leagueList = await Api.TftLeagueV1.GetGrandmasterLeagueAsync(Regions.BR1);

        Assert.IsNotNull(leagueList);
    }

    [TestMethod]
    public async Task GetMasterLeagueAsync()
    {
        var leagueList = await Api.TftLeagueV1.GetMasterLeagueAsync(Regions.BR1);

        Assert.IsNotNull(leagueList);
    }

    [TestMethod]
    public async Task LeagueEntriesForSummonerAsync()
    {
        var acc = GetConfiguration("Summoner").Get<AccountInfo>()!;
        var summonerId = GetConfiguration("Summoner:Id").Get<string>()!;

        var entries = await Api.TftLeagueV1.LeagueEntriesForSummonerAsync(acc.Region, summonerId);

        Assert.IsNotNull(entries);
        if (entries.Length == 0)
            Assert.Inconclusive("Summoner is unranked.");
    }

    [TestMethod]
    public async Task GetAllLeaguesEntriesAsync()
    {
        var entries = await Api.TftLeagueV1.GetAllLeaguesEntriesAsync(Regions.PH2, Tier.Emerald, Division.II);

        Assert.AreNotEqual(0, entries.Length);
    }
}
