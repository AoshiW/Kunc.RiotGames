using System.Text.Json;

namespace Kunc.RiotGames.Lor.GameClient.Tests;

[TestClass]
public class DeserializeTest
{
    [TestMethod]
    public void StaticDecklist()
    {
        DeserializeJsonsInDirectory<StaticDecklist>(Path.Combine("Data", "StaticDecklist"));
    }

    [TestMethod]
    public void PositionalRectangles()
    {
        DeserializeJsonsInDirectory<PositionalRectangles>(Path.Combine("Data", "PositionalRectangles"));
    }

    [TestMethod]
    public void GameResult()
    {
        DeserializeJsonsInDirectory<GameResult>(Path.Combine("Data", "GameResult"));
    }

    static void DeserializeJsonsInDirectory<T>(string path)
    {
        var isEmpty = true;
        foreach (var item in Directory.EnumerateFiles(path))
        {
            isEmpty = false;
            var json = File.ReadAllText(item);
            var gameResult = JsonSerializer.Deserialize<T>(json);
            Assert.IsNotNull(gameResult);
        }
        Assert.IsFalse(isEmpty);
    }
}
