using System.Text.Json;
using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kunc.RiotGames.Core.Tests;

[TestClass]
public class JsonStringEnumConverterWithAltNamesTests
{
    [TestMethod]
    public void SerializeToNewName()
    {
        var json = JsonSerializer.Serialize(TestEnum.A);

        Assert.AreEqual($"\"{Constants.first}\"", json);
    }

    [TestMethod]
    public void DeserializeFromNewName()
    {
        var value = JsonSerializer.Deserialize<TestEnum>($"\"{Constants.first}\"");

        Assert.AreEqual(TestEnum.A, value);
    }

    [TestMethod]
    public void DeserializeFromOldName()
    {
        var value = JsonSerializer.Deserialize<TestEnum>($"\"{TestEnum.A}\"");

        Assert.AreEqual(TestEnum.A, value);
    }

    [TestMethod]
    public void DeserdfializeNormal()
    {
        var value = JsonSerializer.Deserialize<TestEnum>($"\"b\"");

        Assert.AreEqual(TestEnum.B, value);
    }

    [TestMethod]
    public void DeserializeFlags()
    {
        var value = JsonSerializer.Deserialize<TestEnum>($"\"LAST, first, B\"");

        Assert.AreEqual(TestEnum.A | TestEnum.C | TestEnum.B, value);
    }
}


[Flags, JsonConverter(typeof(JsonStringEnumConverterWithAltNames<TestEnum>))]
file enum TestEnum
{
    Default,

    [JsonEnumName(Constants.first)]
    A = 1 << 1,

    B = 1 << 2,

    [JsonEnumName(Constants.LAST)]
    C = 1 << 3,
}
file static class Constants
{
    public const string first = nameof(first);
    public const string LAST = nameof(LAST);
}
