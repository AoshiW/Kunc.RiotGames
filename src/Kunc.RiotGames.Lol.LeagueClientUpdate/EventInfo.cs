using System.Reflection;
using System.Runtime.CompilerServices;

namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

class EventInfo
{
    public readonly ArgType[] ArgTypes;
    public readonly Type? EventArgsType;
    public readonly MethodInfo MethodInfo;
    public readonly LcuEventAttribute EventAttribute;
    public readonly object? Target;

    public EventInfo(LcuEventAttribute attribute, MethodInfo methodInfo, object? target)
    {
        var parameterInfos = methodInfo.GetParameters();
        EventAttribute = attribute;
        MethodInfo = methodInfo;
        Target = target;
        ArgTypes = parameterInfos.Length is 0 ? [] : new ArgType[parameterInfos.Length];
        for (int i = 0; i < parameterInfos.Length; i++)
        {
            var item = parameterInfos[i];
            if (item.ParameterType == typeof(object) ||
                item.ParameterType == typeof(LolLeagueClientUpdate) ||
                item.ParameterType == typeof(ILolLeagueClientUpdate))
            {
                ArgTypes[i] = ArgType.Sender;
            }
            else if (item.ParameterType == typeof(CancellationToken))
            {
                ArgTypes[i] = ArgType.CancelationToken;
            }
            else
            {
                if (EventArgsType is not null && EventArgsType != item.ParameterType)
                    throw new InvalidOperationException($"Delegate have multiple different arguments that are classified as {nameof(ArgType.EventArgs)}. ('{EventArgsType}', '{item.ParameterType}')");
                ArgTypes[i] = ArgType.EventArgs;
                EventArgsType = item.ParameterType;
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public object? Invoke(object?[]? parameters) => MethodInfo.Invoke(Target, parameters);
}
