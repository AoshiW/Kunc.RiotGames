#pragma warning disable CA1707 // Identifiers should not contain underscores
using System.Security.Cryptography;
using System.Text;

namespace Kunc.RiotGames.Lor.DeckCodes.Tests;

[TestClass]
public class Base32Test
{
    [TestMethod]
    public void ConversionTest() // test from .NET Github
    {
        var data = new byte[] { 1, 2, 3, 4, 5, 6 };
        Assert.IsTrue(data.SequenceEqual(Base32.FromBase32(Base32.ToBase32(data))));

        int length;
        do
        {
            length = GetRandomByteArray(1)[0];
        } while (length % 5 == 0);
        data = GetRandomByteArray(length);
        Assert.IsTrue(data.SequenceEqual(Base32.FromBase32(Base32.ToBase32(data))));

        length = GetRandomByteArray(1)[0] * 5;
        data = GetRandomByteArray(length);
        Assert.IsTrue(data.SequenceEqual(Base32.FromBase32(Base32.ToBase32(data))));
    }

    private static readonly RandomNumberGenerator _rng = RandomNumberGenerator.Create();

    private static byte[] GetRandomByteArray(int length)
    {
        byte[] bytes = new byte[length];
        _rng.GetBytes(bytes);
        return bytes;
    }

    static IEnumerable<object[]> TestData { get; } = new[]
    {
        new[] { "", "" },
        new[] {"f", "MY======" },
        new[] {"fo", "MZXQ====" },
        new[] {"foo", "MZXW6===" },
        new[] {"foob", "MZXW6YQ=" },
        new[] {"fooba", "MZXW6YTB" },
        new[] {"foobar", "MZXW6YTBOI======" },
        new[] {"foobar1", "MZXW6YTBOIYQ====" },
        new[] {"foobar12", "MZXW6YTBOIYTE===" },
        new[] {"foobar123", "MZXW6YTBOIYTEMY=" },
        new[] {"1234567890123456789012345678901234567890", "GEZDGNBVGY3TQOJQGEZDGNBVGY3TQOJQGEZDGNBVGY3TQOJQGEZDGNBVGY3TQOJQ" },
    };

    [TestMethod]
    [DynamicData(nameof(TestData))]
    public void ToBase32(string input, string expectedOutput)
    {
        byte[] bytes = Encoding.ASCII.GetBytes(input);
        string result = Base32.ToBase32(bytes);
        Assert.AreEqual(result, expectedOutput);
    }

    [TestMethod]
    [DynamicData(nameof(TestData))]
    public void ToBase32_RemovePadding(string input, string expectedOutput)
    {
        byte[] bytes = Encoding.ASCII.GetBytes(input);
        string result = Base32.ToBase32(bytes, Base32FormattingOptions.RemovePadding);
        Assert.AreEqual(result, expectedOutput.Trim('='));
    }

    [TestMethod]
    [DynamicData(nameof(TestData))]
    public void FromBase32(string expectedOutput, string input)
    {
        var bytes = Base32.FromBase32(input);
        string result = Encoding.ASCII.GetString(bytes.ToArray());
        Assert.AreEqual(result, expectedOutput);
        bytes = Base32.FromBase32(input.ToLowerInvariant());
        result = Encoding.ASCII.GetString(bytes.ToArray());
        Assert.AreEqual(result, expectedOutput);
    }

    [TestMethod]
    public void FromBase32_ThrowsFormatException()
    {
        Assert.ThrowsException<FormatException>(() => Base32.FromBase32("[];',m."));
    }
}
