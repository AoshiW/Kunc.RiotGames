using System.Diagnostics.CodeAnalysis;
using System.Net.WebSockets;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

public sealed partial class Wamp : IWamp
{
    /// <inheritdoc/>
    public event EventHandler<JsonElement[]>? OnMessage;
    
    /// <inheritdoc/>
    public event EventHandler? OnDisconnect;
    
    /// <inheritdoc/>
    public event EventHandler? OnConnect;
    
    /// <inheritdoc/>
    public event EventHandler<Exception>? OnMessageException;

    /// <inheritdoc/>
    [MemberNotNullWhen(true, nameof(_socket), nameof(_cancellationTokenSource))]
    public bool IsConnected => _socket?.State == WebSocketState.Open;

    private ClientWebSocket? _socket;
    private CancellationTokenSource? _cancellationTokenSource;
    private Task _eventLoopTask = Task.CompletedTask;
    private readonly ILogger<Wamp> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="LolLeagueClientUpdate"/> class.
    /// </summary>
    public Wamp(ILogger<Wamp> logger)
    {
        _logger = logger;
    }

    private async Task EventLoop()
    {
        if (!IsConnected)
            return;
        _cancellationTokenSource = new();
        var cancellationToken = _cancellationTokenSource.Token;
        var buffer = new byte[4 * 1024];
        var memorBuffer = new Memory<byte>(buffer);
        var memoryStream = new MemoryStream();
        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                switch (_socket.State)
                {
                    case WebSocketState.Open:
                        var received = await _socket.ReceiveAsync(memorBuffer, cancellationToken).ConfigureAwait(false);
                        if (received.MessageType == WebSocketMessageType.Close)
                            break;
                        if (received.EndOfMessage && memoryStream.Position == 0)
                        {
                            LogFullMessageReceived(received.Count);
                            var data = JsonSerializer.Deserialize<JsonElement[]>(buffer.AsSpan(0, received.Count))!;
                            OnMessage?.Invoke(this, data);
                            break;
                        }
                        memoryStream.Write(buffer, 0, received.Count);
                        if (received.EndOfMessage)
                        {
                            LogFullMessageReceived(memoryStream.Position);
                            var memmoryBuffer = memoryStream.GetBuffer();
                            var data = JsonSerializer.Deserialize<JsonElement[]>((memmoryBuffer.AsSpan(0, (int)memoryStream.Position))!;
                            OnMessage?.Invoke(this, data);
                            memoryStream.SetLength(0);
                        }
                        break;
                    case WebSocketState.Closed or WebSocketState.Aborted:
                        _cancellationTokenSource.Cancel();
                        break;
                    default:
                        break;
                }
            }
            catch (TaskCanceledException)
            { /* NOP */ }
            catch (Exception ex)
            {
                LogEventLoopException(ex);
                OnMessageException?.Invoke(this, ex);
            }
        }
        LogDisconnected();
        OnDisconnect?.Invoke(this, EventArgs.Empty);
    }

    /// <inheritdoc/>
    public async Task ConnectAsync(Lockfile lockfile, CancellationToken token)
    {
        if(IsConnected)
        {
            throw new InvalidOperationException("WAMP is already connected.");
        }
        _socket = new();
        _socket.Options.AddSubProtocol("wamp");
#pragma warning disable CA5359 // Do Not Disable Certificate Validation
        _socket.Options.RemoteCertificateValidationCallback = static (_, _, _, _) => true;
#pragma warning restore CA5359 // Do Not Disable Certificate Validation
        _socket.Options.Credentials = lockfile.ToCredential();
        await _socket.ConnectAsync(new Uri($"wss://127.0.0.1:{lockfile.Port}"), token).ConfigureAwait(false);
        OnConnect?.Invoke(this, EventArgs.Empty);
        LogConnected();
        _eventLoopTask = EventLoop();
    }

    /// <inheritdoc/>
    public ValueTask SendAsync(ReadOnlyMemory<byte> buffer, WebSocketMessageType msgType, CancellationToken token)
    {
        return IsConnected
            ? _socket.SendAsync(buffer, msgType, true, token)
            : throw new InvalidOperationException("Wamp isn't connected.");
    }

    /// <inheritdoc/>
    public async Task CloseAsync(CancellationToken token)
    {
        if (!IsConnected)
        {
            return;
        }
        try
        {
            await _socket.CloseAsync(WebSocketCloseStatus.NormalClosure, null, token).ConfigureAwait(false);
        }
        catch (OperationCanceledException)
        { /* NOP */ }
        Dispose();
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        _cancellationTokenSource?.Cancel();
        _cancellationTokenSource?.Dispose();
        _cancellationTokenSource = null;

        _socket?.Dispose();
        _socket = null;
    }
}
