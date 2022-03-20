using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utils;

namespace Kunc.RiotGames.Lol.DataDragon.TestProject;

[TestClass]
public class DataDragonTest
{
    static readonly LolDataDragon _client = new();
    readonly string language = "cs_CZ";
    static string version = "12.3.1";

    [ClassInitialize]
#pragma warning disable IDE0060 // Remove unused parameter
    public static async Task Init(TestContext context)
#pragma warning restore IDE0060 // Remove unused parameter
    {
        var versions = await _client.GetVersionsAsync();
        version = versions[0];
    }


    [TestMethod]
    public async Task GetItemsAsync()
    {
        var obj = await _client.GetItemsAsync(version, language);
        Assert.IsNotNull(obj);
        Assert.That.CheckNullabilityInfo(obj);
        Assert.That.CheckJsonExtensionData(obj);
    }

    [TestMethod]
    public async Task GetAllChampionsAsync()
    {
        var obj = await _client.GetAllChampionsAsync(version, language);
        Assert.IsNotNull(obj);
        Assert.That.CheckNullabilityInfo(obj);
        Assert.That.CheckJsonExtensionData(obj);
    }

    [TestMethod]
    public async Task GetAllChampionsBaseAsync()
    {
        var obj = await _client.GetAllChampionsBaseAsync(version, language);
        Assert.IsNotNull(obj);
        Assert.That.CheckNullabilityInfo(obj); 
        Assert.That.CheckJsonExtensionData(obj);
    }

    [TestMethod]
    public async Task GetLanguagesAsync()
    {
        var obj = await _client.GetLanguagesAsync();
        Assert.IsNotNull(obj);
    }

    [TestMethod]
    public async Task GetMapsAsync()
    {
        var obj = await _client.GetMapsAsync(version, language);
        Assert.IsNotNull(obj);
        Assert.That.CheckNullabilityInfo(obj);
        Assert.That.CheckJsonExtensionData(obj);
    }

    [TestMethod]
    public async Task GetProfileIconsAsync()
    {
        var obj = await _client.GetProfileIconsAsync(version, language);
        Assert.IsNotNull(obj);
        Assert.That.CheckNullabilityInfo(obj);
        Assert.That.CheckJsonExtensionData(obj);
    }

    [TestMethod]
    public async Task GetRunesReforgedAsync()
    {
        var obj = await _client.GetRunesReforgedAsync(version, language);
        Assert.IsNotNull(obj);
        Assert.That.CheckNullabilityInfo(obj);
        Assert.That.CheckJsonExtensionData(obj);
    }

    [TestMethod]
    public async Task GetSummonerSpellsAsync()
    {
        var obj = await _client.GetSummonerSpellsAsync(version, language);
        Assert.IsNotNull(obj);
        Assert.That.CheckNullabilityInfo(obj);
        Assert.That.CheckJsonExtensionData(obj);
    }

    [TestMethod]
    public async Task GetVersionsAsync()
    {
        var obj = await _client.GetVersionsAsync();
        Assert.IsNotNull(obj);
    }

    [TestMethod]
    [DataRow("Velkoz")]
    [DataRow("MonkeyKing")]
    [DataRow("Leblanc")]
    [DataRow("Fiddlesticks")]
    [DataRow("AurelionSol")]
    public async Task GetChampionsAsync(string championName)
    {
        var obj = await _client.GetChampionsAsync(version, language, championName);
        Assert.IsNotNull(obj);
        Assert.That.CheckNullabilityInfo(obj);
        Assert.That.CheckJsonExtensionData(obj);
    } 
}