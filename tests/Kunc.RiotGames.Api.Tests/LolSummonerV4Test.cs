using Microsoft.Extensions.Configuration;

namespace Kunc.RiotGames.Api.Tests;

[TestClass]
public class LolSummonerV4Test : ApiBase<TGame.LOL>
{
    [TestMethod]
    public async Task GetSummonerByPuuidAsync()
    {
        var acc = GetConfiguration("Summoner").Get<AccountInfo>()!;

        var summoner = await Api.LolSummonerV4.GetSummonerByPuuidAsync(acc.Region, acc.Puuid);

        Assert.IsNotNull(summoner);
    }
}
