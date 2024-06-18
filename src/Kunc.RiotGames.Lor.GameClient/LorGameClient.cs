using System.Net.Http.Json;
using Microsoft.Extensions.Options;

namespace Kunc.RiotGames.Lor.GameClient;

/// <inheritdoc cref="ILorGameClient"/>
public partial class LorGameClient : ILorGameClient
{
    private static readonly Uri StaticDecklistUri = new("static-decklist");
    private static readonly Uri PositionalRectanglesUri = new("positional-rectangles");
    private static readonly Uri GameResultUri = new("game-result");

    private readonly HttpClient _client = new();
    private readonly LorGameClientOptions _options;
    private bool _disposedValue;

    /// <summary>
    /// Initializes a new instance of the <see cref="LorGameClient"/> class.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    public LorGameClient(IOptions<LorGameClientOptions> options)
    {
        ArgumentNullException.ThrowIfNull(options);
        _options = options.Value;
        _client.BaseAddress = new($"http://127.0.0.1:{_options.Port}");
    }

    /// <inheritdoc/>
    public async Task<StaticDecklist> GetStaticDecklistAsync(CancellationToken cancellationToken = default)
    {
        ObjectDisposedException.ThrowIf(_disposedValue, this);
        var decklist = await _client.GetFromJsonAsync<StaticDecklist>(StaticDecklistUri, _options.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
        return decklist!;
    }

    /// <inheritdoc/>
    public async Task<PositionalRectangles> GetPositionalRectanglesAsync(CancellationToken cancellationToken = default)
    {
        ObjectDisposedException.ThrowIf(_disposedValue, this);
        var positionalRectangles = await _client.GetFromJsonAsync<PositionalRectangles>(PositionalRectanglesUri, _options.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
        return positionalRectangles!;
    }

    /// <inheritdoc/>
    public async Task<GameResult> GetGameResultAsync(CancellationToken cancellationToken = default)
    {
        ObjectDisposedException.ThrowIf(_disposedValue, this);
        var gameResult = await _client.GetFromJsonAsync<GameResult>(GameResultUri, _options.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
        return gameResult!;
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
