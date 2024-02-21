namespace Kunc.RiotGames.Api.Tests;

[TestClass]
public class LorRankedV1Test : ApiBase
{
    [TestMethod]
    [DataRow(Regions.AMERICAS)]
    [DataRow(Regions.EUROPE)]
    [DataRow(Regions.SEA)]
    public async Task GetChampionFreeRotationsAsync(string region)
    {
        var leaderboard = await api.LorRankedV1.GetLeaderboardAsync(region);

        Assert.IsNotNull(leaderboard);
    }
}
