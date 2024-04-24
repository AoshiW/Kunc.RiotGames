using System.Net.WebSockets;
using System.Text.Json;

namespace Kunc.RiotGames.Lol.LeagueClientUpdate.Tests;

class NullWamp : IWamp
{
    public bool IsConnected => true;

    public event EventHandler<JsonElement[]>? OnMessage;
    public event EventHandler? OnDisconnect;
    public event EventHandler? OnConnect;
    public event EventHandler<Exception>? OnMessageException;

    public void InvokeOnMessage<T>(LcuEventArgs<T> eventArgs)
    {
        var data = new object[]
        {
            8,
            "OnJsonApiEvent",
            eventArgs
        };
        var json = JsonSerializer.Serialize(data);
        InvokeOnMessage(json);
    }

    public void InvokeOnMessage<T>(string uri, string eventType, T date)
    {
        InvokeOnMessage(new LcuEventArgs<T>()
        {
            Data = date,
            EventType = eventType,
            Uri = uri,
        });
    }

    void InvokeOnMessage(string jsonMessage)
    {
        var eventArg = JsonSerializer.Deserialize<JsonElement[]>(jsonMessage);
        OnMessage!.Invoke(this, eventArg!);
    }

    public Task CloseAsync(CancellationToken token)
    {
        return Task.CompletedTask;
    }

    public Task ConnectAsync(Lockfile lockfile, CancellationToken token)
    {
        return Task.CompletedTask;
    }

    public void Dispose()
    {
    }

    public ValueTask SendAsync(ReadOnlyMemory<byte> buffer, WebSocketMessageType msgType, CancellationToken token)
    {
        return ValueTask.CompletedTask;
    }
}
