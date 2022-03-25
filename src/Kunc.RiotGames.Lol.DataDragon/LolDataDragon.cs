using System.Net.Http.Json;

namespace Kunc.RiotGames.Lol.DataDragon;

/// <inheritdoc cref="ILolDataDragon"/>
public class LolDataDragon : ILolDataDragon
{
    private readonly HttpClient _client;
    private readonly LolDataDragonOptions _options;

    /// <summary>
    /// Initializes a new instance of the <see cref="LolDataDragon"/>.
    /// </summary>
    public LolDataDragon(LolDataDragonOptions? options = null)
    {
        _options = options ?? new();
        _client = new HttpClient()
        {
            BaseAddress = new Uri(_options.BaseAddress)
        };
    }

    /// <inheritdoc/>
    public async Task<ChampionBase[]> GetAllChampionsBaseAsync(string version, string language, CancellationToken cancellationToken = default)
    {
        var obj = await _client.GetFromJsonAsync<RootObj<ChampionBase>>($"/cdn/{version}/data/{language}/champion.json", cancellationToken).ConfigureAwait(false);
        return obj!.Data.Values.ToArray();
    }

    /// <inheritdoc/>
    public async Task<Champion[]> GetAllChampionsAsync(string version, string language, CancellationToken cancellationToken = default)
    {
        var obj = await _client.GetFromJsonAsync<RootObj<Champion>>($"/cdn/{version}/data/{language}/championFull.json", cancellationToken).ConfigureAwait(false);
        return obj!.Data.Values.ToArray();
    }

    /// <inheritdoc/>
    public async Task<Champion> GetChampionsAsync(string version, string language, string championId, CancellationToken cancellationToken = default)
    {
        var obj = await _client.GetFromJsonAsync<RootObj<Champion>>($"/cdn/{version}/data/{language}/champion/{championId}.json", cancellationToken).ConfigureAwait(false);
        return obj!.Data.Values.First();
    }

    /// <inheritdoc/>
    public async Task<Item[]> GetItemsAsync(string version, string language, CancellationToken cancellationToken = default)
    {
        var obj = await _client.GetFromJsonAsync<RootObj<Item>>($"/cdn/{version}/data/{language}/item.json", cancellationToken).ConfigureAwait(false);
        return obj!.Data.Values.ToArray();
    }

    /// <inheritdoc/>
    public async Task<ProfileIcon[]> GetProfileIconsAsync(string version, string language, CancellationToken cancellationToken = default)
    {
        var obj = await _client.GetFromJsonAsync<RootObj<ProfileIcon>>($"/cdn/{version}/data/{language}/profileicon.json", cancellationToken).ConfigureAwait(false);
        return obj!.Data.Values.ToArray();
    }

    /// <inheritdoc/>
    public async Task<Map[]> GetMapsAsync(string version, string language, CancellationToken cancellationToken = default)
    {
        var obj = await _client.GetFromJsonAsync<RootObj<Map>>($"/cdn/{version}/data/{language}/map.json", cancellationToken).ConfigureAwait(false);
        return obj!.Data.Values.ToArray();
    }

    /// <inheritdoc/>
    public async Task<SummonerSpell[]> GetSummonerSpellsAsync(string version, string language, CancellationToken cancellationToken = default)
    {
        var obj = await _client.GetFromJsonAsync<RootObj<SummonerSpell>>($"/cdn/{version}/data/{language}/summoner.json", cancellationToken).ConfigureAwait(false);
        return obj!.Data.Values.ToArray();
    }

    /// <inheritdoc/>
    public async Task<RunesReforged[]> GetRunesReforgedAsync(string version, string language, CancellationToken cancellationToken = default)
    {
        var obj = await _client.GetFromJsonAsync<RunesReforged[]>($"/cdn/{version}/data/{language}/runesReforged.json", cancellationToken).ConfigureAwait(false);
        return obj!;
    }

    /// <inheritdoc/>
    public async Task<string[]> GetLanguagesAsync(CancellationToken cancellationToken = default)
    {
        var result = await _client.GetFromJsonAsync<string[]>("cdn/languages.json", cancellationToken).ConfigureAwait(false);
        return result!;
    }

    /// <inheritdoc/>
    public async Task<string[]> GetVersionsAsync(CancellationToken cancellationToken = default)
    {
        var result = await _client.GetFromJsonAsync<string[]>("api/versions.json", cancellationToken).ConfigureAwait(false);
        return result!;
    }
}
