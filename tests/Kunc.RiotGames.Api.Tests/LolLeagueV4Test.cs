namespace Kunc.RiotGames.Api.Tests;

[TestClass]
public class LolLeagueV4Test : ApiBase
{
    [TestMethod]
    public async Task GetChampionFreeRotationsAsync()
    {
        var freeRotation = await api.LolLeagueV4.GetChallengerLeagueAsync(Regions.EUN1, Lol.QueueType.RANKED_SOLO_5x5);

        Assert.IsNotNull(freeRotation);
    }
}
