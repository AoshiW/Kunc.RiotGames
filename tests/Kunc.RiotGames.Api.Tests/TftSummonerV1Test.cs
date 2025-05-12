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
        Assert.IsTrue(summoner.RevisionDate > DateTimeOffset.UtcNow.AddMonths(-2), "The account has been inactive for more than 2 months.");
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
