#pragma warning disable IDE0046 // Use conditional expression for return
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace Kunc.RiotGames.Lol;

/// <summary>
/// Represents the rank of Summoner in League of Legends (and TFT).
/// </summary>
public struct Rank :
    IEquatable<Rank>,
    IComparable,
    IComparable<Rank>,
    ISpanFormattable
#if NET7_0_OR_GREATER
    , IEqualityOperators<Rank, Rank, bool>,
    IComparisonOperators<Rank, Rank, bool> // TODO ISpanParseable<>?
#endif
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Rank"/> class.
    /// </summary>
    /// <param name="tier"></param>
    /// <param name="division"></param>
    /// <param name="leaguePoints"></param>
    public Rank(Tier tier, Division division, int leaguePoints = 0)
    {
        Tier = tier;
        Division = division;
        LeaguePoints = leaguePoints;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Rank"/> class.
    /// </summary>
    public Rank()
    { }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public Tier Tier { get; set; }
    public Division Division { get; set; }
    public int LeaguePoints { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

    /// <remarks>
    /// <see langword="true"/> if <see cref="Tier"/> is <see cref="Tier.Unranked"/> or <see cref="Division"/> is <see cref="Division.None"/>; otherwise, <see langword="false"/>.
    /// </remarks>
    public bool IsUnranked
        => Tier == Tier.Unranked || Division == Division.None;

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is Rank rank && Equals(rank);

    /// <inheritdoc/>
    public bool Equals(Rank other)
    {
        return Tier == other.Tier &&
               Division == other.Division &&
               LeaguePoints == other.LeaguePoints;
    }

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(Tier, Division, LeaguePoints);

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
    public int CompareTo(Rank other)
    {
        if (Tier != other.Tier)
        {
            return Tier.CompareTo(other.Tier);
        }
        else if (Division != other.Division)
        {
            return other.Division.CompareTo(Division);
        }
        else
        {
            return LeaguePoints.CompareTo(other.LeaguePoints);
        }
    }

    /// <inheritdoc/>
    public int CompareTo(object? obj)
    {
        if (obj is null)
        {
            return 1;
        }
        if (obj is Rank rank)
        {
            return CompareTo(rank);
        }
        else
        {
            throw new ArgumentException($"Object must be of type '{nameof(Rank)}'.");
        }
    }

    /// <summary>
    /// Deconstructs <see cref="Rank"/> by <see cref="Tier"/>, <see cref="Division"/> and <see cref="LeaguePoints"/>.
    /// </summary>
    /// <param name="tier">Deconstructed parameter for <see cref="Tier"/>.</param>
    /// <param name="division">Deconstructed parameter for <see cref="Division"/>.</param>
    /// <param name="lp">Deconstructed parameter for <see cref="LeaguePoints"/>.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void Deconstruct(out Tier tier, out Division division, out int lp)
    {
        tier = Tier;
        division = Division;
        lp = LeaguePoints;
    }

    /// <summary>
    /// Deconstructs <see cref="Rank"/> by <see cref="Tier"/>, <see cref="Division"/> and <see cref="LeaguePoints"/>.
    /// </summary>
    /// <param name="tier"> Deconstructed parameter for <see cref="Tier"/>.</param>
    /// <param name="division">Deconstructed parameter for <see cref="Division"/>.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void Deconstruct(out Tier tier, out Division division)
    {
        tier = Tier;
        division = Division;
    }

    const string UnrankedString = "Unranked";

    /// <inheritdoc/>
    public override string ToString()
        => IsUnranked
        ? UnrankedString
        : $"{Tier} {Division} {LeaguePoints}LP";

    /// <inheritdoc/>
    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
    {
        if (IsUnranked)
        {
            if (UnrankedString.TryCopyTo(destination))
            {
                charsWritten = UnrankedString.Length;
                return true;
            }
            charsWritten = 0;
            return false;
        }
        return destination.TryWrite($"{Tier} {Division} {LeaguePoints}LP", out charsWritten);
    }

    /// <inheritdoc/>
    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        return ToString();
    }
   }
