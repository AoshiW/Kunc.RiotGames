namespace Kunc.RiotGames.Api.Tests;

[TestClass]
public class TftLeagueV1Test : ApiBase
{
    [TestMethod]
    public async Task GetChampionFreeRotationsAsync()
    {
        var freeRotation = await api.TftLeagueV1.GetChallengerLeagueAsync(Regions.EUN1);

        Assert.IsNotNull(freeRotation);
    }
}
