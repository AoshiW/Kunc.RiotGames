﻿using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Kunc.RiotGames.Lor.DeckCodes;

namespace NotSample;

//[ShortRunJob(RuntimeMoniker.Net60)]
[ShortRunJob(RuntimeMoniker.Net70)]
[ShortRunJob(RuntimeMoniker.Net80)]
[MemoryDiagnoser]
public partial class LorDeckEncoderBenchmark
{
    static readonly LorDeckEncoder DeckEncoder = new(new());
    static readonly LorDeckEncoder DeckEncoderNoCache = new(null);

    public IEnumerable<object> Inputs { get; } = new Input[]
   {
        //new("CEAAAAIBAEAAC", "1 card"),
        new("CEAQYAIABEGA2EQUDANB2IRHFAYQCAQBAAWTEAA","Min"),
        new("CEAAECABAQJRWHBIFU2DOOYIAEBAMCIMCINCILJZAICACBANE4VCYBABAILR2HRL","D_1"),
        new("CQBQCAIADAAQEAADAEBAGBAKAEAQAHIBAEBSGAICAAEQCAQDAMAQGAAPAEBQGAIBAQAAOAIEAMDACBIKWMAQCBIDBUFACAIAE4AQCAZCAEBAABABAIBQKAIDAAHACBAABYAQIAYSAECQUEQBAUBQMAQDAMDAO", "Max"), // legal, but unplayable: D 
        //new("CUAAAKABHQGOOBYBHUGOOBYBHYGOOBYBH4GOOBYBIAGOOBYBIEGOOBYBIIGOOBYBIMGOOBYBIQGOOBYBIUGOOBYBIYGOOBYBI4GOOBYBJAGOOBYBJEGOOBYBJIGOOBYBJMGOOBYBJQGOOBYBJUGOOBYBJYGOOBYBJ4GOOBYBKAGOOBYBKEGOOBYBKIGOOBYBKMGOOBYBKQGOOBYBKUGOOBYBKYGOOBYBK4GOOBYBLAGOOBYBLEGOOBYBLIGOOBYBLMGOOBYBLQGOOBYBLUGOOBYBLYGOOBYBL4GOOBYBMAGOOBYBMEGOOBYBMIGOOBYBMMGOOBY", "MAX illegal deck") // 327 chars  40x (Count = 1, CardCode = "{59..99}RU999") 
   };

    [Benchmark(Description = "Kunc.GetCode"), ArgumentsSource(nameof(Inputs)), BenchmarkCategory("GetCode")]
    public string GetCodeKunc(Input type) => DeckEncoder.GetCodeFromDeck(type.Kunc);

    [Benchmark(Description = "Kunc.GetDeck"), ArgumentsSource(nameof(Inputs)), BenchmarkCategory("GetDeck")]
    public List<DeckItem> GetDeckKunc(Input type) => DeckEncoder.GetDeckFromCode<DeckItem>(type.Code);

    [Benchmark(Description = "Kunc.GetDeck.NoCache"), ArgumentsSource(nameof(Inputs)), BenchmarkCategory("GetDeck")]
    public List<DeckItem> GetDeckKuncNoCache(Input type) => DeckEncoderNoCache.GetDeckFromCode<DeckItem>(type.Code);

    //[Benchmark(Description = "Riot.GetCode"), ArgumentsSource(nameof(Inputs)), BenchmarkCategory("GetCode")]
    //public string GetCodeRiot(Input type) => LoRDeckEncoder.GetCodeFromDeck(type.Riot);

    //[Benchmark(Description = "Riot.GetDeck"), ArgumentsSource(nameof(Inputs)), BenchmarkCategory("GetDeck")]
    //public List<CardCodeAndCount> GetDeckRiot(Input type) => LoRDeckEncoder.GetDeckFromCode(type.Code);

    public class Input
    {
        public Input(string code, string type)
        {
            Type = type;
            Code = code;
            Kunc = DeckEncoderNoCache.GetDeckFromCode<DeckItem>(code);
            //Riot = LoRDeckEncoder.GetDeckFromCode(code);
        }

        public string Type { get; }
        public string Code { get; }
        public List<DeckItem> Kunc { get; }
        //public List<CardCodeAndCount> Riot { get; }
        public override string ToString() => Type;
    }
}
