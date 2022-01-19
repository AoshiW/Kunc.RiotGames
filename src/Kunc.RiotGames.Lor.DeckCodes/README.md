﻿# Kunc.Lor.DeckCodes

This is a C# implementation of the C# library [RiotGames/LoRDeckCodes](https://github.com/RiotGames/LoRDeckCodes).
This library is faster and use less memory.

## How to use
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
List<DeckCard> deck2 = deckEncoder.GetDeckFromCode<DeckCard>("SomeCode");
```

You can also use your own class, all you have to do is implement 2 interface\
`IDeckCard` - to get deck from code\
`IReadOnlyDeckCard` - to get the code from the deck

```cs
class MyCard : IDeckItem, IReadOnlyDeckItem { ... }

var deckEncoder = new LorDeckEncoder();
List<MyCard> deck = deckEncoder.GetDeckFromCode<MyCard>("SomeCode");
string code = deckEncoder.GetCodeFromDeck(deck);
```
