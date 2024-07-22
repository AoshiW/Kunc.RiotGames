# Kunc.RiotGames.Lor.DeckCodes
[![Nuget](https://img.shields.io/nuget/v/Kunc.RiotGames.Lor.DeckCodes?logo=NuGet&logoColor=blue&style=flat-square)](https://www.nuget.org/packages/Kunc.RiotGames.Lor.DeckCodes)

This is a better implementation of the C# library [RiotGames/LoRDeckCodes](https://github.com/RiotGames/LoRDeckCodes),
which is used to encode/decode Legends of Runeterra decks  to/from simple strings.
This library is faster and more efficient (at least 50% less memory allocation).

Documentation on how this works can be found in the [original repository](https://github.com/RiotGames/LoRDeckCodes/blob/main/README.md).

## How to Use
```cs
var deckEncoder = new LorDeckEncoder();

var deck1 = new List<DeckItem>()
{
    new() { CardCode = "01DE002", Count = 4 },
    new() { CardCode = "02BW003", Count = 2 },
    new() { CardCode = "02BW010", Count = 3 },
    ...
}
string code = deckEncoder.GetCodeFromDeck(deck1);
List<DeckCard> deck2 = deckEncoder.GetDeckFromCode<DeckCard>(code);
```

You can also use your own class instead of the `DeckItem`, all you have to do is implement these 2 interface\
`IDeckCard` - to get deck from code\
`IReadOnlyDeckCard` - to get the code from the deck
```cs
class MyCard : IDeckItem, IReadOnlyDeckItem 
{
    public string CardCode { get; set; }
    public int Count { get; set; }
    // ...
}
var deckEncoder = new LorDeckEncoder();
List<MyCard> deck = deckEncoder.GetDeckFromCode<MyCard>("SomeCode");
string code = deckEncoder.GetCodeFromDeck(deck);
```

## Disclaimer
`Kunc.RiotGames.Lor.DeckCodes` isn't endorsed by Riot Games and doesn't reflect the views or opinions of Riot Games or anyone officially involved in producing or managing Riot Games properties. Riot Games, and all associated properties are trademarks or registered trademarks of Riot Games, Inc.
