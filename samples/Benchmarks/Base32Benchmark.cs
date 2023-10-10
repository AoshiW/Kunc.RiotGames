using System.Buffers;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Kunc.RiotGames.Lor.DeckCodes;

namespace Benchmarks;

[MemoryDiagnoser]
[ShortRunJob(RuntimeMoniker.Net70)]
public class Base32Benchmark
{
    public IEnumerable<object> Strings() => new string[]
    {
        "oooooo",
    };

    public IEnumerable<object> Bytes() => Strings().Select(static x => Base32.FromBase32((string)x));

    [Benchmark, ArgumentsSource(nameof(Bytes))]
    public void TryGetString(byte[] input)
    {
        var chars = ArrayPool<char>.Shared.Rent(Base32.GetCharCount(input, default));
        if (!Base32.TryToBase32(input, chars, default, out _))
            throw new FormatException();
        ArrayPool<char>.Shared.Return(chars);
    }

    [Benchmark, ArgumentsSource(nameof(Bytes))]
    public void TryGetStringNoPadding(byte[] input)
    {
        var chars = ArrayPool<char>.Shared.Rent(Base32.GetCharCount(input, Base32FormattingOptions.RemovePadding));
        if (!Base32.TryToBase32(input, chars, Base32FormattingOptions.RemovePadding, out _))
            throw new FormatException();
        ArrayPool<char>.Shared.Return(chars);
    }

    [Benchmark, ArgumentsSource(nameof(Strings))]
    public void TryGetBytes(string input) {
        var bytes = ArrayPool<byte>.Shared.Rent(Base32.GetByteCount(input));
        if (!Base32.TryFromBase32(input, bytes, out _))
            throw new FormatException();
        ArrayPool<byte>.Shared.Return(bytes);
    }
}
