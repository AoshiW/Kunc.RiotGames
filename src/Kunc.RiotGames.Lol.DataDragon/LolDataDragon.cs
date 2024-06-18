using System.Text.Json;
using Kunc.RiotGames.Abstractions;
using Kunc.RiotGames.Lol.DataDragon.Challenge;
using Kunc.RiotGames.Lol.DataDragon.Champion;
using Kunc.RiotGames.Lol.DataDragon.Item;
using Kunc.RiotGames.Lol.DataDragon.Map;
using Kunc.RiotGames.Lol.DataDragon.ProfileIcon;
using Kunc.RiotGames.Lol.DataDragon.RuneReforged;
using Kunc.RiotGames.Lol.DataDragon.SummonerSpell;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Kunc.RiotGames.Lol.DataDragon;

/// <inheritdoc cref="ILolDataDragon"/>
public partial class LolDataDragon : ILolDataDragon
{
    private static readonly DistributedCacheEntryOptions distributedCacheEntryOptions = new();
    readonly HttpClient _client;
    private readonly IDistributedCache _distributedCache;
    private readonly ILogger<LolDataDragon> _logger;
    private readonly LolDataDragonOptions _options;
    private bool _disposedValue;

    /// <summary>
    /// Initializes a new instance of the <see cref="LolDataDragon"/> class.
    /// </summary>
    public LolDataDragon(IOptions<LolDataDragonOptions> options, IDistributedCache? distributedCache = null, ILogger<LolDataDragon>? logger = null)
    {
        ArgumentNullException.ThrowIfNull(options);
        _options = options.Value;
        _distributedCache = distributedCache ?? NullDistributedCache.Instance;
        _logger = logger ?? NullLogger<LolDataDragon>.Instance;
        _client = new HttpClient()
        {
            BaseAddress = new(_options.BaseAdress)
        };
    }

    async Task<byte[]> GetAsync(string requestUri, CancellationToken cancellationToken = default)
    {
        ObjectDisposedException.ThrowIf(_disposedValue, this);
        var data = await _distributedCache.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);
        if (data is null)
        {
            _logger.LogDownloading(requestUri);
            data = await _client.GetByteArrayAsync(requestUri, cancellationToken).ConfigureAwait(false);
            await _distributedCache.SetAsync(requestUri, data, _options.DefaultCacheEntryOptions ?? distributedCacheEntryOptions, cancellationToken).ConfigureAwait(false);
        }
        return data;
    }

    async Task<T> GetAsync<T>(string requestUri, CancellationToken cancellationToken)
    {
        var bytes = await GetAsync(requestUri, cancellationToken).ConfigureAwait(false);
        var obj = JsonSerializer.Deserialize<T>(bytes, _options.JsonSerializerOptions)!;
        return obj;
    }

    /// <inheritdoc/>
    public async Task<string[]> GetVersionsAsync(CancellationToken cancellationToken = default)
    {
        const string uri = "api/versions.json";
        var versions = await GetAsync<string[]>(uri, cancellationToken).ConfigureAwait(false);
        return versions!;
    }

    /// <inheritdoc/>
    public async Task<string[]> GetLanguagesAsync(CancellationToken cancellationToken = default)
    {
        const string uri = "cdn/languages.json";
        var versions = await GetAsync<string[]>(uri, cancellationToken).ConfigureAwait(false);
        return versions!;
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, MapDto>> GetMapsAsync(string version, string language, CancellationToken cancellationToken = default)
    {
        version = await ConverLatestStringAsync(version, cancellationToken).ConfigureAwait(false);
        var uri = $"cdn/{version}/data/{language}/map.json";
        var maps = await GetAsync<RootDto<MapDto>>(uri, cancellationToken).ConfigureAwait(false); ;
        return maps.Data;
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, ProfileIconDto>> GetProfileIconsAsync(string version, string language, CancellationToken cancellationToken = default)
    {
        version = await ConverLatestStringAsync(version, cancellationToken).ConfigureAwait(false);
        var uri = $"cdn/{version}/data/{language}/profileicon.json";
        var profileIcons = await GetAsync<RootDto<ProfileIconDto>>(uri, cancellationToken).ConfigureAwait(false);
        return profileIcons.Data;
    }

    /// <inheritdoc/>
    public async Task<RuneReforgedDto[]> GetRunesReforgedAsync(string version, string language, CancellationToken cancellationToken = default)
    {
        version = await ConverLatestStringAsync(version, cancellationToken).ConfigureAwait(false);
        var uri = $"cdn/{version}/data/{language}/runesReforged.json";
        var runesReforged = await GetAsync<RuneReforgedDto[]>(uri, cancellationToken).ConfigureAwait(false);
        return runesReforged;
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, SummonerSpellDto>> GetSummonerSpellsAsync(string version, string language, CancellationToken cancellationToken = default)
    {
        version = await ConverLatestStringAsync(version, cancellationToken).ConfigureAwait(false);
        var uri = $"cdn/{version}/data/{language}/summoner.json";
        var summonerSpell = await GetAsync<RootDto<SummonerSpellDto>>(uri, cancellationToken).ConfigureAwait(false);
        return summonerSpell.Data;
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, ItemDto>> GetItemsAsync(string version, string language, CancellationToken cancellationToken = default)
    {
        version = await ConverLatestStringAsync(version, cancellationToken).ConfigureAwait(false);
        var uri = $"cdn/{version}/data/{language}/item.json";
        var items = await GetAsync<RootDto<ItemDto>>(uri, cancellationToken).ConfigureAwait(false);
        return items.Data;
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, ChampionBaseDto>> GetAllChampionsBaseAsync(string version, string language, CancellationToken cancellationToken = default)
    {
        version = await ConverLatestStringAsync(version, cancellationToken).ConfigureAwait(false);
        var uri = $"cdn/{version}/data/{language}/champion.json";
        var champions = await GetAsync<RootDto<ChampionBaseDto>>(uri, cancellationToken).ConfigureAwait(false);
        return champions.Data;
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, ChampionDto>> GetAllChampionsAsync(string version, string language, CancellationToken cancellationToken = default)
    {
        version = await ConverLatestStringAsync(version, cancellationToken).ConfigureAwait(false);
        var uri = $"cdn/{version}/data/{language}/championFull.json";
        var champions = await GetAsync<RootDto<ChampionDto>>(uri, cancellationToken).ConfigureAwait(false);
        return champions.Data;
    }

    /// <inheritdoc/>
    public async Task<ChampionDto> GetChampionsAsync(string version, string language, string id, CancellationToken cancellationToken = default)
    {
        version = await ConverLatestStringAsync(version, cancellationToken).ConfigureAwait(false);
        var uri = $"cdn/{version}/data/{language}/champion/{id}.json";
        var champions = await GetAsync<RootDto<ChampionDto>>(uri, cancellationToken).ConfigureAwait(false);
        return champions.Data.First().Value;
    }

    /// <inheritdoc/>
    public async Task<ChallengeDto[]> GetChallengesAsync(string version, string language, CancellationToken cancellationToken = default)
    {
        version = await ConverLatestStringAsync(version, cancellationToken).ConfigureAwait(false);
        var uri = $"cdn/{version}/data/{language}/challenges.json";
        var challenges = await GetAsync<ChallengeDto[]>(uri, cancellationToken).ConfigureAwait(false);
        return challenges;
    }

    private ValueTask<string> ConverLatestStringAsync(string version, CancellationToken cancellationToken)
    {
        return version == "latest"
            ? GetLatestVersion(this, cancellationToken)
            : ValueTask.FromResult(version);

        static async ValueTask<string> GetLatestVersion(LolDataDragon obj, CancellationToken cancellationToken)
        {
            const string cacheKey = "lol.ddragon.latestVersion";
            var latest = await obj._distributedCache.GetStringAsync(cacheKey, cancellationToken).ConfigureAwait(false);
            if (latest == null)
            {
                var versions = await obj.GetVersionsAsync(cancellationToken).ConfigureAwait(false);
                latest = versions[0];
                await obj._distributedCache.SetStringAsync(cacheKey, latest, obj._options.DefaultCacheEntryOptions, cancellationToken).ConfigureAwait(false);
            }
            return latest;
        }
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
