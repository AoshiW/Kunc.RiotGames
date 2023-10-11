#pragma warning disable SYSLIB1006 // Multiple logging methods cannot use the same event id within a class
using System.Reflection;
using Microsoft.Extensions.Logging;

namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

partial class LolLeagueClientUpdate
{
    [LoggerMessage(0, LogLevel.Error, "Exception was throw when was invoked WAMP delegate: {methodInfo}")]
    partial void LogExceptionWhenInvokeWampDelegate(MethodInfo methodInfo, Exception ex);

    [LoggerMessage(0, LogLevel.Debug, "Invoked Method: {methodInfo}")]
    partial void LogInvokeMethod(MethodInfo methodInfo);

    [LoggerMessage(0, LogLevel.Debug, "Register delegate: {methodInfo}")]
    partial void LogRegisterDelegate(MethodInfo methodInfo);

    [LoggerMessage(0, LogLevel.Debug, "Total {count} methods were subscribed from {type}.")]
    partial void LogTotalSubscibedMethods(int count, Type type);
}
