# Kunc.RiotGames.Lor.DeckCodes
[![Nuget](https://img.shields.io/nuget/v/Kunc.RiotGames.Lor.DeckCodes?logo=NuGet&logoColor=blue&style=flat-square)](https://www.nuget.org/packages/Kunc.RiotGames.Lor.DeckCodes)

This is a C# implementation of the C# library [RiotGames/LoRDeckCodes](https://github.com/RiotGames/LoRDeckCodes).
This library is faster and allocate less memory.


## Usage
```cs
var deck1 = new List<DeckItem>()
{
    new() { CardCode = "01DE002", Count = 4 },
    new() { CardCode = "02BW003", Count = 2 },
    new() { CardCode = "02BW010", Count = 3 },
    ...
}
var deckEncoder = new LorDeckEncoder();
string code = deckEncoder.GetCodeFromDeck(deck1);
List<DeckCard> deck2 = deckEncoder.GetDeckFromCode<DeckCard>(code);
```

You can also use your own class, all you have to do is implement 2 interface\
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

### Build-in DI support
```cs
serviceCollection.AddLorDeckCodes();  
// ...
var deckEncoder = serviceProvider.GetRequiredService<ILorDeckEncoder>();
```
## Disclaimer
`Kunc.RiotGames.Lor.DeckCodes` isn't endorsed by Riot Games and doesn't reflect the views or opinions of Riot Games or anyone officially involved in producing or managing Riot Games properties. Riot Games, and all associated properties are trademarks or registered trademarks of Riot Games, Inc.
