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

        var matchIds = await Api.LolMatchV5.GetListOfMatchIdsAsync(region, acc.Puuid);

        Assert.IsTrue(matchIds.Length > 0);
        bool isFirstMatch = true;
        foreach (var matchId in matchIds.Take(10))
        {
            var match = await Api.LolMatchV5.GetMatchAsync(region, matchId);
            var matchTimeline = await Api.LolMatchV5.GetMatchTimelineAsync(region, matchId);


            Assert.IsNotNull(match);
            if (isFirstMatch)
            {
                isFirstMatch = false;
                if (DateTimeOffset.UtcNow - match.Info.GameStart > TimeSpan.FromDays(60))
                {
                    Assert.Fail("The game is too old for testing. / The player no longer plays the game.");
                }
            }
            Assert.IsNotNull(matchTimeline);
        }
    }
}
