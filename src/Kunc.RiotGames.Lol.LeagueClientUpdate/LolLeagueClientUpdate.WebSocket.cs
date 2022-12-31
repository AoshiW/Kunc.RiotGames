using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Reflection;
using System.Text.Json;

namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

public partial class LolLeagueClientUpdate
{
    public Wamp Wamp { get; } = new();
    
    private readonly ConcurrentDictionary<string, ConcurrentBag<DelegateInfo>> _events = new();
    CancellationTokenSource? _cancellationTokenSource;

    public async Task ConnectAsync(CancellationToken token = default)
    {
        _cancellationTokenSource = new();
        await Wamp.ConnectAsync(Lockfile, token).ConfigureAwait(false);
        await Wamp.SendAsync(SubscribeOnJsonApiEvent, WebSocketMessageType.Text, token).ConfigureAwait(false);
    }

    public Task CloseAsync(CancellationToken token = default)
    {
        _cancellationTokenSource?.Cancel();
        return Wamp.CloseAsync(token);
    }

    static readonly ReadOnlyMemory<byte> SubscribeOnJsonApiEvent = "[5, \"OnJsonApiEvent\"]"u8.ToArray();

    private void OnMessage(JsonElement[] data)
    {
        if (data.Length != 3 ||
            data[0].GetInt32() != 8 ||
            !data[1].ValueEquals("OnJsonApiEvent"u8) ||
            !_events.TryGetValue(data[2].GetProperty("uri"u8).GetString()!, out var ev))
            return;
        JsonElement? eventTypeProp = default;
        foreach (var item in ev)
        {
            if (item.EventType is not null &&
                !(eventTypeProp ??= data[2].GetProperty("eventType"u8)).ValueEquals(item.EventType))
                continue;
            var args = item.ArgTypes.Length == 0 ? Array.Empty<object>() : new object[item.ArgTypes.Length];
            for (int i = 0; i < item.ArgTypes.Length; i++)
            {
                args[i] = item.ArgTypes[i] switch
                {
                    ArgType.Sender => this,
                    ArgType.Argument => data[2].Deserialize(item.Type!)!,
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
        => SubscribeCore(new(eventUri), eventHandler, eventHandler.Method.GetParameters());

    public void Subscribe<T>(string eventUri, Func<object, T, CancellationToken, Task> eventHandler)
        => SubscribeCore(new(eventUri), eventHandler, eventHandler.Method.GetParameters());

    public void Subscribe(string eventUri, Delegate eventHandler) 
        => SubscribeCore(new(eventUri), eventHandler, eventHandler.Method.GetParameters());

    void SubscribeCore(LcuEventAttribute attribute, Delegate eventHandler, ParameterInfo[] parameterInfos)
    {
        ArgumentNullException.ThrowIfNull(attribute);
        ArgumentNullException.ThrowIfNull(eventHandler);
        ArgumentNullException.ThrowIfNull(parameterInfos);
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
            delegateType = parameters.Length switch
            {
                1 => typeof(Action<>),
                2 => typeof(Action<,>),
                3 => typeof(Action<,,>),
            };
        }
        else
        {
            methodArgs = new Type[parameters.Length + 1];
            methodArgs[^1] = returnType;
            delegateType = parameters.Length switch
            {
                0 => typeof(Func<>),
                1 => typeof(Func<,>),
                2 => typeof(Func<,,>),
                3 => typeof(Func<,,,>),
            };
        }
        for (int i = 0; i < parameters.Length; i++)
        {
            methodArgs[i] = parameters[i].ParameterType;
        }
        return delegateType.MakeGenericType(methodArgs);
    }
}
