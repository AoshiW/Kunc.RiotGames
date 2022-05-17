using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using Kunc.RiotGames.Lor.DeckCodes.Benchmark.OrigCode;
using System.Collections.Generic;

namespace Kunc.RiotGames.Lor.DeckCodes.Benchmark;

[MemoryDiagnoser, GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
public class Benchmark
{
    readonly LorDeckEncoder _deckEncoder = new(null);
    public IEnumerable<object> Inputs { get; } = new Input[]
    {
        //new("CEAAAAIBAEAAC", "1 card"),
        new("CEAQYAIABEGA2EQUDANB2IRHFAYQCAQBAAWTEAA","Min"),
        new("CEAAECABAQJRWHBIFU2DOOYIAEBAMCIMCINCILJZAICACBANE4VCYBABAILR2HRL","D_1"),
        new("CQBQCAIADAAQEAADAEBAGBAKAEAQAHIBAEBSGAICAAEQCAQDAMAQGAAPAEBQGAIBAQAAOAIEAMDACBIKWMAQCBIDBUFACAIAE4AQCAZCAEBAABABAIBQKAIDAAHACBAABYAQIAYSAECQUEQBAUBQMAQDAMDAO", "Max") // legal, but unplayable: D 
    };

    [Benchmark(Description = "Riot.GetCode"), ArgumentsSource(nameof(Inputs)), BenchmarkCategory("GetCode")]
    public string GetCodeRiot(Input type) => LoRDeckEncoder.GetCodeFromDeck(type.Property);

    [Benchmark(Description = "Kunc.GetCode"), ArgumentsSource(nameof(Inputs)), BenchmarkCategory("GetCode")]
    public string GetCodeKunc(Input type) => _deckEncoder.GetCodeFromDeck(type.Kunc);

    [Benchmark(Description = "Riot.GetDeck"), ArgumentsSource(nameof(Inputs)), BenchmarkCategory("GetDeck")]
    public List<CardCodeAndCount> GetDeckRiot(Input type) => LoRDeckEncoder.GetDeckFromCode(type.Code);

    [Benchmark(Description = "Kunc.GetDeck"), ArgumentsSource(nameof(Inputs)), BenchmarkCategory("GetDeck")]
    public List<DeckItem> GetDeckKunc(Input type) => _deckEncoder.GetDeckFromCode<DeckItem>(type.Code);
}
