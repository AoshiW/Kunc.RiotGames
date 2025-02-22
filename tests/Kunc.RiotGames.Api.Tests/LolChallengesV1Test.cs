using Microsoft.Extensions.Configuration;

namespace Kunc.RiotGames.Api.Tests;

[TestClass]
public class LolChallengesV1Test : ApiBase<TGame.LOL>
{
    [TestMethod]
    public async Task GetListOfAllBasicChallengeConfigurationInformationAsync()
    {
        var challengeConfigInfos = await Api.LolChallengesV1.GetListOfAllBasicChallengeConfigurationInformationAsync(Regions.ME1);

        Assert.IsNotNull(challengeConfigInfos);
        Assert.AreNotEqual(0, challengeConfigInfos.Length);
    }

    [TestMethod]
    public async Task GetMapOfLevelToPercentileOfPlayersAsync()
    {
        var data = await Api.LolChallengesV1.GetMapOfLevelToPercentileOfPlayersAsync(Regions.ME1);

        Assert.IsNotNull(data);
        Assert.AreNotEqual(0, data.Count);
    }

    [TestMethod]
    [DataRow(603000)] // Swarm Survivor
    public async Task GetChallengeConfigurationAsync(long challengeId)
    {
        var challengeConfigInfo = await Api.LolChallengesV1.GetChallengeConfigurationAsync(Regions.ME1, challengeId);

        Assert.IsNotNull(challengeConfigInfo);
    }

    [TestMethod]
    [DataRow(603000, "MASTER")] // Swarm Survivor
    public async Task GetTopPlayersAsync(long challengeId, string level)
    {
        var topPlayers = await Api.LolChallengesV1.GetTopPlayersAsync(Regions.ME1, challengeId, level);

        Assert.IsNotNull(topPlayers);
    }

    [TestMethod]
    [DataRow(603000)] //Swarm Survivor
    public async Task GetMapOfLevelToPercentileAsync(long challengeId)
    {
        var challengePercentile = await Api.LolChallengesV1.GetMapOfLevelToPercentileAsync(Regions.ME1, challengeId);

        Assert.IsNotNull(challengePercentile);
    }

    [TestMethod]
    public async Task GetPlayerInformationAsync()
    {
        var acc = GetConfiguration("Summoner").Get<AccountInfo>()!;
        var playerInfo = await Api.LolChallengesV1.GetPlayerInformationAsync(acc.Region, acc.Puuid);

        Assert.IsNotNull(playerInfo);
    }
}
