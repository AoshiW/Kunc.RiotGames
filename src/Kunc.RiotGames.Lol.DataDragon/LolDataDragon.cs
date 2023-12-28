using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
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

public class LolDataDragon : ILolDataDragon
{
    static Uri VersionsUri = new("api/versions.json", UriKind.Relative);

    readonly HttpClient _client = new()
    {
        BaseAddress = new Uri("https://ddragon.leagueoflegends.com")
    };
    private readonly IDistributedCache _distributedCache;
    private readonly ILogger<LolDataDragon> _logger;
    private readonly IOptions<LolDataDragonOptions> _options;

    /// <summary>
    /// Initializes a new instance of the <see cref="LolDataDragon"/> class.
    /// </summary>
    public LolDataDragon(IOptions<LolDataDragonOptions> options, IDistributedCache? distributedCache = null, ILogger<LolDataDragon>? logger = null)
    {
        _options = options;
        _distributedCache = distributedCache ?? NullDistributedCache.Instance;
        _logger = logger ?? NullLogger<LolDataDragon>.Instance;
    }

    private async ValueTask<T> GetAsync<T>(string requestUri, JsonTypeInfo<T> jsonTypeInfo, CancellationToken cancellationToken)
    {
        var data = await _distributedCache.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);
        if (data is null)
        {
            data = await _client.GetByteArrayAsync(requestUri, cancellationToken).ConfigureAwait(false);
            await _distributedCache.SetAsync(requestUri, data, _options.Value.DistributedCacheEntryOptions, cancellationToken).ConfigureAwait(false);
        }
        return JsonSerializer.Deserialize(data, jsonTypeInfo)!;
    }

    /// <inheritdoc/>
    public async Task<string[]> GetVersionsAsync(CancellationToken cancellationToken)
    {
        var versions = await _client.GetFromJsonAsync(VersionsUri, DDJsonContext.Default.StringArray, cancellationToken).ConfigureAwait(false);
        return versions!;
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, MapDto>> GetMapsAsync(string version, string language, CancellationToken cancellationToken)
    {
        var uri = $"cdn/{version}/data/{language}/map.json";
        var maps = await GetAsync(uri, DDJsonContext.Default.RootDtoMapDto, cancellationToken);
        return maps.Data;
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, ProfileIconDto>> GetProfileIconsAsync(string version, string language, CancellationToken cancellationToken)
    {
        var uri = $"cdn/{version}/data/{language}/profileicon.json";
        var profileIcons = await GetAsync(uri, DDJsonContext.Default.RootDtoProfileIconDto, cancellationToken).ConfigureAwait(false);
        return profileIcons.Data;
    }

    /// <inheritdoc/>
    public async Task<RuneReforgedDto[]> GetRunesReforgedAsync(string version, string language, CancellationToken cancellationToken)
    {
        var uri = $"cdn/{version}/data/{language}/runesReforged.json";
        var runesReforged = await GetAsync(uri, DDJsonContext.Default.RuneReforgedDtoArray, cancellationToken).ConfigureAwait(false);
        return runesReforged;
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, SummonerSpellDto>> GetSummonerSpellsAsync(string version, string language, CancellationToken cancellationToken)
    {
        var uri = $"cdn/{version}/data/{language}/summoner.json";
        var summonerSpell = await GetAsync(uri, DDJsonContext.Default.RootDtoSummonerSpellDto, cancellationToken).ConfigureAwait(false);
        return summonerSpell.Data;
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, ItemDto>> GetItemsAsync(string version, string language, CancellationToken cancellationToken)
    {
        var uri = $"cdn/{version}/data/{language}/item.json";
        var items = await GetAsync(uri, DDJsonContext.Default.RootDtoItemDto, cancellationToken).ConfigureAwait(false);
        return items.Data;
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, ChampionBaseDto>> GetAllChampionsBaseAsync(string version, string language, CancellationToken cancellationToken)
    {
        var uri = $"cdn/{version}/data/{language}/champion.json";
        var champions = await GetAsync(uri, DDJsonContext.Default.RootDtoChampionBaseDto, cancellationToken).ConfigureAwait(false);
        return champions.Data;
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, ChampionDto>> GetAllChampionsAsync(string version, string language, CancellationToken cancellationToken)
    {
        var uri = $"cdn/{version}/data/{language}/championFull.json";
        var champions = await GetAsync(uri, DDJsonContext.Default.RootDtoChampionDto, cancellationToken).ConfigureAwait(false);
        return champions.Data;
    }

    /// <inheritdoc/>
    public async Task<ChallengeDto[]> GetChallengesAsync(string version, string language, CancellationToken cancellationToken)
    {
        var uri = $"cdn/{version}/data/{language}/challenges.json";
        var challenges = await GetAsync(uri, DDJsonContext.Default.ChallengeDtoArray, cancellationToken).ConfigureAwait(false);
        return challenges;
    }
}
