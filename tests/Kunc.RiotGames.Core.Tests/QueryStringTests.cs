namespace Kunc.RiotGames.Core.Tests;

[TestClass]
public class QueryStringTests
{
    [TestMethod]
    public void ToStringTest()
    {
        var i = 5;
        var s = "asd";
        var opt = new SomeOptions()
        {
            MyInt = i,
        };
        Assert.AreEqual($"?{nameof(opt.MyInt)}={i}", opt.ToString());

        opt.MyString = s;
        Assert.AreEqual($"?{nameof(opt.MyInt)}={i}&{nameof(opt.MyString)}={s}", opt.ToString());
    }

    class SomeOptions : QueryString
    {
        public int? MyInt { get; set; }
        public string? MyString { get; set; }

        protected override void ToStringCore(ref QueryStringBuilder builder)
        {
            if (MyInt.HasValue)
                builder.Append(nameof(MyInt), MyInt.Value);
            if (MyString is not null)
                builder.Append(nameof(MyString), MyString);
        }
    }
}
