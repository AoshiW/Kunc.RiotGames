namespace Kunc.RiotGames.Api.Tests;

[TestClass]
public class LolSpectatorV4Test : ApiBase
{
    [TestMethod]
    public async Task TestAll()
    {
        var featuredGames = await api.LolSpectatorV4.GetListOfFeaturedGamesAsync(Regions.JP1);

        Assert.IsNotNull(featuredGames);

        var currentGame = await api.LolSpectatorV4.GetCurrentGameInformationForSummonerAsync(Regions.JP1, featuredGames.GameList[0].Participants[0].SummonerId);

        Assert.IsNotNull(currentGame);
    }
}
