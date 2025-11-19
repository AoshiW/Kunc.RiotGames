using Microsoft.Extensions.Configuration;

namespace Kunc.RiotGames.Api.Tests;

[TestClass]
public class LolMatchV5Test : ApiBase<TGame.LOL>
{
    [TestMethod]
    public async Task TestAll()
    {
        var acc = GetConfiguration("Summoner").Get<AccountInfo>()!;
        var region = ToBigRegion(acc.Region);

        var matchIds = await Api.LolMatchV5.GetMatchIdsAsync(region, acc.Puuid);

        Assert.IsNotEmpty(matchIds);
        bool isFirstMatch = true;
        foreach (var matchId in matchIds.Take(10))
        {
            var match = await Api.LolMatchV5.GetMatchAsync(region, matchId);
            var matchTimeline = await Api.LolMatchV5.GetMatchTimelineAsync(region, matchId);


            Assert.IsNotNull(match);
            if (isFirstMatch)
            {
                isFirstMatch = false;
                var lastGameTimeDiff = DateTimeOffset.UtcNow - match.Info.GameStart;
                if (lastGameTimeDiff.Days > 60)
                {
                    Assert.Fail($"The game is too old for testing. / The player no longer plays the game.\nLast game: {lastGameTimeDiff.Days} days ago");
                }
            }
            Assert.IsNotNull(matchTimeline);
        }
    }

    [TestMethod]
    public async Task GetPlayerReplaysAsync()
    {
        var acc = GetConfiguration("Summoner").Get<AccountInfo>()!;
        var region = ToBigRegion(acc.Region);

        var replays = await Api.LolMatchV5.GetPlayerReplaysAsync(region, acc.Puuid);

        Assert.IsNotNull(replays);
        Assert.HasCount(5, replays.MatchFileURLs);
    }
}
