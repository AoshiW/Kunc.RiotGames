namespace Kunc.RiotGames.Lol.DataDragon.Tests;

[TestClass]
public class LolDataDragonTest
{
    private readonly ILolDataDragon _dataDragon = LolDataDragon.Create();

    public static IEnumerable<(string, string)> DefaultVersionLanguage => [
        ("latest", "en_US"),
        ("latest", "cs_CZ"),
    ];


    [TestMethod]
    [DynamicData(nameof(DefaultVersionLanguage))]
    public async Task GetMaps(string version, string language)
    {
        var maps = await _dataDragon.GetMapsAsync(version, language, default);

        Assert.IsNotNull(maps);
    }

    [TestMethod]
    [DynamicData(nameof(DefaultVersionLanguage))]
    public async Task GetItems(string version, string language)
    {
        var items = await _dataDragon.GetItemsAsync(version, language, default);

        Assert.IsNotNull(items);
    }

    [TestMethod]
    [DynamicData(nameof(DefaultVersionLanguage))]
    public async Task GetSummonerSpells(string version, string language)
    {
        var summonerSpells = await _dataDragon.GetSummonerSpellsAsync(version, language, default);

        Assert.IsNotNull(summonerSpells);
    }

    [TestMethod]
    [DynamicData(nameof(DefaultVersionLanguage))]
    public async Task GetProfileIcons(string version, string language)
    {
        var profileIcons = await _dataDragon.GetProfileIconsAsync(version, language, default);

        Assert.IsNotNull(profileIcons);
    }

    [TestMethod]
    [DynamicData(nameof(DefaultVersionLanguage))]
    public async Task GetChampions(string version, string language)
    {
        var champions = await _dataDragon.GetChampionsAsync(version, language, default);

        Assert.IsNotNull(champions);
    }

    [TestMethod]
    [DynamicData(nameof(DefaultVersionLanguage))]
    public async Task GetChampionsBase(string version, string language)
    {
        var champions = await _dataDragon.GetChampionsBaseAsync(version, language, default);

        Assert.IsNotNull(champions);
    }

    [TestMethod]
    [DynamicData(nameof(DefaultVersionLanguage))]
    public async Task GetChallenges(string version, string language)
    {
        var challenges = await _dataDragon.GetChallengesAsync(version, language, default);

        Assert.IsNotNull(challenges);
    }

    [TestMethod]
    public async Task GetLanguages()
    {
        var languages = await _dataDragon.GetLanguagesAsync(default);

        Assert.IsNotNull(languages);
    }

    [TestMethod]
    [DynamicData(nameof(DefaultVersionLanguage))]
    public async Task GetRunesReforged(string version, string language)
    {
        var runesReforged = await _dataDragon.GetRunesReforgedAsync(version, language, default);

        Assert.IsNotNull(runesReforged);
    }
}
