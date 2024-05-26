using System.Text.Json;
using Kunc.RiotGames.Lol.GameClient.LiveClientData;

namespace Kunc.RiotGames.Lol.GameClient.Tests;

[TestClass]
public class DeserializeTest
{
    [TestMethod]
    public void AllGameData()
    {
        var allGameData = JsonSerializer.Deserialize<AllGameDataDto>(File.ReadAllText("allgamedata.json"));

        Assert.IsNotNull(allGameData);
    }
}
