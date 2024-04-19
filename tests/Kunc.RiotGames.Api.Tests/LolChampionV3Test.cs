namespace Kunc.RiotGames.Api.Tests;

[TestClass]
public class LolChampionV3Test : ApiBase<TGame.LOL>
{
    [TestMethod]
    public async Task GetChampionFreeRotationsAsync()
    {
        var freeRotation = await Api.LolChampionV3.GetChampionFreeRotationsAsync(Regions.OC1);

        Assert.IsNotNull(freeRotation);
        Assert.IsTrue(freeRotation.FreeChampionIds.Length > 15);
    }
}
