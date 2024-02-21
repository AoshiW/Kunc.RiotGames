namespace Kunc.RiotGames.Api.Tests;

[TestClass]
public class LolChallengesV1Test : ApiBase
{
    [TestMethod]
    public async Task GetChampionFreeRotationsAsync()
    {
        var freeRotation = await api.LolChallengesV1.GetPlayerInformationAsync(Regions.EUN1, Puuid);

        Assert.IsNotNull(freeRotation);
    }
}
