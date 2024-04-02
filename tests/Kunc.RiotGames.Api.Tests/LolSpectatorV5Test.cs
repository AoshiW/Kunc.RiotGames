namespace Kunc.RiotGames.Api.Tests;

[TestClass]
public class LolSpectatorV5Test : ApiBase<TGame.LOL>
{
    [TestMethod]
    public async Task TestAll()
    {
        var featuredGames = await Api.LolSpectatorV5.GetFeaturedGamesAsync(Regions.JP1);

        Assert.IsNotNull(featuredGames);

        var currentGame = await Api.LolSpectatorV5.GetCurrentGameInformationForPuuidAsync(Regions.JP1, featuredGames.GameList[0].Participants[0].Puuid);

        Assert.IsNotNull(currentGame);
    }
}
