using System.Reflection;
using Microsoft.Extensions.Logging;

namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

partial class LolLeagueClientUpdate
{
    [LoggerMessage(LogLevel.Error, "Exception was throw when was invoked WAMP delegate: {methodInfo}")]
    partial void LogExceptionWhenInvokeWampDelegate(MethodInfo methodInfo, Exception ex);

    [LoggerMessage(LogLevel.Debug, "Invoked Method: {methodInfo}")]
    partial void LogInvokeMethod(MethodInfo methodInfo);

    [LoggerMessage(LogLevel.Debug, "Register delegate: {methodInfo}")]
    partial void LogRegisterDelegate(MethodInfo methodInfo);

    [LoggerMessage(LogLevel.Debug, "Total {count} methods were subscribed from {type}.")]
    partial void LogTotalSubscribedMethods(int count, Type type);
}
