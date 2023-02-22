using System.Runtime.CompilerServices;

namespace Kunc.RiotGames.Lor.DeckCodes;

#if !NET8_0_OR_GREATER
static class ListExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void AddRange<T>(this List<T> list, ReadOnlySpan<T> buffer)
    {
        list.AddRange(buffer.ToArray());
    }
}
#endif
