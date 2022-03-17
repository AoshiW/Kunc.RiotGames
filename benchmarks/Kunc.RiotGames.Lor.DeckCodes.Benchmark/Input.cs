using Kunc.RiotGames.Lor.DeckCodes.Benchmark.OrigCode;
using System.Collections.Generic;

namespace Kunc.RiotGames.Lor.DeckCodes.Benchmark;

public class Input
{
    static readonly ILorDeckEncoder deckEncoder = new LorDeckEncoder();

    public Input(string code, string type)
    {
        Type = type;
        Code = code;
        Property = LoRDeckEncoder.GetDeckFromCode(code);
        Kunc = deckEncoder.GetDeckFromCode<DeckItem>(code);
    }

    public string Type { get; }
    public string Code { get; }
    public List<CardCodeAndCount> Property { get; }
    public List<DeckItem> Kunc { get; }
    public override string ToString() => Type;
}
