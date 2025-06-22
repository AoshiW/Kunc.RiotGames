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

        var entries = await Api.TftLeagueV1.LeagueEntriesForSummonerAsync(acc.Region, acc.Puuid);

        Assert.IsNotNull(entries);
        if (entries.Length == 0)
            Assert.Inconclusive("Summoner is unranked.");
    }

    [TestMethod]
    public async Task GetAllLeaguesEntriesAsync()
    {
        var entries = await Api.TftLeagueV1.GetAllLeaguesEntriesAsync(Regions.SG2, Tier.Emerald, Division.II);

        Assert.AreNotEqual(0, entries.Length);
    }

    [TestMethod]
    public async Task GetTopRatedLadderAsync()
    {
        var topRatedLadder = await Api.TftLeagueV1.GetTopRatedLadderAsync(Regions.SG2, QueueType.RankedTftTurbo);

        Assert.AreNotEqual(0, topRatedLadder.Length);
    }
}
