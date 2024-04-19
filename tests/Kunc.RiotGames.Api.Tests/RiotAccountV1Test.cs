using Microsoft.Extensions.Configuration;

namespace Kunc.RiotGames.Api.Tests;

[TestClass]
public class RiotAccountV1Test : ApiBase<TGame.LOR>
{
    [TestMethod]
    public async Task GetAccountByRiotIdAsync()
    {
        var acc = GetConfiguration("MasterPlayer").Get<AccountInfo>()!;

        var account = await Api.RiotAccountV1.GetAccountByRiotIdAsync(Regions.EUROPE, acc.RiotId);

        Assert.IsNotNull(account);
    }

    [TestMethod]
    public async Task GetAccountByPuuidAsync()
    {
        var acc = GetConfiguration("MasterPlayer").Get<AccountInfo>()!;

        var account = await Api.RiotAccountV1.GetAccountByPuuidAsync(Regions.ASIA, acc.Puuid);

        Assert.IsNotNull(account);
    }

    [TestMethod]
    public async Task GetActiveShardForPlayerAsync()
    {
        var acc = GetConfiguration("MasterPlayer").Get<AccountInfo>()!;

        var activeShard = await Api.RiotAccountV1.GetActiveShardForPlayerAsync(Regions.AMERICAS, Game.Lor, acc.Puuid);

        Assert.IsNotNull(activeShard);
    }
}
