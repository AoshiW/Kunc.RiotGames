using Microsoft.Extensions.Configuration;

namespace Kunc.RiotGames.Api.Tests;

[TestClass]
public class RiotAccountV1Test_TFT : ApiBase<TGame.TFT>
{
    [TestMethod]
    public async Task GetAccountByRiotIdAsync()
    {
        var acc = GetConfiguration("Summoner").Get<AccountInfo>()!;

        var account = await Api.RiotAccountV1.GetAccountByRiotIdAsync(Regions.EUROPE, acc.RiotId);

        Assert.IsNotNull(account);
    }

    [TestMethod]
    public async Task GetAccountByPuuidAsync()
    {
        var acc = GetConfiguration("Summoner").Get<AccountInfo>()!;

        var account = await Api.RiotAccountV1.GetAccountByPuuidAsync(Regions.ASIA, acc.Puuid);

        Assert.IsNotNull(account);
    }

    [TestMethod]
    public async Task GetActiveShardForPlayerAsync()
    {
        var acc = GetConfiguration("Summoner").Get<AccountInfo>()!;

        var accountRegion = await Api.RiotAccountV1.GetActiveRegionForPlayerAsync(Regions.AMERICAS, Game.Tft, acc.Puuid);

        Assert.IsNotNull(accountRegion);
        Assert.AreEqual(acc.Region, accountRegion.Region, StringComparer.OrdinalIgnoreCase);
    }
}
