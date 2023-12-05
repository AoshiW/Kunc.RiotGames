using System.Net.Http.Json;

namespace Kunc.RiotGames.Lor.GameClient;

/// <inheritdoc cref="ILorGameClient"/>
public class LorGameClient : ILorGameClient, IDisposable
{
    private static readonly Uri StaticDecklistUri = new("static-decklist");
    private static readonly Uri PositionalRectanglesUri = new("positional-rectangles");
    private static readonly Uri GameResultUri = new("game-result");

    private readonly HttpClient _client = new();
    private bool _disposed;

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
        var decklist = await _client.GetFromJsonAsync(StaticDecklistUri, JsonContext.Default.StaticDecklist, cancellationToken).ConfigureAwait(false);
        return decklist!;
    }

    /// <inheritdoc/>
    public async Task<PositionalRectangles> GetPositionalRectanglesAsync(CancellationToken cancellationToken = default)
    {
        var positionalRectangles = await _client.GetFromJsonAsync(PositionalRectanglesUri, JsonContext.Default.PositionalRectangles, cancellationToken).ConfigureAwait(false);
        return positionalRectangles!;
    }

    /// <inheritdoc/>
    public async Task<GameResult> GetGameResultAsync(CancellationToken cancellationToken = default)
    {
        var gameResult = await _client.GetFromJsonAsync(GameResultUri, JsonContext.Default.GameResult, cancellationToken).ConfigureAwait(false);
        return gameResult!;
    }

    /// <summary>
    /// Releases the unmanaged resources used by the System.Net.Http.HttpClient and optionally disposes of the managed resources.
    /// </summary>
    /// <param name="disposing">
    /// <see langword="true"/> to release both managed and unmanaged resources;
    /// <see langword="false"/> to releases only unmanaged resources.
    /// </param>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _client.Dispose();
                _disposed = true;
            }
            _disposed = true;
        }
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
