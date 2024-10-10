using System.Text.Json;
using Kunc.RiotGames.Lol.DataDragon.Challenge;
using Kunc.RiotGames.Lol.DataDragon.Champion;
using Kunc.RiotGames.Lol.DataDragon.Item;
using Kunc.RiotGames.Lol.DataDragon.Map;
using Kunc.RiotGames.Lol.DataDragon.ProfileIcon;
using Kunc.RiotGames.Lol.DataDragon.RuneReforged;
using Kunc.RiotGames.Lol.DataDragon.SummonerSpell;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Kunc.RiotGames.Lol.DataDragon;

/// <inheritdoc cref="ILolDataDragon"/>
public partial class LolDataDragon : ILolDataDragon
{
    private readonly HybridCache _cache;
    private readonly HttpClient _client;
    private readonly ILogger<LolDataDragon> _logger;
    private readonly LolDataDragonOptions _options;
    private bool _disposedValue;

    /// <summary>
    /// Initializes a new instance of the <see cref="LolDataDragon"/> class.
    /// </summary>
    public LolDataDragon(IOptions<LolDataDragonOptions> options, HybridCache cache, ILogger<LolDataDragon>? logger = null)
    {
        ArgumentNullException.ThrowIfNull(options);
        ArgumentNullException.ThrowIfNull(cache);
        _options = options.Value;
        _cache = cache;
        _logger = logger ?? NullLogger<LolDataDragon>.Instance;
        _client = new HttpClient()
        {
            BaseAddress = new(_options.BaseAdress)
        };
    }

    ValueTask<byte[]> GetAsync(string requestUri, string[] tags, CancellationToken cancellationToken)
    {
        ObjectDisposedException.ThrowIf(_disposedValue, this);
        return _cache.GetOrCreateAsync(requestUri, (this, requestUri), static async (state, cancellationToken) =>
        {
            state.Item1._logger.LogDownloading(state.requestUri);
            return await state.Item1._client.GetByteArrayAsync(state.requestUri, cancellationToken).ConfigureAwait(false);
        }, _options.DefaultCacheEntryOptions, tags, cancellationToken);
    }

    async ValueTask<T> GetAsync<T>(string requestUri, string[] tags, CancellationToken cancellationToken)
    {
        var bytes = await GetAsync(requestUri, tags, cancellationToken).ConfigureAwait(false);
        var obj = JsonSerializer.Deserialize<T>(bytes, _options.JsonSerializerOptions)!;
        return obj;
    }

    /// <inheritdoc/>
    public async Task<string[]> GetVersionsAsync(CancellationToken cancellationToken = default)
    {
        const string uri = "api/versions.json";
        var versions = await GetAsync<string[]>(uri, [], cancellationToken).ConfigureAwait(false);
        return versions!;
    }

    /// <inheritdoc/>
    public async Task<string[]> GetLanguagesAsync(CancellationToken cancellationToken = default)
    {
        const string uri = "cdn/languages.json";
        var versions = await GetAsync<string[]>(uri, [], cancellationToken).ConfigureAwait(false);
        return versions!;
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, MapDto>> GetMapsAsync(string version, string language, CancellationToken cancellationToken = default)
    {
        version = await ConvertLatestStringAsync(version, cancellationToken).ConfigureAwait(false);
        var uri = $"cdn/{version}/data/{language}/map.json";
        var maps = await GetAsync<RootDto<MapDto>>(uri, [version, language], cancellationToken).ConfigureAwait(false); ;
        return maps.Data;
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, ProfileIconDto>> GetProfileIconsAsync(string version, string language, CancellationToken cancellationToken = default)
    {
        version = await ConvertLatestStringAsync(version, cancellationToken).ConfigureAwait(false);
        var uri = $"cdn/{version}/data/{language}/profileicon.json";
        var profileIcons = await GetAsync<RootDto<ProfileIconDto>>(uri, [version, language], cancellationToken).ConfigureAwait(false);
        return profileIcons.Data;
    }

    /// <inheritdoc/>
    public async Task<RuneReforgedDto[]> GetRunesReforgedAsync(string version, string language, CancellationToken cancellationToken = default)
    {
        version = await ConvertLatestStringAsync(version, cancellationToken).ConfigureAwait(false);
        var uri = $"cdn/{version}/data/{language}/runesReforged.json";
        var runesReforged = await GetAsync<RuneReforgedDto[]>(uri, [version, language], cancellationToken).ConfigureAwait(false);
        return runesReforged;
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, SummonerSpellDto>> GetSummonerSpellsAsync(string version, string language, CancellationToken cancellationToken = default)
    {
        version = await ConvertLatestStringAsync(version, cancellationToken).ConfigureAwait(false);
        var uri = $"cdn/{version}/data/{language}/summoner.json";
        var summonerSpell = await GetAsync<RootDto<SummonerSpellDto>>(uri, [version, language], cancellationToken).ConfigureAwait(false);
        return summonerSpell.Data;
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, ItemDto>> GetItemsAsync(string version, string language, CancellationToken cancellationToken = default)
    {
        version = await ConvertLatestStringAsync(version, cancellationToken).ConfigureAwait(false);
        var uri = $"cdn/{version}/data/{language}/item.json";
        var items = await GetAsync<RootDto<ItemDto>>(uri, [version, language], cancellationToken).ConfigureAwait(false);
        return items.Data;
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, ChampionBaseDto>> GetChampionsBaseAsync(string version, string language, CancellationToken cancellationToken = default)
    {
        version = await ConvertLatestStringAsync(version, cancellationToken).ConfigureAwait(false);
        var uri = $"cdn/{version}/data/{language}/champion.json";
        var champions = await GetAsync<RootDto<ChampionBaseDto>>(uri, [version, language], cancellationToken).ConfigureAwait(false);
        return champions.Data;
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, ChampionDto>> GetChampionsAsync(string version, string language, CancellationToken cancellationToken = default)
    {
        version = await ConvertLatestStringAsync(version, cancellationToken).ConfigureAwait(false);
        var uri = $"cdn/{version}/data/{language}/championFull.json";
        var champions = await GetAsync<RootDto<ChampionDto>>(uri, [version, language], cancellationToken).ConfigureAwait(false);
        return champions.Data;
    }

    /// <inheritdoc/>
    public async Task<ChampionDto> GetChampionAsync(string version, string language, string id, CancellationToken cancellationToken = default)
    {
        version = await ConvertLatestStringAsync(version, cancellationToken).ConfigureAwait(false);
        var uri = $"cdn/{version}/data/{language}/champion/{id}.json";
        var champions = await GetAsync<RootDto<ChampionDto>>(uri, [version, language], cancellationToken).ConfigureAwait(false);
        return champions.Data.First().Value;
    }

    /// <inheritdoc/>
    public async Task<ChallengeDto[]> GetChallengesAsync(string version, string language, CancellationToken cancellationToken = default)
    {
        version = await ConvertLatestStringAsync(version, cancellationToken).ConfigureAwait(false);
        var uri = $"cdn/{version}/data/{language}/challenges.json";
        var challenges = await GetAsync<ChallengeDto[]>(uri, [version, language], cancellationToken).ConfigureAwait(false);
        return challenges;
    }

    private ValueTask<string> ConvertLatestStringAsync(string version, CancellationToken cancellationToken)
    {
        if (version != "latest")
            return ValueTask.FromResult(version);

        return _cache.GetOrCreateAsync("api/latestVersion.json", this, async (state, cancellationToken) =>
        {
            var versions = await state.GetVersionsAsync(cancellationToken).ConfigureAwait(false);
            var latest = versions[0];
            return latest;
        }, _options.LatestVersionCacheEntryOptions ?? _options.DefaultCacheEntryOptions, null, cancellationToken);
    }

    /// <summary>
    /// Releases the unmanaged resources and optionally disposes of the managed resources.
    /// </summary>
    /// <param name="disposing">
    /// <see langword="true"/> to release both managed and unmanaged resources;
    /// <see langword="false"/> to releases only unmanaged resources.
    /// </param>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                _client.Dispose();
            }
            _disposedValue = true;
        }
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
