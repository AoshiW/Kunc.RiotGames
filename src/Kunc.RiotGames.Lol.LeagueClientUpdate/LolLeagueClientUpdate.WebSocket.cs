using System.Diagnostics;
using System.Net.WebSockets;
using System.Reflection;
using System.Text.Json;

#if NET8_0
using Lock = System.Object;
#endif

namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

public partial class LolLeagueClientUpdate : ILolLeagueClientUpdate
{
    private readonly IWamp _wamp;
    private readonly Lock _eventHandlersLock = new();
    private readonly List<EventInfo> _events = [];
    private EventInfo[] _readOnlyEvents = [];
    private bool _areEventHandlersEdited = true;
    private CancellationTokenSource? _cancellationTokenSource;

    /// <inheritdoc/>
    public event EventHandler<LcuEventArgs<JsonElement>>? OnLcuEvent;

    /// <inheritdoc/>
    public async Task ConnectWampAsync(CancellationToken token = default)
    {
        var lockfile = await _lockfileProvider.GetLockfileAsync(token).ConfigureAwait(false);
        if (lockfile is null)
            throw new InvalidOperationException();
        await ConnectWampAsyncCore(lockfile, token).ConfigureAwait(false);
    }

    async Task ConnectWampAsyncCore(Lockfile lockfile, CancellationToken token)
    {
        _cancellationTokenSource = new();
        await _wamp.ConnectAsync(lockfile, token).ConfigureAwait(false);
        await _wamp.SendAsync(SubscribeOnJsonApiEvent, WebSocketMessageType.Text, token).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task CloseWampAsync(CancellationToken token = default)
    {
        _cancellationTokenSource?.Cancel();
        return _wamp.CloseAsync(token);
    }

    static readonly ReadOnlyMemory<byte> SubscribeOnJsonApiEvent = "[5, \"OnJsonApiEvent\"]"u8.ToArray();

    private void OnMessage(object? sender, JsonElement[] e)
    {
        if (e.Length != 3 || e[0].GetInt32() != 8)
            return;
        var data = e[2];
        OnLcuEvent?.Invoke(this, data.Deserialize<LcuEventArgs<JsonElement>>(_options.JsonSerializerOptions)!);
        if (!e[1].ValueEquals("OnJsonApiEvent"u8))
            return;

        EventInfo[] eventsLocalCopy;
        lock (_eventHandlersLock)
        {
            if (_areEventHandlersEdited)
            {
                _readOnlyEvents = _events.ToArray();
                _areEventHandlersEdited = false;
            }
            eventsLocalCopy = _readOnlyEvents;
        }

        object? boxedCancellationToken = null;
        CacheArray cacheArray = default;
        JsonElement eventTypeProp = data.GetProperty("eventType"u8);
        JsonElement uriProp = data.GetProperty("uri"u8);
        foreach (var eventInfo in eventsLocalCopy)
        {
            if (!uriProp.ValueEquals(eventInfo.EventAttribute.Uri) ||
                (eventInfo.EventAttribute.EventType is not null && !eventTypeProp.ValueEquals(eventInfo.EventAttribute.EventType)))
                continue;

            var args = cacheArray.Get(eventInfo.ArgTypes.Length);
            for (int i = 0; i < eventInfo.ArgTypes.Length; i++)
            {
                args![i] = eventInfo.ArgTypes[i] switch
                {
                    ArgType.Sender => this,
                    ArgType.EventArgs => eventInfo.EventArgsType == typeof(JsonElement) ? data : data.Deserialize(eventInfo.EventArgsType!, _options.JsonSerializerOptions)!,
                    ArgType.CancelationToken => boxedCancellationToken ??= _cancellationTokenSource!.Token,
                    _ => throw new UnreachableException($"Unknow enum value '{eventInfo.ArgTypes[i]}'.")
                };
            }
            try
            {
                eventInfo.Invoke(args);
                _logger.LogInvokeMethod(eventInfo.MethodInfo);
            }
            catch (Exception ex)
            {
                _logger.LogExceptionWhenInvokeWampDelegate(eventInfo.MethodInfo, ex);
            }
        }
    }

    /// <inheritdoc/>
    public IDisposable Subscribe(LcuEventAttribute attribute, Delegate eventHandler)
    {
        ArgumentNullException.ThrowIfNull(attribute);
        ArgumentNullException.ThrowIfNull(eventHandler);
        return SubscribeCore(attribute, eventHandler.Method, eventHandler.Target);
    }

    /// <inheritdoc/>
    public IDisposable Subscribe(string uri, Delegate eventHandler)
    {
        ArgumentNullException.ThrowIfNull(uri);
        ArgumentNullException.ThrowIfNull(eventHandler);
        var attribute = new LcuEventAttribute(uri);
        return SubscribeCore(attribute, eventHandler.Method, eventHandler.Target);
    }

    /// <inheritdoc/>
    public IDisposable Subscribe(Delegate eventHandler)
    {
        ArgumentNullException.ThrowIfNull(eventHandler);
        var attribute = ThrowIfMissingLcuEventAttribute(eventHandler.Method);
        return SubscribeCore(attribute, eventHandler.Method, eventHandler.Target);
    }

    IDisposable SubscribeCore(LcuEventAttribute attribute, MethodInfo methodInfo, object? target)
    {
        var di = new EventInfo(attribute, methodInfo, target);
        _logger.LogRegisterDelegate(methodInfo);
        lock (_eventHandlersLock)
        {
            _areEventHandlersEdited = true;
            _events.Add(di);
        }
        return new Unsubscribe(this, di);
    }

    sealed class Unsubscribe : IDisposable
    {
        private readonly LolLeagueClientUpdate _lolLeagueClientUpdate;
        private readonly EventInfo _eventInfo;

        public Unsubscribe(LolLeagueClientUpdate lolLeagueClientUpdate, EventInfo eventInfo)
        {
            _lolLeagueClientUpdate = lolLeagueClientUpdate;
            _eventInfo = eventInfo;
        }

        public void Dispose()
        {
            lock (_lolLeagueClientUpdate._eventHandlersLock)
            {
                if (_lolLeagueClientUpdate._events.Remove(_eventInfo))
                {
                    _lolLeagueClientUpdate._areEventHandlersEdited = true;
                }
            }
        }
    }

    /// <inheritdoc/>
    public IDisposable[] SubscribeAll<T>(T? target, MethodOptions options = MethodOptions.Public | MethodOptions.Instance) where T : class
    {
        return SubscribeAllCore(typeof(T), target, options);

        IDisposable[] SubscribeAllCore(Type type, object? target, MethodOptions options)
        {
            var disposables = new List<IDisposable>();
            var methods = type.GetMethods((BindingFlags)options);
            foreach (var methodInfo in methods)
            {
                var attribute = methodInfo.GetCustomAttribute<LcuEventAttribute>();
                if (attribute is null)
                    continue;
                var currentMethodTarget = methodInfo.IsStatic
                    ? null
                    : target ??= Activator.CreateInstance(type);
                disposables.Add(SubscribeCore(attribute, methodInfo, currentMethodTarget));
            }
            _logger.LogTotalSubscribedMethods(disposables.Count, type);
            return disposables.ToArray();
        }
    }

    public int UnsubscribeAll()
    {
        int count = 0;
        lock (_eventHandlersLock)
        {
            count = _events.Count;
            _events.Clear();
            _areEventHandlersEdited = true;
        }
        return count;
    }

    private static LcuEventAttribute ThrowIfMissingLcuEventAttribute(MethodInfo methodInfo)
    {
        var attribute = methodInfo.GetCustomAttribute<LcuEventAttribute>();
        return attribute is null
            ? throw new InvalidOperationException($"Required attribute '{nameof(LcuEventAttribute)}' missing.")
            : attribute;
    }
}

file struct CacheArray
{
    private object[]? _array1, _array2, _array3;

    public object[]? Get(int length)
    {
        return length switch
        {
            0 => null,
            1 => _array1 ??= new object[1],
            2 => _array2 ??= new object[2],
            3 => _array3 ??= new object[3],
            _ => new object[length],
        };
    }
}
