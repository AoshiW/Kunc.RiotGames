using Microsoft.Extensions.DependencyInjection;

namespace Kunc.RiotGames.Lol.DataDragon.Tests;

[TestClass]
public class LolDataDragonTest
{
    const string language = "en_US";
    private string? _lastVersion;
    private readonly ILolDataDragon _dataDragon = new ServiceCollection()
        .AddDistributedMemoryCache()
        .AddSingleton<ILolDataDragon, LolDataDragon>()
        .BuildServiceProvider()
        .GetRequiredService<ILolDataDragon>();

    [TestMethod]
    public async Task GetMaps()
    {
        var lastVersion = await GetLastVersionAsync();
        var maps = await _dataDragon.GetMapsAsync(lastVersion, language, default);

        Assert.IsNotNull(maps);
    }

    [TestMethod]
    public async Task GetItems()
    {
        var lastVersion = await GetLastVersionAsync();
        var items = await _dataDragon.GetItemsAsync(lastVersion, language, default);

        Assert.IsNotNull(items);
    }

    [TestMethod]
    public async Task GetSummonerSpells()
    {
        var lastVersion = await GetLastVersionAsync();
        var summonerSpells = await _dataDragon.GetSummonerSpellsAsync(lastVersion, language, default);

        Assert.IsNotNull(summonerSpells);
    }

    [TestMethod]
    public async Task GetProfileIcons()
    {
        var lastVersion = await GetLastVersionAsync();
        var profileIcons = await _dataDragon.GetProfileIconsAsync(lastVersion, language, default);

        Assert.IsNotNull(profileIcons);
    }

    [TestMethod]
    public async Task GetAllChampions()
    {
        var lastVersion = await GetLastVersionAsync();
        var champions = await _dataDragon.GetAllChampionsAsync(lastVersion, language, default);

        Assert.IsNotNull(champions);
    }

    [TestMethod]
    public async Task GetAllChampionsBase()
    {
        var lastVersion = await GetLastVersionAsync();
        var champions = await _dataDragon.GetAllChampionsBaseAsync(lastVersion, language, default);

        Assert.IsNotNull(champions);
    }

    [TestMethod]
    public async Task GetChallenges()
    {
        var lastVersion = await GetLastVersionAsync();
        var challenges = await _dataDragon.GetChallengesAsync(lastVersion, language, default);

        Assert.IsNotNull(challenges);
    }

    [TestMethod]
    public async Task GetRunesReforged()
    {
        var lastVersion = await GetLastVersionAsync();
        var runesReforged = await _dataDragon.GetRunesReforgedAsync(lastVersion, language, default);

        Assert.IsNotNull(runesReforged);
    }

    private ValueTask<string> GetLastVersionAsync()
    {
        if (_lastVersion is not null)
            return ValueTask.FromResult(_lastVersion);

        return GetLastVersionAsyncCore(default);

        async ValueTask<string> GetLastVersionAsyncCore(CancellationToken cancellationToken)
        {
            var versions = await _dataDragon.GetVersionsAsync(cancellationToken);
            return _lastVersion = versions[0];
        }
    }
}
