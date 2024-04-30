﻿using System.Net.WebSockets;
using System.Text.Json;
using Kunc.RiotGames.Lol.LeagueClientUpdate;

class NullWamp : IWamp
{
    public bool IsConnected => true;

    public event EventHandler<JsonElement[]>? OnMessage;
    public event EventHandler? OnDisconnect;
    public event EventHandler? OnConnect;
#pragma warning disable CS0067
    public event EventHandler<Exception>? OnMessageException;
#pragma warning restore CS0067

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

    void InvokeOnMessage(string jsonMessage)
    {
        var eventArg = JsonSerializer.Deserialize<JsonElement[]>(jsonMessage);
        OnMessage!.Invoke(this, eventArg!);
    }

    public Task CloseAsync(CancellationToken token)
    {
        OnDisconnect?.Invoke(this, EventArgs.Empty);
        return Task.CompletedTask;
    }

    public Task ConnectAsync(Lockfile lockfile, CancellationToken token)
    {
        OnConnect?.Invoke(this, EventArgs.Empty);
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
