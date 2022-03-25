using Kunc.RiotGames.Lol.Api;
using Kunc.RiotGames.Lor.Api;
using Kunc.RiotGames.Tft.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kunc.RiotGames.Api.Test;

[TestClass]
public static class Api
{
    public static ILorApi LorApi { get; private set; } = default!;
    public static ILolApi LolApi { get; private set; } = default!;
    public static ITftApi TftApi { get; private set; } = default!;

    public const string GameName = "AoshiW";
    public const string TafLine = "Iron";

    [AssemblyInitialize]
    public static void AssemblyInit(TestContext context)
    {
        string apikey = "RGAPI-4b707e48-012d-4791-b7fe-e507c5d8878e";
        LorApi = new LorApi(apikey);
        LolApi = new LolApi(apikey);
        TftApi = new TftApi(apikey);
    }
}
