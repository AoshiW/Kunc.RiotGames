using Kunc.RiotGames.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utils;

namespace Kunc.RiotGames.Api.Test.Lor;

[TestClass]
public class AccountV1Test
{
    [TestMethod]
    public async Task GetAccountAsync_RiotId()
    {
        var accouunt = await Api.LorApi.AccountV1.GetAccountAsync(Region.Europe, Api.GameName, Api.TafLine);

        Assert.IsNotNull(accouunt);
        Assert.That.CheckJsonExtensionData(accouunt);
        Assert.That.CheckNullabilityInfo(accouunt);
    }

    [TestMethod]
    public async Task GetAccountAsync_Puuid()
    {
        var accouunt = await Api.LorApi.AccountV1.GetAccountAsync(Region.Europe, Api.GameName, Api.TafLine);
        accouunt = await Api.LorApi.AccountV1.GetAccountAsync(Region.Europe, accouunt!.Puuid);

        Assert.IsNotNull(accouunt);
        Assert.That.CheckJsonExtensionData(accouunt);
        Assert.That.CheckNullabilityInfo(accouunt);
    }


    [TestMethod]
    public async Task GetAccountAsync_IsNull()
    {
        var accouunt = await Api.LorApi.AccountV1.GetAccountAsync(Region.Europe, Api.GameName, "0123456");

        Assert.IsNull(accouunt);
    }


    [TestMethod]
    public async Task GetLorActiveShardAsync()
    {
        var accouunt = await Api.LorApi.AccountV1.GetAccountAsync(Region.Europe, Api.GameName, Api.TafLine);
        var activeShard = await Api.LorApi.AccountV1.GetLorActiveShardAsync(Region.Europe, accouunt!.Puuid);

        Assert.IsNotNull(activeShard);
        Assert.That.CheckJsonExtensionData(activeShard);
        Assert.That.CheckNullabilityInfo(activeShard);
    }
}

[TestClass]
public class MatchV1Test
{
    //[TestMethod]
    //public async Task GetAccountAsync_RiotId()
    //{
    //    var accouunt = await Api.LorApi.MatchV1.GetListOfMatchIdsAsync(Region.Europe, Api.GameName, Api.TafLine);

    //    Assert.IsNotNull(accouunt);
    //    Assert.That.CheckJsonExtensionData(accouunt);
    //    Assert.That.CheckNullabilityInfo(accouunt);
    //}

    //[TestMethod]
    //public async Task GetAccountAsync_Puuid()
    //{
    //    var accouunt = await Api.LorApi.MatchV1.GetListOfMatchIdsAsync(Region.Europe, Api.GameName, Api.TafLine);
    //    accouunt = await Api.LorApi.MatchV1.GetMatchAsync(Region.Europe, accouunt!.Puuid);

    //    Assert.IsNotNull(accouunt);
    //    Assert.That.CheckJsonExtensionData(accouunt);
    //    Assert.That.CheckNullabilityInfo(accouunt);
    //}
}

[TestClass]
public class RankedV1Test
{
    [TestMethod]
    public async Task GetAccountAsync_RiotId()
    {
        var leaderboard = await Api.LorApi.RankedV1.GetLeaderboardAsync(Region.Europe);

        Assert.IsNotNull(leaderboard);
        Assert.That.CheckJsonExtensionData(leaderboard);
        Assert.That.CheckNullabilityInfo(leaderboard);
    }
}
