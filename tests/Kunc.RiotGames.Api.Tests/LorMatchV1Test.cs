using Microsoft.Extensions.Configuration;

namespace Kunc.RiotGames.Api.Tests;

[TestClass]
public class LorMatchV1Test : ApiBase<TGame.LOR>
{
    [TestMethod]
    public async Task GetChampionFreeRotationsAsync()
    {
        var masterPlayer = GetConfiguration("MasterPlayer").Get<AccountInfo>()!;

        var matchIds = await Api.LorMatchV1.GetListOfMatchIdsAsync(masterPlayer.Region, masterPlayer.Puuid);

        Assert.IsTrue(matchIds.Length > 0);

        bool isFirstMatch = true;
        foreach (var matchId in matchIds.Take(5))
        {
            var match = await Api.LorMatchV1.GetMatchAsync(masterPlayer.Region, matchId);

            if (match is null)
                continue;

            Assert.IsNotNull(match);
            if (isFirstMatch)
            {
                isFirstMatch = false;
                if (DateTimeOffset.UtcNow - match.Info.GameStartTime > TimeSpan.FromDays(60))
                {
                    Assert.Fail("The game is too old for testing. / The player no longer plays the game.");
                }
            }
        }
    }
}
