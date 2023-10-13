namespace Kunc.RiotGames;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public abstract partial class QueryString
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
{
    /// <summary>
    /// Core function for creating query string.
    /// </summary>
    /// <param name="builder"></param>
    protected abstract void ToStringCore(ref QueryStringBuilder builder);

    /// <inheritdoc/>
    public sealed override string ToString()
    {
        var builder = new QueryStringBuilder();
        ToStringCore(ref builder);
        return builder.ToStringAndClear();
    }
}
