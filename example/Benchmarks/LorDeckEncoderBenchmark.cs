using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Benchmarks.Riot.LoRDeckCodes;
using Kunc.RiotGames.Lor.DeckCodes;

namespace Benchmarks;

[MemoryDiagnoser]
[ShortRunJob]
public class KuncLorDeckEncoderBenchmark : LorDeckEncoderBenchmarkBase
{

    [Benchmark(Description = "Kunc.GetCode"), ArgumentsSource(nameof(Inputs))]
    public string GetCodeKunc(Input type) => DeckEncoder.GetCodeFromDeck(type.Kunc);

    [Benchmark(Description = "Kunc.GetDeck"), ArgumentsSource(nameof(Inputs))]
    public List<DeckItem> GetDeckKunc(Input type) => DeckEncoder.GetDeckFromCode<DeckItem>(type.Code);
}

[MemoryDiagnoser]
[ShortRunJob]
public class RiotLorDeckEncoderBenchmark : LorDeckEncoderBenchmarkBase
{
    [Benchmark(Description = "Riot.GetCode"), ArgumentsSource(nameof(Inputs))]
    public string GetCodeRiot(Input type) => LoRDeckEncoder.GetCodeFromDeck(type.Riot);

    [Benchmark(Description = "Riot.GetDeck"), ArgumentsSource(nameof(Inputs))]
    public List<CardCodeAndCount> GetDeckRiot(Input type) => LoRDeckEncoder.GetDeckFromCode(type.Code);
}

public class LorDeckEncoderBenchmarkBase
{
    static protected readonly LorDeckEncoder DeckEncoder = new();

    public IEnumerable<object> Inputs { get; } = new Input[]
    {
        //new("CEAAAAIBAEAAC", "1 card"),
        new("CEAQYAIABEGA2EQUDANB2IRHFAYQCAQBAAWTEAA","Min"),
        new("CEAAECABAQJRWHBIFU2DOOYIAEBAMCIMCINCILJZAICACBANE4VCYBABAILR2HRL","D_1"),
        new("CQBQCAIADAAQEAADAEBAGBAKAEAQAHIBAEBSGAICAAEQCAQDAMAQGAAPAEBQGAIBAQAAOAIEAMDACBIKWMAQCBIDBUFACAIAE4AQCAZCAEBAABABAIBQKAIDAAHACBAABYAQIAYSAECQUEQBAUBQMAQDAMDAO", "Max"),
        //new("CUAAAKABHQGOOBYBHUGOOBYBHYGOOBYBH4GOOBYBIAGOOBYBIEGOOBYBIIGOOBYBIMGOOBYBIQGOOBYBIUGOOBYBIYGOOBYBI4GOOBYBJAGOOBYBJEGOOBYBJIGOOBYBJMGOOBYBJQGOOBYBJUGOOBYBJYGOOBYBJ4GOOBYBKAGOOBYBKEGOOBYBKIGOOBYBKMGOOBYBKQGOOBYBKUGOOBYBKYGOOBYBK4GOOBYBLAGOOBYBLEGOOBYBLIGOOBYBLMGOOBYBLQGOOBYBLUGOOBYBLYGOOBYBL4GOOBYBMAGOOBYBMEGOOBYBMIGOOBYBMMGOOBY", "MAX illegal deck") // 327 chars  40x (Count = 1, CardCode = "{59..99}RU999") 
   };

    public class Input
    {
        public Input(string code, string type)
        {
            Type = type;
            Code = code;
            Kunc = DeckEncoder.GetDeckFromCode<DeckItem>(code);
            Riot = LoRDeckEncoder.GetDeckFromCode(code);
        }

        public string Type { get; }
        public string Code { get; }
        public List<DeckItem> Kunc { get; }
        public List<CardCodeAndCount> Riot { get; }
        public override string ToString() => Type;
    }
}
