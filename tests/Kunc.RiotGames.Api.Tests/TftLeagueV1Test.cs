namespace Kunc.RiotGames.Api.Tests;

[TestClass]
public class TftLeagueV1Test : ApiBase
{
    [TestMethod]
    public async Task GetChallengerLeagueAsync()
    {
        var leagueList = await api.TftLeagueV1.GetChallengerLeagueAsync(Regions.BR1);

        Assert.IsNotNull(leagueList);
    }

    [TestMethod]
    public async Task GetGrandmasterLeagueAsync()
    {
        var leagueList = await api.TftLeagueV1.GetGrandmasterLeagueAsync(Regions.BR1);

        Assert.IsNotNull(leagueList);
    }

    [TestMethod]
    public async Task GetMasterLeagueAsync()
    {
        var leagueList = await api.TftLeagueV1.GetMasterLeagueAsync(Regions.BR1);

        Assert.IsNotNull(leagueList);
    }
}
