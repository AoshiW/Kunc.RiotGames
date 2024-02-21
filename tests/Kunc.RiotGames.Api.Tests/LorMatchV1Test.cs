namespace Kunc.RiotGames.Api.Tests;

[TestClass]
public class LorMatchV1Test : ApiBase
{
    [TestMethod]
    public async Task GetChampionFreeRotationsAsync()
    {
        // todo I need someone who actually plays it.
        var matchIds = await api.LorMatchV1.GetListOfMatchIdsAsync(Regions.EUROPE, Puuid);
        var match = await api.LorMatchV1.GetMatchAsync(Regions.EUROPE, matchIds[0]);

        Assert.IsNotNull(match);
    }
}
