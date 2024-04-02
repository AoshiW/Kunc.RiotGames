namespace Kunc.RiotGames.Api.Tests;

[TestClass]
public class LolSpectatorTftV5Test : ApiBase<TGame.TFT>
{
    [TestMethod]
    public async Task TestAll()
    {
        var featuredGames = await Api.LolSpectatorTftV5.GetFeaturedGamesAsync(Regions.VN2);

        Assert.IsNotNull(featuredGames);

        var currentGame = await Api.LolSpectatorTftV5.GetCurrentGameInformationForPuuidAsync(Regions.VN2, featuredGames.GameList[0].Participants[0].Puuid);

        Assert.IsNotNull(currentGame);
    }
}
