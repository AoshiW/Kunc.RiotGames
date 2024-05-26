﻿using System.Net.Http.Json;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

public class LiveClientDataEndpoint : ILiveClientData
{
    private readonly HttpClient _client = new(new HttpClientHandler()
    {
        ClientCertificateOptions = ClientCertificateOption.Manual,
        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator,
    })
    {
        BaseAddress = new("https://127.0.0.1:2999"),
    };

    /// <inheritdoc/>
    public async Task<AllGameDataDto> GetAllGameDataAsync(int? eventId = null, CancellationToken cancellationToken = default)
    {
        var url = "/liveclientdata/allgamedata";
        if (eventId.HasValue)
            url += $"teamID={eventId.Value}";
        var data = await _client.GetFromJsonAsync<AllGameDataDto>(url, cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <inheritdoc/>
    public async Task<ActivePlayerDto> GetActivePlayerAsync(CancellationToken cancellationToken = default)
    {
        var data = await _client.GetFromJsonAsync<ActivePlayerDto>("/liveclientdata/activeplayer", cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <inheritdoc/>
    public async Task<RiotId> GetActivePlayerNameAsync(CancellationToken cancellationToken = default)
    {
        var data = await _client.GetFromJsonAsync<RiotId>("/liveclientdata/activeplayername", cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <inheritdoc/>
    public async Task<AbilitiesDto> GetActivePlayerAbilitiesAsync(CancellationToken cancellationToken = default)
    {
        var data = await _client.GetFromJsonAsync<AbilitiesDto>("/liveclientdata/activeplayerabilities", cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <inheritdoc/>
    public async Task<FullRunesDto> GetActivePlayerRunesAsync(CancellationToken cancellationToken = default)
    {
        var data = await _client.GetFromJsonAsync<FullRunesDto>("/liveclientdata/activeplayerrunes", cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <inheritdoc/>
    public async Task<PlayerDto[]> GetPlayerListAsync(TeamId? teamId = null, CancellationToken cancellationToken = default)
    {
        var url = "/liveclientdata/playerlist";
        if (teamId.HasValue)
            url += $"teamID={teamId.Value}";
        var data = await _client.GetFromJsonAsync<PlayerDto[]>(url, cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <inheritdoc/>
    public async Task<PlayerScoresDto> GetPlayerScoresAsync(RiotId riotId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(riotId);
        var data = await _client.GetFromJsonAsync<PlayerScoresDto>($"/liveclientdata/playerscores?riotId={riotId}", cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <inheritdoc/>
    public async Task<SummonerSpellsDto> GetPlayerSummonerSpellsAsync(RiotId riotId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(riotId);
        var data = await _client.GetFromJsonAsync<SummonerSpellsDto>($"/liveclientdata/playersummonerspells?riotId={riotId}", cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <inheritdoc/>
    public async Task<MainRunesDto> GetPlayerMainRunesAsync(RiotId riotId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(riotId);
        var data = await _client.GetFromJsonAsync<MainRunesDto>($"/liveclientdata/playermainrunes?riotId={riotId}", cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <inheritdoc/>
    public async Task<PlayerItemDto[]> GetPlayerItemsAsync(RiotId riotId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(riotId);
        var data = await _client.GetFromJsonAsync<PlayerItemDto[]>($"/liveclientdata/playeritems?riotId={riotId}", cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <inheritdoc/>
    public async Task<EventDataDto> GetEventDataAsync(int? eventId = null, CancellationToken cancellationToken = default)
    {
        var url = "/liveclientdata/eventdata";
        if (eventId.HasValue)
            url += $"teamID={eventId.Value}";
        var data = await _client.GetFromJsonAsync<EventDataDto>(url, cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <inheritdoc/>
    public async Task<GameStatsDto> GetGameStatsAsync(CancellationToken cancellationToken = default)
    {
        var data = await _client.GetFromJsonAsync<GameStatsDto>("/liveclientdata/gamestats", cancellationToken).ConfigureAwait(false);
        return data!;
    }
}
