using System.Net.WebSockets;
using System.Text.Json;

namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

public interface IWamp : IDisposable
{
    event EventHandler<JsonElement[]>? OnMessage;
    event EventHandler? OnDisconnect;
    event EventHandler? OnConnect;
    event EventHandler<Exception>? OnMessageException;

    bool IsConnected { get; }

    Task ConnectAsync(Lockfile lockfile, CancellationToken token);
    public ValueTask SendAsync(ReadOnlyMemory<byte> buffer, WebSocketMessageType msgType, CancellationToken token);
    Task CloseAsync(CancellationToken token);
}
