using Microsoft.Extensions.Configuration;

namespace Kunc.RiotGames.Api.Tests;

[TestClass]
public class TftMatchV1Test : ApiBase<TGame.TFT>
{
    [TestMethod]
    public async Task TestAll()
    {
        var acc = GetConfiguration("Summoner").Get<AccountInfo>()!;
        var region = ToBigRegion(acc.Region);

        var matchIds = await Api.TftMatchV1.GetMatchIdsAsync(region, acc.Puuid);

        Assert.IsTrue(matchIds.Length > 0);
        bool isFirstMatch = true;
        foreach (var matchId in matchIds.Take(10))
        {
            var match = await Api.TftMatchV1.GetMatchAsync(region, matchId);

            Assert.IsNotNull(match);
            if (isFirstMatch)
            {
                isFirstMatch = false;
                if (DateTimeOffset.UtcNow - match.Info.GameDatetime > TimeSpan.FromDays(60))
                {
                    Assert.Fail("The game is too old for testing. / The player no longer plays the game.");
                }
            }
        }
    }
}
