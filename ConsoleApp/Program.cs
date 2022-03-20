using Kunc.RiotGames.Lol.GameClient;

Console.WriteLine("Hello, Kunc.RiotGames!");
var versions = await LolDataDragon.GetVersionsAsync();
var t = await LolDataDragon.GetAllChampionsAsync(versions[0], "cs_CZ");
foreach (var item in t.Select(x=>x.Partype).ToHashSet())
{
    Console.WriteLine(item);
}
;