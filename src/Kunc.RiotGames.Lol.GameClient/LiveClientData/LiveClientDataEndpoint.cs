using System.Net.Http.Json;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

/// <inheritdoc cref="ILiveClientData"/>
public class LiveClientDataEndpoint : ILiveClientData
{
    private readonly HttpClient _client = new(
        new HttpClientHandler()
        {
            // todo corect ServerCertificateCustomValidationCallback
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator 
        })
    {
        BaseAddress = new Uri("https://127.0.0.1:2999")
    };
    
    /// <inheritdoc/> 
    public async Task<AllGameData> GetAllGameDataAsync(int? eventID = null, CancellationToken cancellationToken = default)
    {
        var query = eventID is not null
            ? $"?{nameof(eventID)}={eventID}"
            : string.Empty;
        var obj = await _client.GetFromJsonAsync<AllGameData>("/liveclientdata/allgamedata" + query, cancellationToken);
        return obj!;
    }

    /// <inheritdoc/>
    public async Task<ActivePlayer> GeActivePlayerAsync(CancellationToken cancellationToken = default)
    {
        var obj = await _client.GetFromJsonAsync<ActivePlayer>("/liveclientdata/activeplayer", cancellationToken);
        return obj!;
    }

    /// <inheritdoc/>
    public async Task<string> GetSummonerNameAsync(CancellationToken cancellationToken = default)
    {
        var obj = await _client.GetStringAsync("/liveclientdata/activeplayername", cancellationToken);
        return obj!;
    }

    /// <inheritdoc/>
    public async Task<Abilities> GetActivePlayerAbilitiesAsync(CancellationToken cancellationToken = default)
    {
        var obj = await _client.GetFromJsonAsync<Abilities>("/liveclientdata/activeplayerabilities", cancellationToken);
        return obj!;
    }

    /// <inheritdoc/>
    public async Task<FullRunes> GetActivePlayerRunesAsync(CancellationToken cancellationToken = default)
    {
        var obj = await _client.GetFromJsonAsync<FullRunes>("/liveclientdata/activeplayerrunes", cancellationToken);
        return obj!;
    }

    /// <inheritdoc/>
    public async Task<Player[]> GetAllPlayersAsync(string? teamID = null, CancellationToken cancellationToken = default)
    {
        var query = teamID is not null
            ? $"?{nameof(teamID)}={teamID}"
            : string.Empty;
        var obj = await _client.GetFromJsonAsync<Player[]>("/liveclientdata/playerlist" + query, cancellationToken);
        return obj!;
    }

    /// <inheritdoc/>
    public async Task<SummonerSpells> GetPlayerSummonerSpellsAsync(string summonerName, CancellationToken cancellationToken = default)
    {
        var obj = await _client.GetFromJsonAsync<SummonerSpells>($"/liveclientdata/playersummonerspells?summonerName={summonerName}", cancellationToken);
        return obj!;
    }

    /// <inheritdoc/>
    public async Task<Scores> GetPlayerScoreAsync(string summonerName, CancellationToken cancellationToken = default)
    {
        var obj = await _client.GetFromJsonAsync<Scores>($"/liveclientdata/playerscores?summonerName={summonerName}", cancellationToken);
        return obj!;
    }

    /// <inheritdoc/>
    public async Task<Runes> GetPayerMainRunesAsync(string summonerName, CancellationToken cancellationToken = default)
    {
        var obj = await _client.GetFromJsonAsync<Runes>($"/liveclientdata/playermainrunes?summonerName={summonerName}", cancellationToken);
        return obj!;
    }

    /// <inheritdoc/>
    public async Task<Item[]> GetPlayerItemsAsync(string summonerName, CancellationToken cancellationToken = default)
    {
        var obj = await _client.GetFromJsonAsync<Item[]>($"/liveclientdata/playeritems?summonerName={summonerName}", cancellationToken);
        return obj!;
    }

    /// <inheritdoc/>
    public async Task<EventData> GetEventDataAsync(int? eventID = null, CancellationToken cancellationToken = default)
    {
        var query = eventID is not null
            ? $"?{nameof(eventID)}={eventID}"
            : string.Empty;
        var obj = await _client.GetFromJsonAsync<EventData>("/liveclientdata/eventdata" + query, cancellationToken);
        return obj!;
    }

    /// <inheritdoc/>
    public async Task<GameData> GetGameStatsAsync(CancellationToken cancellationToken = default)
    {
        var obj = await _client.GetFromJsonAsync<GameData>("/liveclientdata/gamestats", cancellationToken);
        return obj!;
    }
}
