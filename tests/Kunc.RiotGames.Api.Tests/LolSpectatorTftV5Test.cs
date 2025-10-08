namespace Kunc.RiotGames.Api.Tests;

[TestClass]
public class LolSpectatorTftV5Test : ApiBase<TGame.TFT>
{
    [TestMethod]
    [Ignore("GetFeaturedGamesAsync is removed.")]
    public async Task TestAll()
    {
        var featuredGames = await Api.LolSpectatorTftV5.GetFeaturedGamesAsync(Regions.VN2);

        Assert.IsNotNull(featuredGames);
        if (featuredGames.GameList.Length == 0)
            Assert.Inconclusive("No games were found.");

        var currentGame = await Api.LolSpectatorTftV5.GetCurrentGameInformationForPuuidAsync(Regions.VN2, featuredGames.GameList[0].Participants[0].Puuid);

        if (currentGame is null)
            Assert.Inconclusive("A player who should currently be in the game has not been found.");
    }
}
