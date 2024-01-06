using Microsoft.Extensions.Logging;

namespace Kunc.RiotGames.Lol.DataDragon;

internal static partial class LoggingExtensions
{
    [LoggerMessage(LogLevel.Information, "Downloading: {uri}")]
    public static partial void LogDownloading(this ILogger<LolDataDragon> logger, string uri);
}
