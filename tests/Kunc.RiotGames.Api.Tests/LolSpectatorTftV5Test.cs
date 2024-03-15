namespace Kunc.RiotGames.Api.Tests;

[TestClass]
public class LolSpectatorTftV5Test : ApiBase
{
    [TestMethod]
    public async Task TestAll()
    {
        var featuredGames = await api.LolSpectatorTftV5.GetFeaturedGamesAsync(Regions.JP1);

        Assert.IsNotNull(featuredGames);

        var currentGame = await api.LolSpectatorTftV5.GetCurrentGameInformationForPuuidAsync(Regions.JP1, featuredGames.GameList[0].Participants[0].Puuid);

        Assert.IsNotNull(currentGame);
    }
}
