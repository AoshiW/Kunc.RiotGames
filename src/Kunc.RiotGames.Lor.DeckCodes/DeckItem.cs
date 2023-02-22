using System.Diagnostics;

namespace Kunc.RiotGames.Lor.DeckCodes;

/// <inheritdoc cref="IDeckItem"/>
[DebuggerDisplay("CardCode = {CardCode}, Count = {Count} ")]
public class DeckItem : IReadOnlyDeckItem, IDeckItem, IEquatable<DeckItem?>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DeckItem"/> class. 
    /// </summary>
    public DeckItem() : this(string.Empty, 0)
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="DeckItem"/> class.
    /// </summary>
    /// <param name="cardCode">Card's card code.</param>
    /// <param name="count">Card's count.</param>
    /// <exception cref="ArgumentNullException">If <paramref name="cardCode"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">If <paramref name="count"/> is less than 0.</exception>
    public DeckItem(string cardCode, int count)
    {
        ArgumentNullException.ThrowIfNull(cardCode);
#if NET8_0_OR_GREATER
        ArgumentOutOfRangeException.ThrowIfNegative(count);
#else
        if (count < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(count), count, $"'{nameof(count)}' must be a non-negative value.");
        }
#endif
        CardCode = cardCode;
        Count = count;
    }

    /// <inheritdoc/>
    public string CardCode { get; set; }

    /// <inheritdoc/>
    public int Count { get; set; }

    /// <inheritdoc/>
    public override bool Equals(object? obj) => Equals(obj as DeckItem);

    /// <inheritdoc/>
    public bool Equals(DeckItem? other)
    {
        return other is not null &&
               Count == other.Count &&
               CardCode == other.CardCode;
    }

    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(CardCode, Count);

    /// <summary>Compares two values to determine equality.</summary>
    /// <param name="left">The value to compare with <paramref name="right" />.</param>
    /// <param name="right">The value to compare with <paramref name="left" />.</param>
    /// <returns><c>true</c> if <paramref name="left" /> is equal to <paramref name="right" />; otherwise, <c>false</c>.</returns>
    public static bool operator ==(DeckItem? left, DeckItem? right) => EqualityComparer<DeckItem>.Default.Equals(left, right);

    /// <summary>Compares two values to determine inequality.</summary>
    /// <param name="left">The value to compare with <paramref name="right" />.</param>
    /// <param name="right">The value to compare with <paramref name="left" />.</param>
    /// <returns><c>true</c> if <paramref name="left" /> is not equal to <paramref name="right" />; otherwise, <c>false</c>.</returns>
    public static bool operator !=(DeckItem? left, DeckItem? right) => !(left == right);
}
