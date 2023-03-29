#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Reflection;
using System.Text.Json;

namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

public partial class LolLeagueClientUpdate
{
    private readonly Wamp _wamp;
    public event EventHandler<JsonElement[]>? OnWampMessage
    {
        add => _wamp.OnMessage += value;
        remove => _wamp.OnMessage -= value;
    }

    public event EventHandler? OnWampDisconnect
    {
        add => _wamp.OnDisconnect += value;
        remove => _wamp.OnDisconnect -= value;
    }

    public event EventHandler? OnWampConnect
    {
        add => _wamp.OnConnect += value; 
        remove => _wamp.OnConnect -= value;
    }

    public event EventHandler<Exception>? OnWampMessageError
    {
        add => _wamp.OnMessageError += value; 
        remove => _wamp.OnMessageError -= value;
    }

    private readonly ConcurrentDictionary<string, List<DelegateInfo>> _events = new();
    CancellationTokenSource? _cancellationTokenSource;

    /// <summary>
    /// Connest to LCU WebSocket.
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    public async Task ConnectWampAsync(CancellationToken token = default)
    {
        _cancellationTokenSource = new();
        await _wamp.ConnectAsync(Lockfile, token).ConfigureAwait(false);
        await _wamp.SendAsync(SubscribeOnJsonApiEvent, WebSocketMessageType.Text, token).ConfigureAwait(false);
    }

    /// <summary>
    /// Close LCU WebSocket.
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    public Task CloseWampAsync(CancellationToken token = default)
    {
        _cancellationTokenSource?.Cancel();
        return _wamp.CloseAsync(token);
    }

    static readonly ReadOnlyMemory<byte> SubscribeOnJsonApiEvent = "[5, \"OnJsonApiEvent\"]"u8.ToArray();

    private void OnMessage(object? sender, JsonElement[] data)
    {
        if (data.Length != 3 ||
            data[0].GetInt32() != 8 ||
            !data[1].ValueEquals("OnJsonApiEvent"u8) ||
            !_events.TryGetValue(data[2].GetProperty("uri"u8).GetString()!, out var eventsDelegatesInfo))
            return;
        JsonElement? eventTypeProp = default;
        foreach (var item in eventsDelegatesInfo)
        {
            if (item.EventType is not null &&
                !(eventTypeProp ??= data[2].GetProperty("eventType"u8)).ValueEquals(item.EventType))
                continue;
            var args = item.ArgTypes.Length == 0 ? null : new object[item.ArgTypes.Length];
            for (int i = 0; i < item.ArgTypes.Length; i++)
            {
                args![i] = item.ArgTypes[i] switch
                {
                    ArgType.Sender => this,
                    ArgType.Argument => item.Type == typeof(JsonElement) ? data[2] : data[2].Deserialize(item.Type!)!,
                    ArgType.CancelationToken => _cancellationTokenSource!.Token,
                    _ => throw new ArgumentOutOfRangeException(null, item.ArgTypes[i], "Unknow enum value.")
                };
            }
            try
            {
                item.Delegate.DynamicInvoke(args);
            }
            catch { }
        }
    }

    public void Subscribe<T>(string eventUri, EventHandler<T> eventHandler)
    {
        ArgumentNullException.ThrowIfNull(eventUri);
        ArgumentNullException.ThrowIfNull(eventHandler);
        SubscribeCore(new(eventUri), eventHandler, eventHandler.Method.GetParameters());
    }

    public void Subscribe(string eventUri, Delegate eventHandler)
    {
        ArgumentNullException.ThrowIfNull(eventUri);
        ArgumentNullException.ThrowIfNull(eventHandler);
        SubscribeCore(new(eventUri), eventHandler, eventHandler.Method.GetParameters());
    }

    void SubscribeCore(LcuEventAttribute attribute, Delegate eventHandler, ParameterInfo[] parameterInfos)
    {
        DelegateInfo di = new()
        {
            ArgTypes = parameterInfos.Length == 0 ? Array.Empty<ArgType>() : new ArgType[parameterInfos.Length],
            Delegate = eventHandler,
            //Uri = eventUri,
            EventType = attribute.EventType,
        };
        for (int i = 0; i < parameterInfos.Length; i++)
        {
            var item = parameterInfos[i];
            if (item.ParameterType == typeof(object) || item.ParameterType == typeof(LolLeagueClientUpdate))
            {
                di.ArgTypes[i] = ArgType.Sender;
            }
            else if (item.ParameterType == typeof(CancellationToken))
            {
                di.ArgTypes[i] = ArgType.CancelationToken;
            }
            else
            {
                di.ArgTypes[i] = ArgType.Argument;
                di.Type = item.ParameterType;
            }
        }
        var events = _events.GetOrAdd(attribute.Uri, static _ => new());
        events.Add(di);
    }

    public void SubscribeAll<T>() => SubscribeAllCore(typeof(T), null);

    public void SubscribeAll<T>(T obj)
    {
        ArgumentNullException.ThrowIfNull(obj);
        SubscribeAllCore(typeof(T), obj);
    }

    void SubscribeAllCore(Type type, object? obj)
    {
        var methods = type.GetMethods();
        foreach (var methodInfo in methods)
        {
            var attribute = methodInfo.GetCustomAttribute<LcuEventAttribute>();
            if (attribute is null)
                continue;
            var args = methodInfo.GetParameters();
            var delegateType = CreateDelegateType(args, methodInfo.ReturnType);
            var @delegate = methodInfo.CreateDelegate(delegateType, methodInfo.IsStatic ? null : obj ??= Activator.CreateInstance(type));
            SubscribeCore(attribute, @delegate, args);
        }
    }

    static Type CreateDelegateType(ParameterInfo[] parameters, Type returnType)
    {
        if (parameters.Length > 3)
            throw new ArgumentException("Method cant have more than 3 parametrs.", nameof(parameters));
        Type[] methodArgs;
        Type delegateType;
        if (returnType == typeof(void))
        {
            if (parameters.Length == 0)
                return typeof(Action);
            methodArgs = new Type[parameters.Length];
#pragma warning disable CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).
            delegateType = parameters.Length switch
            {
                1 => typeof(Action<>),
                2 => typeof(Action<,>),
                3 => typeof(Action<,,>),
            };
#pragma warning restore CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).
        }
        else
        {
            methodArgs = new Type[parameters.Length + 1];
            methodArgs[^1] = returnType;
#pragma warning disable CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).
            delegateType = parameters.Length switch
            {
                0 => typeof(Func<>),
                1 => typeof(Func<,>),
                2 => typeof(Func<,,>),
                3 => typeof(Func<,,,>),
            };
#pragma warning restore CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).
        }
        for (int i = 0; i < parameters.Length; i++)
        {
            methodArgs[i] = parameters[i].ParameterType;
        }
        return delegateType.MakeGenericType(methodArgs);
    }
}
