using Kunc.RiotGames.Api.LolChampionMasteryV4;
using Microsoft.Extensions.Configuration;

namespace Kunc.RiotGames.Api.Tests;

[TestClass]
public class LolChampionMasteryV4Test : ApiBase<TGame.LOL>
{
    [TestMethod]
    public async Task GetAllChampionMasteryEntriesAsync()
    {
        var summoner = GetConfiguration("Summoner").Get<AccountInfo>()!;

        var entries = await Api.LolChampionMasteryV4.GetAllChampionMasteryEntriesAsync(summoner.Region, summoner.Puuid);

        Assert.IsTrue(entries.Length > 0);
    }

    [TestMethod]
    public async Task GetChampionMasteryByPuuidAsync()
    {
        var summoner = GetConfiguration("Summoner").Get<AccountInfo>()!;

        var entry = await Api.LolChampionMasteryV4.GetChampionMasteryByPuuidAsync(summoner.Region, summoner.Puuid, 74);

        Assert.IsNotNull(entry);
    }

    [TestMethod]
    public async Task GetTopChampionMasteryEntriesAsync()
    {
        var summoner = GetConfiguration("Summoner").Get<AccountInfo>()!;
        var query = new TopChampionMasteryEntriesQuery()
        {
            Count = 7,
        };
        var entries = await Api.LolChampionMasteryV4.GetTopChampionMasteryEntriesAsync(summoner.Region, summoner.Puuid, query);

        Assert.AreEqual(entries.Length, 7);
    }

    [TestMethod]
    public async Task GetPlayersTotalChampionMasteryScoreAsync()
    {
        var summoner = GetConfiguration("Summoner").Get<AccountInfo>()!;

        var score = await Api.LolChampionMasteryV4.GetPlayersTotalChampionMasteryScoreAsync(summoner.Region, summoner.Puuid);

        Assert.IsTrue(score > 0);
    }
}
