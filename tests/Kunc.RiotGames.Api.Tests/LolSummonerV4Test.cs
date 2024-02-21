namespace Kunc.RiotGames.Api.Tests;

[TestClass]
public class LolSummonerV4Test : ApiBase
{
    [TestMethod]
    public async Task GetSummonerByPuuidAsync()
    {
        var summoner = await api.LolSummonerV4.GetSummonerByPuuidAsync(Regions.EUN1, Puuid);

        Assert.IsNotNull(summoner);
    }
}
