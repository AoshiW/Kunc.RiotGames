namespace Kunc.RiotGames.Lol.LeagueClientUpdate.Test;

[TestClass]
public class WampEvents
{
    static readonly NullWamp Wamp = new();
    static readonly Func<LolLeagueClientUpdate> NewLcu = () => new(Lockfile.Empty, Wamp);

    [TestMethod]
    public void Test()
    {
        var lcu = NewLcu();
        const string url1 = "random";
        var isInvoked = new Wrapper<bool>();
        lcu.Subscribe(url1, isInvoked.EventHandler);

        Wamp.InvokeOnMessage(new LcuEventArgs<string>()
        {
            Data = "Null",
            EventType = "Create",
            Uri = url1 + "wrong",
        });
        Assert.IsFalse(isInvoked.Value);

        Wamp.InvokeOnMessage(new LcuEventArgs<string>()
        {
            Data = "Null",
            EventType = "Create",
            Uri = url1,
        });
        Assert.IsTrue(isInvoked.Value);
    }

    [TestMethod]
    public void CheckEventInvocationWhenIfExceptionIsThrow()
    {
        var lcu = NewLcu();
        const string url1 = "random";
        var isInvoked = new Wrapper<bool>();
#pragma warning disable CA2201, IDE0053 // Do not raise reserved exception types, Use expression body for lambda expression
        lcu.Subscribe(url1, () => { throw new Exception(); });
#pragma warning restore CA2201, IDE0053 // Do not raise reserved exception types, Use expression body for lambda expression
        lcu.Subscribe(url1, isInvoked.EventHandler);

        Wamp.InvokeOnMessage(new LcuEventArgs<string>()
        {
            Data = "Null",
            EventType = "Create",
            Uri = url1,
        });
        Assert.IsTrue(isInvoked.Value);
    }

    [TestMethod]
    public void SubscribeAllTest()
    {
        var lcu = NewLcu();
        var obj = new SomeClass();
        lcu.SubscribeAll(obj);

        Wamp.InvokeOnMessage(new LcuEventArgs<string>()
        {
            Data = "Null",
            EventType = "Create",
            Uri = "url2",
        });
        Assert.IsFalse(obj.IsInvoked.Value);

        Wamp.InvokeOnMessage(new LcuEventArgs<string>()
        {
            Data = "Null",
            EventType = "Create",
            Uri = "url",
        });
        Assert.IsTrue(obj.IsInvoked.Value);
    }

    [TestMethod]
    public void Unsubscribe()
    {
        var lcu = NewLcu();
        const string url1 = "random";
        var isInvoked = new Wrapper<bool>();
        lcu.Subscribe(url1, isInvoked.EventHandler);

        Wamp.InvokeOnMessage(new LcuEventArgs<string>()
        {
            Data = "Null",
            EventType = "Create",
            Uri = url1,
        });
        Assert.IsTrue(isInvoked.Value);
        isInvoked.Value = false;
        lcu.Unsubscribe(url1, isInvoked.EventHandler);
        Wamp.InvokeOnMessage(new LcuEventArgs<string>()
        {
            Data = "Null",
            EventType = "Create",
            Uri = url1,
        });
        Assert.IsFalse(isInvoked.Value);
    }
}

class SomeClass
{
    public Wrapper<bool> IsInvoked { get; set; } = new();

    [LcuEvent("url")]
    public void M1()
    {
        IsInvoked.EventHandler(this, EventArgs.Empty);
    }

    [LcuEvent("url2")]
    public void M2()
    {
    }
}

class SomeClass2
{
    public Wrapper<bool> IsInvoked { get; set; } = new();

    [LcuEvent("url", EventType = "Create")]
    public void M1()
    {
        IsInvoked.EventHandler(this, EventArgs.Empty);
    }
}
