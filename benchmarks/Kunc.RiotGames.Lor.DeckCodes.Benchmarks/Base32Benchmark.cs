using BenchmarkDotNet.Attributes;

namespace Kunc.RiotGames.Lor.DeckCodes.Benchmarks;

[MemoryDiagnoser]
public class Base32Benchmark
{
    public IEnumerable<object> Strings() => new string[]
    {
        "oooooo",
    };

    public IEnumerable<object> Bytes() => Strings().Select(static x => Base32.FromBase32((string)x));

    [Benchmark, ArgumentsSource(nameof(Bytes))]
    public object TryGetString(byte[] input)
    {
        return Base32.ToBase32(input, default);
    }

    [Benchmark, ArgumentsSource(nameof(Bytes))]
    public object TryGetStringNoPadding(byte[] input)
    {
        return Base32.ToBase32(input, Base32FormattingOptions.RemovePadding);
    }

    [Benchmark, ArgumentsSource(nameof(Strings))]
    public object TryGetBytes(string input)
    {
        return Base32.FromBase32(input);
    }
}
