using System.Reflection;
using Microsoft.Extensions.Logging;

namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

internal static partial class LoggingExtensions
{
    [LoggerMessage(LogLevel.Information, "lockfile was created: {lockfile}")]
    public static partial void LogCreate(this ILogger<FileLockfileProvider> logger, Lockfile lockfile);

    [LoggerMessage(LogLevel.Information, "lockfile was deleted")]
    public static partial void LogDelete(this ILogger<FileLockfileProvider> logger);


    [LoggerMessage(LogLevel.Error, "Exception was throw when was invoked WAMP delegate: {methodInfo}")]
    public static partial void LogExceptionWhenInvokeWampDelegate(this ILogger<LolLeagueClientUpdate> logger, MethodInfo methodInfo, Exception ex);

    [LoggerMessage(LogLevel.Debug, "Invoked Method: {methodInfo}")]
    public static partial void LogInvokeMethod(this ILogger<LolLeagueClientUpdate> logger, MethodInfo methodInfo);

    [LoggerMessage(LogLevel.Debug, "Register delegate: {methodInfo}")]
    public static partial void LogRegisterDelegate(this ILogger<LolLeagueClientUpdate> logger, MethodInfo methodInfo);

    [LoggerMessage(LogLevel.Debug, "Total {count} methods were subscribed from {type}.")]
    public static partial void LogTotalSubscribedMethods(this ILogger<LolLeagueClientUpdate> logger, int count, Type type);

    [LoggerMessage(LogLevel.Debug, "Process not found.")]
    public static partial void LogProcessNotFound(this ILogger<FileLockfileProvider> logger);

    [LoggerMessage(LogLevel.Information, "Process found.")]
    public static partial void LogProcessFound(this ILogger<FileLockfileProvider> logger);

    [LoggerMessage(LogLevel.Error, "Process found, but cant get path.")]
    public static partial void LogProcessFoundNotPath(this ILogger<FileLockfileProvider> logger);


    [LoggerMessage(LogLevel.Error, "Exception was throw in WAMP event loop.")]
    public static partial void LogEventLoopException(this ILogger<Wamp> logger, Exception ex);

    [LoggerMessage(LogLevel.Information, "Exception was throw.")]
    public static partial void LogInfoException(this ILogger logger, Exception ex);

    [LoggerMessage(LogLevel.Information, "Connected.")]
    public static partial void LogConnected(this ILogger<Wamp> logger);

    [LoggerMessage(LogLevel.Information, "Disconnected.")]
    public static partial void LogDisconnected(this ILogger<Wamp> logger);

    [LoggerMessage(LogLevel.Trace, "Full message received, length: {length} bytes.")]
    public static partial void LogFullMessageReceived(this ILogger<Wamp> logger, long length);
}
