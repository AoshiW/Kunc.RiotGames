using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Lol;

/// <summary>
/// Queue types for Lol (and Tft).
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverterWithAltNames<QueueType>))]
public enum QueueType
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    [JsonStringEnumMemberName("RANKED_SOLO_5x5")]
    RankedSolo5x5,

    [JsonStringEnumMemberName("RANKED_FLEX_SR")]
    RankedFlexSR,

    Cherry,

    [JsonStringEnumMemberName("RANKED_TFT_DOUBLE_UP")]
    RankedTftDoubleUp,

    [JsonStringEnumMemberName("RANKED_TFT_TURBO")]
    RankedTftTurbo,

    [JsonStringEnumMemberName("RANKED_TFT")]
    RankedTft,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}

internal static partial class QueueTypeExtensions
{
    public static void ThrowIfNotLolQueue(this QueueType queue, [CallerArgumentExpression(nameof(queue))] string? paramName = null)
    {
        if (!(queue is QueueType.RankedSolo5x5 or QueueType.RankedFlexSR or QueueType.Cherry))
        {
            throw new ArgumentException($"Value '{queue}' is not valid LoL Queue", paramName);
        }
    }

    public static void ThrowIfNotTftQueue(this QueueType queue, [CallerArgumentExpression(nameof(queue))] string? paramName = null)
    {
        if (!(queue is QueueType.RankedTft or QueueType.RankedTftTurbo or QueueType.RankedTftDoubleUp))
        {
            throw new ArgumentException($"Value '{queue}' is not valid TFT Queue", paramName);
        }
    }

    public static string ToApiString(this QueueType queue)
    {
        return queue switch
        {
            QueueType.RankedSolo5x5 => "RANKED_SOLO_5x5",
            QueueType.RankedFlexSR => "RANKED_FLEX_SR",
            QueueType.Cherry => "CHERRY",

            QueueType.RankedTftDoubleUp => "RANKED_TFT_DOUBLE_UP",
            QueueType.RankedTftTurbo => "RANKED_TFT_TURBO",
            QueueType.RankedTft => "RANKED_TFT",
            _ => throw new InvalidOperationException()
        };
    }
}
