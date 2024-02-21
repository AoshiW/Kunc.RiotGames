namespace Kunc.RiotGames.Api.Tests;

[TestClass]
public class TftSummonerV1Test : ApiBase
{
    [TestMethod]
    public async Task GetSummonerByPuuidAsync()
    {
        var summoner = await api.TftSummonerV1.GetSummonerByPuuidAsync(Regions.EUN1, Puuid);

        Assert.IsNotNull(summoner);
    }
}
