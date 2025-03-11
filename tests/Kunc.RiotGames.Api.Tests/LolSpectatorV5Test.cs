namespace Kunc.RiotGames.Api.Tests;

[TestClass]
public class LolSpectatorV5Test : ApiBase<TGame.LOL>
{
    [TestMethod]
    public async Task TestAll()
    {
        var featuredGames = await Api.LolSpectatorV5.GetFeaturedGamesAsync(Regions.JP1);

        Assert.IsNotNull(featuredGames);
        if (featuredGames.GameList.Length == 0)
            Assert.Inconclusive("No games were found.");

        var currentGame = await Api.LolSpectatorV5.GetCurrentGameInformationForPuuidAsync(Regions.JP1, featuredGames.GameList[0].Participants[0].Puuid);
        
        if (currentGame is null)
            Assert.Inconclusive("A player who should currently be in the game has not been found.");
    }
}
