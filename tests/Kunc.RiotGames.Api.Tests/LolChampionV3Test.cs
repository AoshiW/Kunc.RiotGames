namespace Kunc.RiotGames.Api.Tests;

[TestClass]
public class LolChampionV3Test : ApiBase
{
    [TestMethod]
    public async Task GetChampionFreeRotationsAsync()
    {
        var freeRotation = await api.LolChampionV3.GetChampionFreeRotationsAsync(Regions.EUN1);

        Assert.IsNotNull(freeRotation);
    }
}
