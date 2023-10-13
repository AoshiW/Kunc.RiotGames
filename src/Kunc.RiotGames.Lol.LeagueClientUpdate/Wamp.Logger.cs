using Microsoft.Extensions.Logging;

namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

partial class Wamp
{
    [LoggerMessage(LogLevel.Error, "Exception was throw in WAMP event loop.")]
    partial void LogEventLoopException(Exception ex);

    [LoggerMessage(LogLevel.Information, "Connected.")]
    partial void LogConnected();

    [LoggerMessage(LogLevel.Information, "Disconnected.")]
    partial void LogDisconnected();

    [LoggerMessage(LogLevel.Trace, "Full message received, length: {length} bytes.")]
    partial void LogFullMessageReceived(long length);
}
