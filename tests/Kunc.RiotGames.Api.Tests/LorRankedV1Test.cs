namespace Kunc.RiotGames.Api.Tests;

[TestClass]
public class LorRankedV1Test : ApiBase<TGame.LOR>
{
    [TestMethod]
    [DataRow("AMERICAS")]
    [DataRow("EUROPE")]
    [DataRow("SEA")]
    public async Task GetLeaderboardAsync(string region)
    {
        var leaderboard = await Api.LorRankedV1.GetLeaderboardAsync(region);

        Assert.IsNotNull(leaderboard);
    }
}
