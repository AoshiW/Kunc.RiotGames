using System.Net.Http.Json;
using Kunc.RiotGames.Lol.DataDragon.Challenge;
using Kunc.RiotGames.Lol.DataDragon.Champion;
using Kunc.RiotGames.Lol.DataDragon.Item;
using Kunc.RiotGames.Lol.DataDragon.Map;
using Kunc.RiotGames.Lol.DataDragon.ProfileIcon;
using Kunc.RiotGames.Lol.DataDragon.RuneReforged;
using Kunc.RiotGames.Lol.DataDragon.SummonerSpell;

namespace Kunc.RiotGames.Lol.DataDragon;

public class LolDataDragon
{
    static Uri VersionsUri = new("api/versions.json");

    readonly HttpClient _client = new()
    {
        BaseAddress = new Uri("https://ddragon.leagueoflegends.com")
    };

    /// <inheritdoc/>
    public async Task<string[]> GetVersionsAsync(CancellationToken cancellationToken)
    {
        return await _client.GetFromJsonAsync(VersionsUri, DDJsonContext.Default.StringArray, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, MapDto>> GetMapsAsync(string version, string language, CancellationToken cancellationToken)
    {
        var data = await _client.GetFromJsonAsync($"cdn/{version}/data/{language}/map.json", DDJsonContext.Default.RootDtoMapDto, cancellationToken).ConfigureAwait(false);
        return data.Data;
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, ProfileIconDto>> GetProfileIconsAsync(string version, string language, CancellationToken cancellationToken)
    {
        var data = await _client.GetFromJsonAsync($"cdn/{version}/data/{language}/profileicon.json", DDJsonContext.Default.RootDtoProfileIconDto, cancellationToken).ConfigureAwait(false);
        return data.Data;
    }

    /// <inheritdoc/>
    public async Task<RuneReforgedDto[]> GetRunesReforgedAsync(string version, string language, CancellationToken cancellationToken)
    {
        var data = await _client.GetFromJsonAsync($"cdn/{version}/data/{language}/runesReforged.json", DDJsonContext.Default.RuneReforgedDtoArray, cancellationToken).ConfigureAwait(false);
        return data;
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, SummonerSpellDto>> GetSummonerSpellsAsync(string version, string language, CancellationToken cancellationToken)
    {
        var data = await _client.GetFromJsonAsync($"cdn/{version}/data/{language}/summoner.json", DDJsonContext.Default.RootDtoSummonerSpellDto, cancellationToken).ConfigureAwait(false);
        return data.Data;
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, ItemDto>> GetItemsAsync(string version, string language, CancellationToken cancellationToken)
    {
        var data = await _client.GetFromJsonAsync($"cdn/{version}/data/{language}/item.json", DDJsonContext.Default.RootDtoItemDto, cancellationToken).ConfigureAwait(false);
        return data.Data;
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, ChampionBaseDto>> GetAllChampionsBaseAsync(string version, string language, CancellationToken cancellationToken)
    {
        var data = await _client.GetFromJsonAsync($"cdn/{version}/data/{language}/champion.json", DDJsonContext.Default.RootDtoChampionBaseDto, cancellationToken).ConfigureAwait(false);
        return data.Data;
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, ChampionDto>> GetAllChampionsAsync(string version, string language, CancellationToken cancellationToken)
    {
        var data = await _client.GetFromJsonAsync($"cdn/{version}/data/{language}/championFull.json", DDJsonContext.Default.RootDtoChampionDto, cancellationToken).ConfigureAwait(false);
        return data.Data;
    }

    /// <inheritdoc/>
    public async Task<ChallengeDto[]> GetchallengesAsync(string version, string language, CancellationToken cancellationToken)
    {
        var data = await _client.GetFromJsonAsync($"cdn/{version}/data/{language}/challenges.json", DDJsonContext.Default.ChallengeDtoArray, cancellationToken).ConfigureAwait(false);
        return data;
    }
}
