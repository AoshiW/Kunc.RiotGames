using System.Net.Http.Json;

namespace Kunc.RiotGames.Lor.GameClient;

/// <inheritdoc cref="ILorGameClient"/>
public class LorGameClient : ILorGameClient
{
    private readonly HttpClient _client = new();

    /// <inheritdoc/>
    public int Port
    {
        get => _client.BaseAddress!.Port;
        set => _client.BaseAddress = new($"http://127.0.0.1:{value}");
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="LorGameClient"/> class.
    /// </summary>
    /// <param name="port"></param>
    public LorGameClient(int port = 21337)
    {
        Port = port;
    }

    /// <inheritdoc/>
    public async Task<StaticDecklist> GetStaticDecklistAsync(CancellationToken cancellationToken = default)
    {
        var obj = await _client.GetFromJsonAsync<StaticDecklist>("static-decklist", cancellationToken).ConfigureAwait(false);
        return obj!;
    }

    /// <inheritdoc/>
    public async Task<PositionalRectangles> GetPositionalRectanglesAsync(CancellationToken cancellationToken = default)
    {
        var obj = await _client.GetFromJsonAsync<PositionalRectangles>("positional-rectangles", cancellationToken).ConfigureAwait(false);
        return obj!;
    }

    /// <inheritdoc/>
    public async Task<GameResult> GetGameResultAsync(CancellationToken cancellationToken = default)
    {
        var obj = await _client.GetFromJsonAsync<GameResult>("game-result", cancellationToken).ConfigureAwait(false);
        return obj!;
    }
}
