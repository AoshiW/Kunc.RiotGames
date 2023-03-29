using System.Net.WebSockets;
using System.Text.Json;

namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

sealed class Wamp : IDisposable
{
    public event EventHandler<JsonElement[]>? OnMessage;
    public event EventHandler? OnDisconnect;
    public event EventHandler? OnConnect;
    public event EventHandler<Exception>? OnMessageError;

    private ClientWebSocket? _socket;
    private Task _eventLoopTask = Task.CompletedTask;
    private CancellationTokenSource? _cancellationTokenSource;
    private readonly LolLeagueClientUpdate _lolLeagueClientUpdate;

    public Wamp(LolLeagueClientUpdate lolLeagueClientUpdate)
    {
        _lolLeagueClientUpdate = lolLeagueClientUpdate;
    }

    private async Task EventLoop()
    {
        _cancellationTokenSource = new();
        var cancellationToken = _cancellationTokenSource.Token;
        var buffer = new byte[4 * 1024];
        var memorBuffer = new Memory<byte>(buffer);
        var memoryStream = new MemoryStream();
        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                switch (_socket!.State)
                {
                    case WebSocketState.Open:
                        var received = await _socket!.ReceiveAsync(memorBuffer, cancellationToken).ConfigureAwait(false);
                        memoryStream.Write(buffer, 0, received.Count);
                        if (received.EndOfMessage)
                        {
                            memoryStream.Position = 0;
                            var data = JsonSerializer.Deserialize<JsonElement[]>(memoryStream)!;
                            OnMessage?.Invoke(_lolLeagueClientUpdate, data);
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
            catch (Exception e)
            {
                OnMessageError?.Invoke(_lolLeagueClientUpdate, e);
            }
        }
        OnDisconnect?.Invoke(this, EventArgs.Empty);
    }

    public async Task ConnectAsync(Lockfile lockfile, CancellationToken token)
    {
        _socket = new();
        _socket.Options.AddSubProtocol("wamp");
#pragma warning disable CA5359 // Do Not Disable Certificate Validation
        _socket.Options.RemoteCertificateValidationCallback = static (_, _, _, _) => true;
#pragma warning restore CA5359 // Do Not Disable Certificate Validation
        _socket.Options.Credentials = lockfile.ToCredential();
        await _socket.ConnectAsync(new Uri($"wss://127.0.0.1:{lockfile.Port}"), token).ConfigureAwait(false);
        OnConnect?.Invoke(_lolLeagueClientUpdate, EventArgs.Empty);
        _eventLoopTask = EventLoop();
    }

    public ValueTask SendAsync(ReadOnlyMemory<byte> buffer, WebSocketMessageType msgType, CancellationToken token)
    {
        return _socket!.SendAsync(buffer, msgType, true, token);
    }

    public async Task CloseAsync(CancellationToken token)
    {
        _cancellationTokenSource?.Cancel();
        try
        {
            if (_socket is not null)
            {
                await _eventLoopTask.ConfigureAwait(false);
                await _socket!.CloseAsync(WebSocketCloseStatus.NormalClosure, null, token).ConfigureAwait(false);
            }
        }
        catch (OperationCanceledException)
        { }
    }

    public void Dispose()
    {
        _cancellationTokenSource?.Cancel();
        _cancellationTokenSource?.Dispose();
        _socket?.Dispose();
    }
}
