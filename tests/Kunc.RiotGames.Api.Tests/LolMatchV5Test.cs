namespace Kunc.RiotGames.Api.Tests;

[TestClass]
public class LolMatchV5Test : ApiBase
{
    [TestMethod]
    public async Task TestAll()
    {
        var matchIds = await api.LolMatchV5.GetListOfMatchIdsAsync(Regions.EUROPE, Puuid, new()
        {
            Queue = 420,
        });

        Assert.IsTrue(matchIds.Length > 0);

        var match = await api.LolMatchV5.GetMatchAsync(Regions.EUROPE, matchIds[0]);
        var matchTimeline = await api.LolMatchV5.GetMatchTimelineAsync(Regions.EUROPE, matchIds[0]);

        Assert.IsNotNull(match);
        Assert.IsNotNull(matchTimeline);
    }
}
