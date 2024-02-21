namespace Kunc.RiotGames.Api.Tests;

[TestClass]
public class TftMatchV1Test : ApiBase
{
    [TestMethod]
    public async Task TestAll()
    {
        var matchIds = await api.TftMatchV1.GetListOfMatchIdsAsync(Regions.EUROPE, Puuid);

        Assert.IsTrue(matchIds.Length > 0);

        var match = await api.TftMatchV1.GetMatchAsync(Regions.EUROPE, matchIds[0]);

        Assert.IsNotNull(match);
    }
}
