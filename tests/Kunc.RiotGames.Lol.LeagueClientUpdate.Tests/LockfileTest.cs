using System.Text;

namespace Kunc.RiotGames.Lol.LeagueClientUpdate.Test;

[TestClass]
public class LockfileTest
{
    const string TestData = "LeagueClient:11784:53453:zKLoQxuPDFO3_0ZVSwQjQQ:https";

    [TestMethod]
    [DataRow(TestData)]
    public void Parse(string lockfileData)
    {
        if (!Lockfile.TryParse(lockfileData, null, out var lockfile))
            Assert.Fail();
        Assert.AreEqual(lockfileData, lockfile.ToString());
    }

    [TestMethod]
    public async Task FromFileAsync()
    {
        var lockfile = await Lockfile.FromFileAsync("lockfile");

        Assert.IsNotNull(lockfile);
    }

    [TestMethod]
    public async Task AuthenticationHeaderValue()
    {
        var lockfile = Lockfile.Parse(TestData, null);

        var authHeaderValue = lockfile.ToAuthenticationHeaderValue();
        var bytes = Convert.FromBase64String(authHeaderValue.Parameter!);
        var userPassword = Encoding.ASCII.GetString(bytes);

        Assert.AreEqual($"riot:{lockfile.Password}", userPassword);
    }
}
