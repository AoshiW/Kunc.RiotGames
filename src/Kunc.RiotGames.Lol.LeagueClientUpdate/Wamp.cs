using System.Net.WebSockets;
using System.Text.Json;

namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

public sealed class Wamp
{
    public event Action<JsonElement[]>? OnMessage;
    public event Action? OnDisconnect;
    public event Action<Exception>? OnMessageError;
    
    private ClientWebSocket? _socket;
    private Task _eventLoopTask = Task.CompletedTask;
    private CancellationTokenSource? _cancellationTokenSource;
    
    private async Task EventLoop()
    {
        _cancellationTokenSource = new();
        var cancellationToken = _cancellationTokenSource.Token;
        var buffer = new byte[2048];
        var memorBuffer = new Memory<byte>(buffer);
        var memoryStream = new MemoryStream();
        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                switch (_socket!.State)
                {
                    case WebSocketState.Open:
                        var received = await _socket!.ReceiveAsync(memorBuffer, cancellationToken);
                        memoryStream.Write(buffer, 0, received.Count);
                        if (received.EndOfMessage)
                        {
                            memoryStream.Position = 0;
                            var data = JsonSerializer.Deserialize<JsonElement[]>(memoryStream)!;
                            OnMessage?.Invoke(data);
                            memoryStream.SetLength(0);
                        }
                        break;
                    case WebSocketState.Closed or WebSocketState.Aborted:
                        try
                        {
                            _cancellationTokenSource.Cancel();
                            _socket = null;
                            OnDisconnect?.Invoke();
                        }
                        catch { }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                OnMessageError?.Invoke(e);
            }
        }
    }

    public async Task ConnectAsync(Lockfile lockfile, CancellationToken token)
    {
        if (_socket is not null)
            throw new InvalidOperationException();
        _socket = new();
        _socket.Options.AddSubProtocol("wamp");
        _socket.Options.RemoteCertificateValidationCallback = (_, _, _, _) => true;
        _socket.Options.Credentials = lockfile.ToCredential();
        await _socket.ConnectAsync(new($"wss://127.0.0.1:{lockfile.Port}"), token);
        _eventLoopTask = EventLoop();
    }

    public ValueTask SendAsync(ReadOnlyMemory<byte> buffer, WebSocketMessageType msgType, CancellationToken token)
    {
        return _socket is not null
            ? _socket.SendAsync(buffer, msgType, true, token)
            : throw new InvalidOperationException();
    }

    public async Task CloseAsync(CancellationToken token)
    {
        _cancellationTokenSource?.Cancel();
        try
        {
            if (_socket is not null)
            {
                await _eventLoopTask;
                await _socket!.CloseAsync(WebSocketCloseStatus.NormalClosure, null, token);
            }
            _socket = null;
        }
        catch (OperationCanceledException)
        { }
    }
}
