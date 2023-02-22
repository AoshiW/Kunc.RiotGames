using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Kunc.RiotGames.Lor.DeckCodes;

namespace NotSample;

//[SimpleJob(RuntimeMoniker.Net70)]
//[SimpleJob(RuntimeMoniker.Net80)]
[MemoryDiagnoser]
public class LorDeckEncoderBenchmark
{
    static readonly LorDeckEncoder _deckEncoder = new(new());
    public IEnumerable<object> Inputs { get; } = new Input[]
   {
        //new("CEAAAAIBAEAAC", "1 card"),
        new("CEAQYAIABEGA2EQUDANB2IRHFAYQCAQBAAWTEAA","Min"),
        new("CEAAECABAQJRWHBIFU2DOOYIAEBAMCIMCINCILJZAICACBANE4VCYBABAILR2HRL","D_1"),
        new("CQBQCAIADAAQEAADAEBAGBAKAEAQAHIBAEBSGAICAAEQCAQDAMAQGAAPAEBQGAIBAQAAOAIEAMDACBIKWMAQCBIDBUFACAIAE4AQCAZCAEBAABABAIBQKAIDAAHACBAABYAQIAYSAECQUEQBAUBQMAQDAMDAO", "Max") // legal, but unplayable: D 
   };

    [Benchmark(Description = "Kunc.GetCode"), ArgumentsSource(nameof(Inputs)), BenchmarkCategory("GetCode")]
    public string GetCodeKunc(Input type) => _deckEncoder.GetCodeFromDeck(type.Kunc);

    [Benchmark(Description = "Kunc.GetDeck"), ArgumentsSource(nameof(Inputs)), BenchmarkCategory("GetDeck")]
    public List<DeckItem> GetDeckKunc(Input type) => _deckEncoder.GetDeckFromCode<DeckItem>(type.Code);

    //[Benchmark(Description = "Riot.GetCode"), ArgumentsSource(nameof(Inputs)), BenchmarkCategory("GetCode")]
    //public string GetCodeRiot(Input type) => LoRDeckEncoder.GetCodeFromDeck(type.Property);

    //[Benchmark(Description = "Riot.GetDeck"), ArgumentsSource(nameof(Inputs)), BenchmarkCategory("GetDeck")]
    //public List<CardCodeAndCount> GetDeckRiot(Input type) => LoRDeckEncoder.GetDeckFromCode(type.Code);

    public class Input
    {
        static readonly ILorDeckEncoder deckEncoder = new LorDeckEncoder();

        public Input(string code, string type)
        {
            Type = type;
            Code = code;
            Kunc = deckEncoder.GetDeckFromCode<DeckItem>(code);
            //Property = LoRDeckEncoder.GetDeckFromCode(code);
        }

        public string Type { get; }
        public string Code { get; }
        public List<DeckItem> Kunc { get; }
        //public List<CardCodeAndCount> Property { get; }
        public override string ToString() => Type;
    }
}
