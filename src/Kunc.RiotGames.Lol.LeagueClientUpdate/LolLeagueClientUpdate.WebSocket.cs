using System.Net.WebSockets;
using System.Reflection;
using System.Text.Json;

namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

public partial class LolLeagueClientUpdate : ILolLeagueClientUpdate
{
    readonly object _lock = new();
    private readonly List<EventInfo> _events = [];
    EventInfo[] _readOnlyEvents = [];
    bool _isEdited = true;
    CancellationTokenSource? _cancellationTokenSource;

    /// <inheritdoc/>
    public IWamp Wamp { get; }

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
        await Wamp.ConnectAsync(lockfile, token).ConfigureAwait(false);
        await Wamp.SendAsync(SubscribeOnJsonApiEvent, WebSocketMessageType.Text, token).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task CloseWampAsync(CancellationToken token = default)
    {
        _cancellationTokenSource?.Cancel();
        return Wamp.CloseAsync(token);
    }

    static readonly ReadOnlyMemory<byte> SubscribeOnJsonApiEvent = "[5, \"OnJsonApiEvent\"]"u8.ToArray();

    private void OnMessage(object? sender, JsonElement[] e)
    {
        if (e.Length != 3 || e[0].GetInt32() != 8)
            return;
        var data = e[2];
        OnLcuEvent?.Invoke(this, data.Deserialize<LcuEventArgs<JsonElement>>()!);
        if (!e[1].ValueEquals("OnJsonApiEvent"u8))
            return;

        EventInfo[] eventLocalCopy;
        lock (_lock)
        {
            if (_isEdited)
            {
                _readOnlyEvents = _events.ToArray();
                _isEdited = false;
            }
            eventLocalCopy = _readOnlyEvents;
        }

        object? boxedCancellationToken = null;
        CacheArray cacheArray = default;
        JsonElement eventTypeProp = data.GetProperty("eventType"u8);
        JsonElement uriProp = data.GetProperty("uri"u8);
        foreach (var item in eventLocalCopy)
        {
            if (!uriProp.ValueEquals(item.EventAttribute.Uri) ||
                (item.EventAttribute.EventType is not null && !eventTypeProp.ValueEquals(item.EventAttribute.EventType)))
                continue;

            var args = cacheArray.Get(item.ArgTypes.Length);
            for (int i = 0; i < item.ArgTypes.Length; i++)
            {
                args![i] = item.ArgTypes[i] switch
                {
                    ArgType.Sender => this,
                    ArgType.EventArgs => item.EventArgsType == typeof(JsonElement) ? data : data.Deserialize(item.EventArgsType!)!,
                    ArgType.CancelationToken => boxedCancellationToken ??= _cancellationTokenSource!.Token,
                    _ => throw new ArgumentOutOfRangeException(null, item.ArgTypes[i], "Unknow enum value.")
                };
            }
            try
            {
                item.Invoke(args);
                _logger.LogInvokeMethod(item.MethodInfo);
            }
            catch (Exception ex)
            {
                _logger.LogExceptionWhenInvokeWampDelegate(item.MethodInfo, ex);
            }
        }
    }

    /// <inheritdoc/>
    public void Subscribe(LcuEventAttribute attribute, Delegate eventHandler)
    {
        ArgumentNullException.ThrowIfNull(attribute);
        ArgumentNullException.ThrowIfNull(eventHandler);
        SubscribeCore(attribute, eventHandler.Method, eventHandler.Target);
    }

    /// <inheritdoc/>
    public void Subscribe(string uri, Delegate eventHandler)
    {
        ArgumentNullException.ThrowIfNull(uri);
        ArgumentNullException.ThrowIfNull(eventHandler);
        var attribute = new LcuEventAttribute(uri);
        SubscribeCore(attribute, eventHandler.Method, eventHandler.Target);
    }

    /// <inheritdoc/>
    public void Subscribe(Delegate eventHandler)
    {
        ArgumentNullException.ThrowIfNull(eventHandler);
        var attribute = ThrowIfMissingLcuEventAttribute(eventHandler.Method);
        SubscribeCore(attribute, eventHandler.Method, eventHandler.Target);
    }

    void SubscribeCore(LcuEventAttribute attribute, MethodInfo methodInfo, object? target)
    {
        var di = new EventInfo(attribute, methodInfo, target);
        _logger.LogRegisterDelegate(methodInfo);
        lock (_lock)
        {
            _isEdited = true;
            _events.Add(di);
        }
    }

    /// <inheritdoc/>
    public bool Unsubscribe(LcuEventAttribute attribute, Delegate eventHandler)
    {
        ArgumentNullException.ThrowIfNull(attribute);
        ArgumentNullException.ThrowIfNull(eventHandler);
        lock (_lock)
        {
            var index = _events.FindIndex(x => x.Equals(attribute, eventHandler.Method, eventHandler.Target));
            if (index is -1)
                return false;
            _events.RemoveAt(index);
            _isEdited = true;
            return true;
        }
    }

    /// <inheritdoc/>
    public bool Unsubscribe(string uri, Delegate eventHandler)
    {
        ArgumentNullException.ThrowIfNull(uri);
        ArgumentNullException.ThrowIfNull(eventHandler);
        var attribute = new LcuEventAttribute(uri);
        return Unsubscribe(attribute, eventHandler);
    }

    /// <inheritdoc/>
    public bool Unsubscribe(Delegate eventHandler)
    {
        ArgumentNullException.ThrowIfNull(eventHandler);
        var attribute = ThrowIfMissingLcuEventAttribute(eventHandler.Method);
        return Unsubscribe(attribute, eventHandler);
    }

    /// <inheritdoc/>
    public int SubscribeAll<T>(T? target, MethodOptions options = MethodOptions.Public | MethodOptions.Instance) where T : class
    {
        return SubscribeAllCore(typeof(T), target, options);
    }


    int SubscribeAllCore(Type type, object? target, MethodOptions options)
    {
        var count = 0;
        var methods = type.GetMethods((BindingFlags)options);
        foreach (var methodInfo in methods)
        {
            var attribute = methodInfo.GetCustomAttribute<LcuEventAttribute>();
            if (attribute is null)
                continue;
            var currentMethodTarget = methodInfo.IsStatic
                ? null
                : target ??= Activator.CreateInstance(type);
            SubscribeCore(attribute, methodInfo, currentMethodTarget);
            count++;
        }
        _logger.LogTotalSubscribedMethods(count, type);
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
    object[]? _array1, _array2, _array3;

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
