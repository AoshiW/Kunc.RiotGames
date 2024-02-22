namespace Kunc.RiotGames.Api.Tests;

[TestClass]
public class LolLeagueV4Test : ApiBase
{
    [TestMethod]
    public async Task GetChallengerLeagueAsync()
    {
        var leagueList = await api.LolLeagueV4.GetChallengerLeagueAsync(Regions.LA2, Lol.QueueType.RANKED_SOLO_5x5);

        Assert.IsNotNull(leagueList);
    }

    [TestMethod]
    public async Task GetGrandmasterLeagueAsync()
    {
        var leagueList = await api.LolLeagueV4.GetGrandmasterLeagueAsync(Regions.LA1, Lol.QueueType.RANKED_FLEX_SR);

        Assert.IsNotNull(leagueList);
    }

    [TestMethod]
    public async Task GetMasterLeagueAsync()
    {
        var leagueList = await api.LolLeagueV4.GetMasterLeagueAsync(Regions.EUN1, Lol.QueueType.RANKED_SOLO_5x5);

        Assert.IsNotNull(leagueList);
    }

    [TestMethod]
    public async Task LeagueEntriesForSummonerAsync()
    {
        var entries = await api.LolLeagueV4.LeagueEntriesForSummonerAsync(Regions.EUN1, SummonerId);

        Assert.IsNotNull(entries);
    }
}
