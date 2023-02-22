using System.Numerics;

namespace Kunc.RiotGames.Lol;

public struct Rank :
    IEquatable<Rank>,
    IComparable,
    IComparable<Rank>
#if NET7_0_OR_GREATER
    , IEqualityOperators<Rank, Rank, bool>,
    IComparisonOperators<Rank, Rank, bool>
#endif
{
    public Rank(Tier tier, Division division, int lp)
    {
        Tier = tier;
        Division = division;
        LP = lp;
    }

    public Rank(Tier tier, Division division)
        : this(tier, division, 0)
    { }

    public Tier Tier { get; set; }
    public Division Division { get; set; }
    public int LP { get; set; }

    public bool IsUnranked 
        => Tier == Tier.Unranked;

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is Rank rank && Equals(rank);

    /// <inheritdoc/>
    public bool Equals(Rank other)
    {
        return Tier == other.Tier &&
               Division == other.Division &&
               LP == other.LP;
    }

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(Tier, Division, LP);

    /// <inheritdoc/>
    public static bool operator ==(Rank left, Rank right)
        => left.Equals(right);

    /// <inheritdoc/>
    public static bool operator !=(Rank left, Rank right)
        => !(left == right);

    /// <inheritdoc/>
    public static bool operator >(Rank left, Rank right)
        => left.CompareTo(right) > 0;

    /// <inheritdoc/>
    public static bool operator >=(Rank left, Rank right)
        => left.CompareTo(right) >= 0;

    /// <inheritdoc/>
    public static bool operator <(Rank left, Rank right)
        => left.CompareTo(right) < 0;

    /// <inheritdoc/>
    public static bool operator <=(Rank left, Rank right)
        => left.CompareTo(right) <= 0;

    /// <inheritdoc/>
    public override string ToString()
        => $"{Tier} {Division} {LP}LP";

    /// <inheritdoc/>
    public int CompareTo(Rank other)
    {
        if (Tier != other.Tier)
        {
            return Tier.CompareTo(other.Tier);
        }
        else if (Division != other.Division)
        {
            return Division.CompareTo(other.Division);
        }
        else
        {
            return LP.CompareTo(other.LP);
        }
    }

    /// <inheritdoc/>
    public int CompareTo(object? value)
    {
        if (value is null)
        {
            return 1;
        }
        return value is Rank rank 
            ? CompareTo(rank) 
            : throw new ArgumentException($"Object must be of type {nameof(Rank)}.");
    }

}
