#pragma warning disable SYSLIB1006 // Multiple logging methods cannot use the same event id within a class
using Microsoft.Extensions.Logging;

namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

partial class Wamp
{
    [LoggerMessage(0, LogLevel.Error, "Exception was throw in WAMP event loop.")]
    partial void LogEventLoopException(Exception ex);

    [LoggerMessage(0, LogLevel.Information, "Conneted.")]
    partial void LogConnected();

    [LoggerMessage(0, LogLevel.Information, "Disconneted.")]
    partial void LogDisconnected();

    [LoggerMessage(0, LogLevel.Trace, "Full message received, length: {length} bytes.")]
    partial void LogFullMessageReceived(long length);
}
