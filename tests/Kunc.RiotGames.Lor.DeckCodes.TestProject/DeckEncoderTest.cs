using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace Kunc.RiotGames.Lor.DeckCodes.TestProject;

[TestClass]
public class DeckEncoderTest
{
    static readonly ILorDeckEncoder DeckEncoder = new LorDeckEncoder();

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
            while ((line = myReader.ReadLine()) != null)
            {
                codes.Add(line);
                var newDeck = new List<DeckItem>();
                while (!string.IsNullOrEmpty(line = myReader.ReadLine()))
                {
                    var parts = line.Split(new char[] { ':' });
                    newDeck.Add(new DeckItem() { Count = int.Parse(parts[0]), CardCode = parts[1] });
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
            new() { CardCode = "01DE002", Count = 1 }
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
            new() { CardCode = "01DE002", Count = 3 },
            new() { CardCode = "01DE003", Count = 3 },
            new() { CardCode = "01DE004", Count = 3 },
            new() { CardCode = "01DE005", Count = 3 },
            new() { CardCode = "01DE006", Count = 3 },
            new() { CardCode = "01DE007", Count = 3 },
            new() { CardCode = "01DE008", Count = 3 },
            new() { CardCode = "01DE009", Count = 3 },
            new() { CardCode = "01DE010", Count = 3 },
            new() { CardCode = "01DE011", Count = 3 },
            new() { CardCode = "01DE012", Count = 3 },
            new() { CardCode = "01DE013", Count = 3 },
            new() { CardCode = "01DE014", Count = 3 },
            new() { CardCode = "01DE015", Count = 3 },
            new() { CardCode = "01DE016", Count = 3 },
            new() { CardCode = "01DE017", Count = 3 },
            new() { CardCode = "01DE018", Count = 3 },
            new() { CardCode = "01DE019", Count = 3 },
            new() { CardCode = "01DE020", Count = 3 },
            new() { CardCode = "01DE021", Count = 3 }
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
            new() { CardCode = "01DE002", Count = 4 }
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
            new() { CardCode = "01DE002", Count = 3 },
            new() { CardCode = "01DE003", Count = 3 },
            new() { CardCode = "01DE004", Count = 3 },
            new() { CardCode = "01DE005", Count = 3 },
            new() { CardCode = "01DE006", Count = 4 },
            new() { CardCode = "01DE007", Count = 5 },
            new() { CardCode = "01DE008", Count = 6 },
            new() { CardCode = "01DE009", Count = 7 },
            new() { CardCode = "01DE010", Count = 8 },
            new() { CardCode = "01DE011", Count = 9 },
            new() { CardCode = "01DE012", Count = 3 },
            new() { CardCode = "01DE013", Count = 3 },
            new() { CardCode = "01DE014", Count = 3 },
            new() { CardCode = "01DE015", Count = 3 },
            new() { CardCode = "01DE016", Count = 3 },
            new() { CardCode = "01DE017", Count = 3 },
            new() { CardCode = "01DE018", Count = 3 },
            new() { CardCode = "01DE019", Count = 3 },
            new() { CardCode = "01DE020", Count = 3 },
            new() { CardCode = "01DE021", Count = 3 }
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
            new() { CardCode = "01DE002", Count = 40 }
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
            new() { CardCode = "01DE002", Count = 4 },
            new() { CardCode = "01DE003", Count = 4 },
            new() { CardCode = "01DE004", Count = 4 },
            new() { CardCode = "01DE005", Count = 4 },
            new() { CardCode = "01DE006", Count = 4 },
            new() { CardCode = "01DE007", Count = 5 },
            new() { CardCode = "01DE008", Count = 6 },
            new() { CardCode = "01DE009", Count = 7 },
            new() { CardCode = "01DE010", Count = 8 },
            new() { CardCode = "01DE011", Count = 9 },
            new() { CardCode = "01DE012", Count = 4 },
            new() { CardCode = "01DE013", Count = 4 },
            new() { CardCode = "01DE014", Count = 4 },
            new() { CardCode = "01DE015", Count = 4 },
            new() { CardCode = "01DE016", Count = 4 },
            new() { CardCode = "01DE017", Count = 4 },
            new() { CardCode = "01DE018", Count = 4 },
            new() { CardCode = "01DE019", Count = 4 },
            new() { CardCode = "01DE020", Count = 4 },
            new() { CardCode = "01DE021", Count = 4 }
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
            new() { CardCode = "01DE002", Count = 1 },
            new() { CardCode = "01DE003", Count = 2 },
            new() { CardCode = "02DE003", Count = 3 }
        };

        var deck2 = new List<DeckItem>
        {
            new() { CardCode = "01DE003", Count = 2 },
            new() { CardCode = "02DE003", Count = 3 },
            new() { CardCode = "01DE002", Count = 1 }
        };

        string code1 = DeckEncoder.GetCodeFromDeck(deck1);
        string code2 = DeckEncoder.GetCodeFromDeck(deck2);

        Assert.AreEqual(code1, code2);

        var deck3 = new List<DeckItem>
        {
            new() { CardCode = "01DE002", Count = 4 },
            new() { CardCode = "01DE003", Count = 2 },
            new() { CardCode = "02DE003", Count = 3 }
        };

        var deck4 = new List<DeckItem>
        {
            new() { CardCode = "01DE003", Count = 2 },
            new() { CardCode = "02DE003", Count = 3 },
            new() { CardCode = "01DE002", Count = 4 }
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
            new() { CardCode = "01DE002", Count = 4 },
            new() { CardCode = "01DE003", Count = 2 },
            new() { CardCode = "02DE003", Count = 3 },
            new() { CardCode = "01DE004", Count = 5 }
        };

        var deck2 = new List<DeckItem>
        {
            new() { CardCode = "01DE004", Count = 5 },
            new() { CardCode = "01DE003", Count = 2 },
            new() { CardCode = "02DE003", Count = 3 },
            new() { CardCode = "01DE002", Count = 4 }
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
            new() { CardCode = "01DE002", Count = 4 },
            new() { CardCode = "02BW003", Count = 2 },
            new() { CardCode = "02BW010", Count = 3 },
            new() { CardCode = "01DE004", Count = 5 }
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
            new() { CardCode = "01DE002", Count = 4 },
            new() { CardCode = "02BW003", Count = 2 },
            new() { CardCode = "02BW010", Count = 3 },
            new() { CardCode = "04SH047", Count = 5 }
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
            new() { CardCode = "01DE002", Count = 4 },
            new() { CardCode = "03MT003", Count = 2 },
            new() { CardCode = "03MT010", Count = 3 },
            new() { CardCode = "02BW004", Count = 5 }
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
            new() { CardCode = "01DE002", Count = 4 },
            new() { CardCode = "01DE003", Count = 2 },
            new() { CardCode = "02DE003", Count = 3 },
            new() { CardCode = "01DE004", Count = 5 }
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
            new() { CardCode = "01DE02", Count = 1 }
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
        deck.Add(new() { CardCode = "01XX002", Count = 1 });

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
    public void DeckVersionIsTheMinimumLibraryVersionThatSupportsTheContainedFactions(string faction, int expectedVersion)
    {
        List<DeckItem> deck = new();
        deck.Add(new() { CardCode = "01DE001", Count = 1 });
        deck.Add(new() { CardCode = $"01{faction}002", Count = 1 });
        deck.Add(new() { CardCode = "01FR001", Count = 1 });
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
        const string singleCardDeckWithVersion5 = "CUAAAAIBAUAAC";
        Assert.ThrowsException<ArgumentException>(() => DeckEncoder.GetDeckFromCode<DeckItem>(singleCardDeckWithVersion5));
    }

    static bool VerifyRehydration(List<DeckItem> d, List<DeckItem> rehydratedList)
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
