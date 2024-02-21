namespace Kunc.RiotGames.Api.Tests;

[TestClass]
public class RiotAccountV1Test : ApiBase
{
    [TestMethod]
    public async Task GetAccountByRiotIdAsync()
    {
        var account = await api.RiotAccountV1.GetAccountByRiotIdAsync(Regions.EUROPE, RiotId.GameName, RiotId.TagLine);

        Assert.IsNotNull(account);
    }
    [TestMethod]
    public async Task GetAccountByPuuidAsync()
    {
        var account = await api.RiotAccountV1.GetAccountByPuuidAsync(Regions.EUROPE, Puuid);

        Assert.IsNotNull(account);
    }
    [TestMethod]
    public async Task GetActiveShardForPlayerAsync()
    {
        var activeShard = await api.RiotAccountV1.GetActiveShardForPlayerAsync(Regions.EUROPE, Game.Lor, Puuid);

        Assert.IsNotNull(activeShard);
    }
}
