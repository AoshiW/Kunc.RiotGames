using Kunc.RiotGames.Api.LolChampionMasteryV4;

namespace Kunc.RiotGames.Api.Tests;

[TestClass]
public class LolChampionMasteryV4Test : ApiBase
{
    [TestMethod]
    public async Task GetAllChampionMasteryEntriesAsync()
    {
        var entries = await api.LolChampionMasteryV4.GetAllChampionMasteryEntriesAsync(Regions.EUN1, Puuid);

        Assert.IsTrue(entries.Length > 0);
    }
    [TestMethod]
    public async Task GetChampionMasteryByPuuidAsync()
    {
        var entry = await api.LolChampionMasteryV4.GetChampionMasteryByPuuidAsync(Regions.EUN1, Puuid, 74);

        Assert.IsNotNull(entry);
    }
    [TestMethod]
    public async Task GetTopChampionMasteryEntriesAsync()
    {
        var query = new TopChampionMasteryEntriesQuery()
        {
            Count = 7,
        };
        var entries = await api.LolChampionMasteryV4.GetTopChampionMasteryEntriesAsync(Regions.EUN1, Puuid, query);

        Assert.AreEqual(entries.Length, 7);
    }
    [TestMethod]
    public async Task GetPlayersTotalChampionMasteryScoreAsync()
    {
        var score = await api.LolChampionMasteryV4.GetPlayersTotalChampionMasteryScoreAsync(Regions.EUN1, Puuid);

        Assert.IsTrue(score > 0);
    }
}
