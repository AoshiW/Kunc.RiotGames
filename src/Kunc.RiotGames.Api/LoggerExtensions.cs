using Kunc.RiotGames.Api.Http;
using Microsoft.Extensions.Logging;

namespace Kunc.RiotGames.Api;

internal static partial class LoggerExtensions
{
    [LoggerMessage(LogLevel.Error, "Problem with json deserialization. Request: {request}")]
    public static partial void LogDeserializeException(this ILogger logger, Exception ex, RiotRequestMessage  request);

    [LoggerMessage(LogLevel.Warning, "TooManyRequests (speed limiter didn't work properly). Region: {region}, MethodId: {methodId}, Delay: {delay:c} MethodType: {type}")]
    public static partial void HitRateLimits(this ILogger logger, string region, string methodId, TimeSpan delay, string type);

    [LoggerMessage(LogLevel.Information, "App rate limiter is initialized, Region: {region}, RateLimits: {rateLimits}")]
    public static partial void InitializedAppRateLimit(this ILogger logger, string region, string rateLimits);

    [LoggerMessage(LogLevel.Information, "Method rate limiter is initialized, Region: {region}, MethodId: {methodId} RateLimits: {rateLimits}")]
    public static partial void InitializedMethodRateLimit(this ILogger logger, string region, string methodId, string rateLimits);
}
