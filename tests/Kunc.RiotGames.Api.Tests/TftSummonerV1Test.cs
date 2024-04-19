using Microsoft.Extensions.Configuration;

namespace Kunc.RiotGames.Api.Tests;

[TestClass]
public class TftSummonerV1Test : ApiBase<TGame.TFT>
{
    [TestMethod]
    public async Task GetSummonerByPuuidAsync()
    {
        var acc = GetConfiguration("Summoner").Get<AccountInfo>()!;

        var summoner = await Api.TftSummonerV1.GetSummonerByPuuidAsync(acc.Region, acc.Puuid);

        Assert.IsNotNull(summoner);
    }

    [TestMethod]
    public async Task GetSummonerBySummonerIdAsync()
    {
        var acc = GetConfiguration("Summoner").Get<AccountInfo>()!;
        var summonerId = GetConfiguration("Summoner:Id").Get<string>()!;

        var summoner = await Api.TftSummonerV1.GetSummonerBySummonerIdAsync(acc.Region, summonerId);

        Assert.IsNotNull(summoner);
    }
}
