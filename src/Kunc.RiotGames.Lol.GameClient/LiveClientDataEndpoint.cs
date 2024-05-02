using System.Net.Http.Json;
using Kunc.RiotGames.Lol.GameClient.LiveClientData;

namespace Kunc.RiotGames.Lol.GameClient;

public class LiveClientDataEndpoint
{
    private readonly HttpClient _client = new()
    {
        BaseAddress = new("https://127.0.0.1:2999"),
    };

    /// <summary>
    /// Get all available data.
    /// </summary>
    /// <param name="eventId">ID of the next event you expect to see.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<AllGameDataDto> GetAllGameDataAsync(int? eventId = null, CancellationToken cancellationToken = default)
    {
        var url = "/liveclientdata/allgamedata";
        if (eventId.HasValue)
            url += $"teamID={eventId.Value}";
        var data = await _client.GetFromJsonAsync<AllGameDataDto>(url, cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <summary>
    /// Get all data about the active player.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ActivePlayerDto> GetActivePlayerAsync(CancellationToken cancellationToken = default)
    {
        var data = await _client.GetFromJsonAsync<ActivePlayerDto>("/liveclientdata/activeplayer", cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <summary>
    /// Returns the player name
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<RiotId> GetActivePlayerNameAsync(CancellationToken cancellationToken = default)
    {
        var data = await _client.GetFromJsonAsync<RiotId>("/liveclientdata/activeplayername", cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <summary>
    /// Get Abilities for the active player.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<AbilitiesDto> GetActivePlayerAbilitiesAsync(CancellationToken cancellationToken = default)
    {
        var data = await _client.GetFromJsonAsync<AbilitiesDto>("/liveclientdata/activeplayerabilities", cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <summary>
    /// Retrieve the full list of runes for the active player.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<FullRunesDto> GetActivePlayerRunesAsync(CancellationToken cancellationToken = default)
    {
        var data = await _client.GetFromJsonAsync<FullRunesDto>("/liveclientdata/activeplayerrunes", cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <summary>
    /// Retrieve the list of heroes in the game and their stats.
    /// </summary>
    /// <param name="teamId">Heroes team ID</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<PlayerDto[]> GetPlayerListAsync(TeamId? teamId = null, CancellationToken cancellationToken = default)
    {
        var url = "/liveclientdata/playerlist";
        if (teamId.HasValue)
            url += $"teamID={teamId.Value}";
        var data = await _client.GetFromJsonAsync<PlayerDto[]>(url, cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <summary>
    /// Retrieve the list of the current scores for the player.
    /// </summary>
    /// <param name="summonerName">Summoner name of player.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// 
    public async Task<PlayerScoresDto> GetPlayerScoresAsync(string summonerName, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(summonerName);
        var data = await _client.GetFromJsonAsync<PlayerScoresDto>($"/liveclientdata/playerscores?summonerName={summonerName}", cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <summary>
    /// Retrieve the list of the summoner spells for the player.
    /// </summary>
    /// <param name="summonerName">Summoner name of player.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<SummonerSpellsDto> GetPlayerSummonerSpellsAsync(string summonerName, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(summonerName);
        var data = await _client.GetFromJsonAsync<SummonerSpellsDto>($"/liveclientdata/playersummonerspells?summonerName={summonerName}", cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <summary>
    /// Retrieve the basic runes of any player.
    /// </summary>
    /// <param name="summonerName">Summoner name of player.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<MainRunesDto> GetPlayerMainRunesAsync(string summonerName, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(summonerName);
        var data = await _client.GetFromJsonAsync<MainRunesDto>($"/liveclientdata/playermainrunes?summonerName={summonerName}", cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <summary>
    /// Retrieve the list of items for the player.
    /// </summary>
    /// <param name="summonerName">Summoner name of player.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<PlayerItemDto[]> GetPlayerItemsAsync(string summonerName, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(summonerName);
        var data = await _client.GetFromJsonAsync<PlayerItemDto[]>($"/liveclientdata/playeritems?summonerName={summonerName}", cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <summary>
    /// Get a list of events that have occurred in the game.
    /// </summary>
    /// <param name="eventId">ID of the next event you expect to see.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<EventDataDto> GetEventDataAsync(int? eventId = null, CancellationToken cancellationToken = default)
    {
        var url = "/liveclientdata/eventdata";
        if (eventId.HasValue)
            url += $"teamID={eventId.Value}";
        var data = await _client.GetFromJsonAsync<EventDataDto>(url, cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <summary>
    /// Get basic data about the game.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GameStatsDto> GetGameStatsAsync(CancellationToken cancellationToken = default)
    {
        var data = await _client.GetFromJsonAsync<GameStatsDto>("/liveclientdata/gamestats", cancellationToken).ConfigureAwait(false);
        return data!;
    }
}
