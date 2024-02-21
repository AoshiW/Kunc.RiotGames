namespace Kunc.RiotGames.Api.Tests;

[TestClass]
public class LolMatchV5Test : ApiBase
{
    [TestMethod]
    public async Task GetChampionFreeRotationsAsync()
    {
        var freeRotation = await api.LolMatchV5.GetListOfMatchIdsAsync(Regions.EUROPE, Puuid);

        Assert.IsNotNull(freeRotation);
    }
}
