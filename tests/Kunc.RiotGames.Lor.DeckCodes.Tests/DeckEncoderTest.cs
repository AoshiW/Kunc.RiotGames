using System.Globalization;

namespace Kunc.RiotGames.Lor.DeckCodes.Tests;

[TestClass]
public class DeckEncoderTest
{
    private static readonly LorDeckEncoder DeckEncoder = new();

    //Tests the encoding of a set of hard coded decks in DeckCodesTestData.txt
    [TestMethod]
    public void EncodeDecodeRecommendedDecks()
    {
        var codes = new List<string>();
        var decks = new List<List<DeckItem>>();

        //Load the test data from file.
        string? line;
        using (var myReader = new StreamReader("DeckCodesTestData.txt"))
        {
            while ((line = myReader.ReadLine()) is not null)
            {
                codes.Add(line);
                var newDeck = new List<DeckItem>();
                while (!string.IsNullOrEmpty(line = myReader.ReadLine()))
                {
                    var inex = line.IndexOf(':');
                    var cardCode = line[(inex + 1)..];
                    var count = int.Parse(line.AsSpan(0, inex), NumberStyles.Integer, NumberFormatInfo.InvariantInfo);
                    var item = new DeckItem(cardCode, count);
                    newDeck.Add(item);
                }
                decks.Add(newDeck);
            }
        }

        //Encode each test deck and ensure it's equal to the correct string.
        //Then decode and ensure the deck is unchanged.
        for (int i = 0; i < decks.Count; i++)
        {
            var encoded = DeckEncoder.GetCodeFromDeck(decks[i]);
            Assert.AreEqual(codes[i], encoded);

            var decoded = DeckEncoder.GetDeckFromCode<DeckItem>(encoded);
            Assert.IsTrue(VerifyRehydration(decks[i], decoded));
        }
    }

    [TestMethod]
    public void SmallDeck()
    {
        var deck = new List<DeckItem>
        {
            new("01DE002", 1)
        };

        string code = DeckEncoder.GetCodeFromDeck(deck);
        var decoded = DeckEncoder.GetDeckFromCode<DeckItem>(code);
        Assert.IsTrue(VerifyRehydration(deck, decoded));

    }

    [TestMethod]
    public void LargeDeck()
    {
        var deck = new List<DeckItem>
        {
            new("01DE002", 3),
            new("01DE003", 3),
            new("01DE004", 3),
            new("01DE005", 3),
            new("01DE006", 3),
            new("01DE007", 3),
            new("01DE008", 3),
            new("01DE009", 3),
            new("01DE010", 3),
            new("01DE011", 3),
            new("01DE012", 3),
            new("01DE013", 3),
            new("01DE014", 3),
            new("01DE015", 3),
            new("01DE016", 3),
            new("01DE017", 3),
            new("01DE018", 3),
            new("01DE019", 3),
            new("01DE020", 3),
            new("01DE021", 3)
        };

        string code = DeckEncoder.GetCodeFromDeck(deck);
        var decoded = DeckEncoder.GetDeckFromCode<DeckItem>(code);
        Assert.IsTrue(VerifyRehydration(deck, decoded));
    }

    [TestMethod]
    public void DeckWithCountsMoreThan3Small()
    {
        var deck = new List<DeckItem>
        {
            new("01DE002", 4)
        };

        string code = DeckEncoder.GetCodeFromDeck(deck);
        var decoded = DeckEncoder.GetDeckFromCode<DeckItem>(code);
        Assert.IsTrue(VerifyRehydration(deck, decoded));
    }

    [TestMethod]
    public void DeckWithCountsMoreThan3Large()
    {
        var deck = new List<DeckItem>
        {
            new("01DE002", 3),
            new("01DE003", 3),
            new("01DE004", 3),
            new("01DE005", 3),
            new("01DE006", 4),
            new("01DE007", 5),
            new("01DE008", 6),
            new("01DE009", 7),
            new("01DE010", 8),
            new("01DE011", 9),
            new("01DE012", 3),
            new("01DE013", 3),
            new("01DE014", 3),
            new("01DE015", 3),
            new("01DE016", 3),
            new("01DE017", 3),
            new("01DE018", 3),
            new("01DE019", 3),
            new("01DE020", 3),
            new("01DE021", 3)
        };

        string code = DeckEncoder.GetCodeFromDeck(deck);
        var decoded = DeckEncoder.GetDeckFromCode<DeckItem>(code);
        Assert.IsTrue(VerifyRehydration(deck, decoded));
    }

    [TestMethod]
    public void SingleCard40Times()
    {
        var deck = new List<DeckItem>
        {
            new("01DE002", 40)
        };

        string code = DeckEncoder.GetCodeFromDeck(deck);
        var decoded = DeckEncoder.GetDeckFromCode<DeckItem>(code);
        Assert.IsTrue(VerifyRehydration(deck, decoded));
    }

    [TestMethod]
    public void WorstCaseLength()
    {
        var deck = new List<DeckItem>
        {
            new("01DE002", 4),
            new("01DE003", 4),
            new("01DE004", 4),
            new("01DE005", 4),
            new("01DE006", 4),
            new("01DE007", 5),
            new("01DE008", 6),
            new("01DE009", 7),
            new("01DE010", 8),
            new("01DE011", 9),
            new("01DE012", 4),
            new("01DE013", 4),
            new("01DE014", 4),
            new("01DE015", 4),
            new("01DE016", 4),
            new("01DE017", 4),
            new("01DE018", 4),
            new("01DE019", 4),
            new("01DE020", 4),
            new("01DE021", 4)
        };

        string code = DeckEncoder.GetCodeFromDeck(deck);
        var decoded = DeckEncoder.GetDeckFromCode<DeckItem>(code);
        Assert.IsTrue(VerifyRehydration(deck, decoded));
    }

    [TestMethod]
    public void OrderShouldNotMatter1()
    {
        var deck1 = new List<DeckItem>
        {
            new("01DE002", 1),
            new("01DE003", 2),
            new("02DE003", 3)
        };

        var deck2 = new List<DeckItem>
        {
            new("01DE003", 2),
            new("02DE003", 3),
            new("01DE002", 1)
        };

        string code1 = DeckEncoder.GetCodeFromDeck(deck1);
        string code2 = DeckEncoder.GetCodeFromDeck(deck2);

        Assert.AreEqual(code1, code2);

        var deck3 = new List<DeckItem>
        {
            new("01DE002", 4),
            new("01DE003", 2),
            new("02DE003", 3)
        };

        var deck4 = new List<DeckItem>
        {
            new("01DE003", 2),
            new("02DE003", 3),
            new("01DE002", 4)
        };

        string code3 = DeckEncoder.GetCodeFromDeck(deck3);
        string code4 = DeckEncoder.GetCodeFromDeck(deck4);

        Assert.AreEqual(code3, code4);
    }

    [TestMethod]
    public void OrderShouldNotMatter2()
    {
        //importantly this order test includes more than 1 card with counts >3, which are sorted by card code and appending to the <=3 encodings.
        var deck1 = new List<DeckItem>
        {
            new("01DE002", 4),
            new("01DE003", 2),
            new("02DE003", 3),
            new("01DE004", 5)
        };

        var deck2 = new List<DeckItem>
        {
            new("01DE004", 5),
            new("01DE003", 2),
            new("02DE003", 3),
            new("01DE002", 4)
        };

        string code1 = DeckEncoder.GetCodeFromDeck(deck1);
        string code2 = DeckEncoder.GetCodeFromDeck(deck2);

        Assert.AreEqual(code1, code2);
    }

    [TestMethod]
    public void BilgewaterSet()
    {
        var deck = new List<DeckItem>
        {
            new("01DE002", 4),
            new("02BW003", 2),
            new("02BW010", 3),
            new("01DE004", 5)
        };

        string code = DeckEncoder.GetCodeFromDeck(deck);
        var decoded = DeckEncoder.GetDeckFromCode<DeckItem>(code);
        Assert.IsTrue(VerifyRehydration(deck, decoded));
    }

    [TestMethod]
    public void ShurimaSet()
    {
        var deck = new List<DeckItem>
        {
            new("01DE002", 4),
            new("02BW003", 2),
            new("02BW010", 3),
            new("04SH047", 5)
        };

        string code = DeckEncoder.GetCodeFromDeck(deck);
        var decoded = DeckEncoder.GetDeckFromCode<DeckItem>(code);
        Assert.IsTrue(VerifyRehydration(deck, decoded));
    }

    [TestMethod]
    public void MtTargonSet()
    {
        var deck = new List<DeckItem>
        {
            new("01DE002", 4),
            new("03MT003", 2),
            new("03MT010", 3),
            new("02BW004", 5)
        };

        string code = DeckEncoder.GetCodeFromDeck(deck);
        var decoded = DeckEncoder.GetDeckFromCode<DeckItem>(code);
        Assert.IsTrue(VerifyRehydration(deck, decoded));
    }

    [TestMethod]
    public void RuneterraSet()
    {
        var deck = new List<DeckItem>
        {
            new("01DE002", 4),
            new("03MT003", 2),
            new("03MT010", 3),
            new("01RU001", 5)
        };

        string code = DeckEncoder.GetCodeFromDeck(deck);
        var decoded = DeckEncoder.GetDeckFromCode<DeckItem>(code);
        Assert.IsTrue(VerifyRehydration(deck, decoded));
    }

    [TestMethod]
    public void BadVersion()
    {
        // make sure that a deck with an invalid version fails
        var deck = new List<DeckItem>
        {
            new("01DE002", 4),
            new("01DE003", 2),
            new("02DE003", 3),
            new("01DE004", 5)
        };

        var bytesFromDeck = Base32.FromBase32(DeckEncoder.GetCodeFromDeck(deck));

        byte formatAndVersion = 88; // arbitrary invalid format/version
        bytesFromDeck[0] = formatAndVersion;// replace with invalid one

        try
        {
            string badVersionDeckCode = Base32.ToBase32(bytesFromDeck, Base32FormattingOptions.RemovePadding);
            var deckBad = DeckEncoder.GetDeckFromCode<DeckItem>(badVersionDeckCode);
        }
        catch (ArgumentException e)
        {
            string expectedErrorMessage = "The provided code requires a higher version of this library; please update.";
            Console.WriteLine(e.Message);
            Assert.AreEqual(expectedErrorMessage, e.Message);
        }
    }

    [TestMethod]
    public void BadCardCodes()
    {
        var deck = new List<DeckItem>
        {
            new("01DE02", 1)
        };

        bool failed = false;
        try
        {
            DeckEncoder.GetCodeFromDeck(deck);
        }
        catch (ArgumentException)
        {
            failed = true;
        }
        catch (Exception ex)
        {
            Assert.IsTrue(false, "Expected to throw an ArgumentException, but it threw {0}.", ex);
        }
        Assert.IsTrue(failed, "Expected to throw an ArgumentException, but it succeeded.");

        failed = false;
        deck.Clear();
        deck.Add(new("01XX002", 1));

        try
        {
            DeckEncoder.GetCodeFromDeck(deck);
        }
        catch (ArgumentException)
        {
            failed = true;
        }
        catch (Exception ex)
        {
            Assert.IsTrue(false, "Expected to throw an ArgumentException, but it threw {0}.", ex);
        }
        Assert.IsTrue(failed, "Expected to throw an ArgumentException, but it succeeded.");


        failed = false;
        deck.Clear();
        deck.Add(new() { CardCode = "01DE002", Count = 0 });

        try
        {
            DeckEncoder.GetCodeFromDeck(deck);
        }
        catch (ArgumentException)
        {
            failed = true;
        }
        catch (Exception ex)
        {
            Assert.IsTrue(false, "Expected to throw an ArgumentException, but it threw {0}.", ex);
        }
        Assert.IsTrue(failed, "Expected to throw an ArgumentException, but it succeeded.");
    }

    [TestMethod]
    public void BadCount()
    {
        var deck = new List<DeckItem>
        {
            new() { CardCode = "01DE002", Count = 0 }
        };
        bool failed = false;
        try
        {
            DeckEncoder.GetCodeFromDeck(deck);
        }
        catch (ArgumentException)
        {
            failed = true;
        }
        catch (Exception ex)
        {
            Assert.IsTrue(false, "Expected to throw an ArgumentException, but it threw {0}.", ex);
        }
        Assert.IsTrue(failed, "Expected to throw an ArgumentException, but it succeeded.");

        failed = false;
        deck.Clear();
        deck.Add(new() { CardCode = "01DE002", Count = -1 });
        try
        {
            DeckEncoder.GetCodeFromDeck(deck);
        }
        catch (ArgumentException)
        {
            failed = true;
        }
        catch (Exception ex)
        {
            Assert.IsTrue(false, "Expected to throw an ArgumentException, but it threw {0}.", ex);
        }
        Assert.IsTrue(failed, "Expected to throw an ArgumentException, but it succeeded.");
    }


    [TestMethod]
    public void GarbageDecoding()
    {
        string badEncodingNotBase32 = "I'm no card code!";
        string badEncoding32 = "ABCDEFG";
        string badEncodingEmpty = "";

        bool failed = false;
        try
        {
            DeckEncoder.GetDeckFromCode<DeckItem>(badEncodingNotBase32);
        }
        catch (ArgumentException)
        {
            failed = true;
        }
        catch (Exception ex)
        {
            Assert.IsTrue(false, "Expected to throw an ArgumentException, but it threw {0}.", ex);
        }
        Assert.IsTrue(failed, "Expected to throw an ArgumentException, but it succeeded.");

        failed = false;
        try
        {
            DeckEncoder.GetDeckFromCode<DeckItem>(badEncoding32);
        }
        catch (ArgumentException)
        {
            failed = true;
        }
        catch (Exception ex)
        {
            Assert.IsTrue(false, "Expected to throw an ArgumentException, but it threw {0}.", ex);
        }
        Assert.IsTrue(failed, "Expected to throw an ArgumentException, but it succeeded.");

        failed = false;
        try
        {
            DeckEncoder.GetDeckFromCode<DeckItem>(badEncodingEmpty);
        }
        catch
        {
            failed = true;
        }
        Assert.IsTrue(failed, "Expected to throw an ArgumentException, but it succeeded.");

    }

    [TestMethod]
    [DataRow("DE", 1)]
    [DataRow("FR", 1)]
    [DataRow("IO", 1)]
    [DataRow("NX", 1)]
    [DataRow("PZ", 1)]
    [DataRow("SI", 1)]
    [DataRow("BW", 2)]
    [DataRow("MT", 2)]
    [DataRow("SH", 3)]
    [DataRow("BC", 4)]
    [DataRow("RU", 5)]
    public void DeckVersionIsTheMinimumLibraryVersionThatSupportsTheContainedFactions(string faction, int expectedVersion)
    {
        List<DeckItem> deck = new()
        {
            new("01DE001", 1),
            new($"01{faction}002", 1),
            new("01FR001", 1)
        };
        string deckCode = DeckEncoder.GetCodeFromDeck(deck);

        int minSupportedLibraryVersion = ExtractVersionFromDeckCode(deckCode);

        Assert.AreEqual(expectedVersion, minSupportedLibraryVersion);
    }

    private static int ExtractVersionFromDeckCode(string deckCode)
    {
        byte[] bytes = Base32.FromBase32(deckCode);
        return bytes[0] & 0xF;
    }

    [TestMethod]
    public void ArgumentExceptionOnFutureVersion()
    {
        const string singleCardDeckWithVersion10 = "DEAAABABAEFACAIBAAAQCAIFAEAQGCTP";
        Assert.ThrowsException<ArgumentException>(() => DeckEncoder.GetDeckFromCode<DeckItem>(singleCardDeckWithVersion10));
    }

    private static bool VerifyRehydration(List<DeckItem> d, List<DeckItem> rehydratedList)
    {
        if (d.Count != rehydratedList.Count)
            return false;

        foreach (var cd in rehydratedList)
        {
            bool found = false;
            foreach (var cc in d)
            {
                if (cc.CardCode == cd.CardCode && cc.Count == cd.Count)
                {
                    found = true;
                    break;
                }
            }
            if (!found)
                return false;
        }
        return true;
    }
}
