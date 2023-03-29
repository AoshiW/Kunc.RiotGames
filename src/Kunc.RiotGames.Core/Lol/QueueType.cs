using System.Runtime.CompilerServices;

namespace Kunc.RiotGames.Lol;

/// <summary>
/// Queue types for Lol (and Tft).
/// </summary>
public enum QueueType
{
#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    RANKED_SOLO_5x5,
    RANKED_FLEX_SR,

    RANKED_TFT_DOUBLE_UP,
    RANKED_TFT_TURBO,
    RANKED_TFT,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning restore CA1707 // Identifiers should not contain underscores
}

internal static partial class ThrowExtensions
{
    public static void ThrowIfNotLolQueue(this QueueType queue, [CallerArgumentExpression(nameof(queue))] string? paramName = null)
    {
        if (!(queue is QueueType.RANKED_SOLO_5x5 or QueueType.RANKED_FLEX_SR))
        {
            throw new ArgumentException($"Value '{queue}' is not valid LoL Queue", paramName);
        }
    }

    public static void ThrowIfNotTftQueue(this QueueType queue, [CallerArgumentExpression(nameof(queue))] string? paramName = null)
    {
        if (!(queue is QueueType.RANKED_TFT or QueueType.RANKED_TFT_TURBO or QueueType.RANKED_TFT_DOUBLE_UP))
        {
            throw new ArgumentException($"Value '{queue}' is not valid TFT Queue", paramName);
        }
    }
}
