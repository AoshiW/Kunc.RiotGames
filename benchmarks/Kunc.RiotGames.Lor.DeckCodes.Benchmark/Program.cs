using BenchmarkDotNet.Running;
using Kunc.RiotGames.Lor.DeckCodes;
using Kunc.RiotGames.Lor.DeckCodes.Benchmark;
using System.Linq;

#if RELEASE
BenchmarkRunner.Run<Benchmark>();
return;
#endif
var inputs = new Benchmark().Inputs.Cast<Input>();
var deckEncoder = new LorDeckEncoder();
deckEncoder.GetDeckFromCode<DeckItem>(inputs.Last().Code);
deckEncoder.GetCodeFromDeck(inputs.Last().Kunc);
