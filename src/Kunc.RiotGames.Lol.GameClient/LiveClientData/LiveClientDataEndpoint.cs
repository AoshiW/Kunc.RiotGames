using System.Net.Http.Json;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

public class LiveClientDataEndpoint
{
    private readonly HttpClient _client = new(new HttpClientHandler()
    {
        ClientCertificateOptions = ClientCertificateOption.Manual,
        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator,
    })
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
    /// Returns the player RiotId.
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
    /// <param name="riotId">RiotID GameName (with tag) of the player.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// 
    public async Task<PlayerScoresDto> GetPlayerScoresAsync(RiotId riotId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(riotId);
        var data = await _client.GetFromJsonAsync<PlayerScoresDto>($"/liveclientdata/playerscores?riotId={riotId}", cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <summary>
    /// Retrieve the list of the summoner spells for the player.
    /// </summary>
    /// <param name="riotId">RiotID GameName (with tag) of the player.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<SummonerSpellsDto> GetPlayerSummonerSpellsAsync(RiotId riotId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(riotId);
        var data = await _client.GetFromJsonAsync<SummonerSpellsDto>($"/liveclientdata/playersummonerspells?riotId={riotId}", cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <summary>
    /// Retrieve the basic runes of any player.
    /// </summary>
    /// <param name="riotId">RiotID GameName (with tag) of the player.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<MainRunesDto> GetPlayerMainRunesAsync(RiotId riotId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(riotId);
        var data = await _client.GetFromJsonAsync<MainRunesDto>($"/liveclientdata/playermainrunes?riotId={riotId}", cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <summary>
    /// Retrieve the list of items for the player.
    /// </summary>
    /// <param name="riotId">RiotID GameName (with tag) of the player.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<PlayerItemDto[]> GetPlayerItemsAsync(RiotId riotId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(riotId);
        var data = await _client.GetFromJsonAsync<PlayerItemDto[]>($"/liveclientdata/playeritems?riotId={riotId}", cancellationToken).ConfigureAwait(false);
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
