using Kunc.RiotGames.Extensions;
using Kunc.RiotGames.Lor.DeckCodes;

Console.WriteLine("Hello, Kunc.RiotGames!");

var d = LorDeckEncoder.GetDeckFromCode<DeckItem>("CQCACAYCAIAQIAAOAQCQUKSJMSIQCBQBAAGREGA5E4YQCAIBAARAEAIBAQEACAQGFY");

var acc = await LorApi.AccountV1.GetAccountAsync(Kunc.RiotGames.Region.Europe, "AoshiW", "iron");
var shard = await LorApi.AccountV1.GetLorActiveShardAsync(Kunc.RiotGames.Region.Europe, acc!.Puuid);
var ml = await LorApi.MatchV1.GetListOfMatcIdsAsync(shard!);
foreach (var item in ml)
{
    var m = await LorApi.MatchV1.GetMatchAsync(item);
}
var matchs = ml.Select(x=>LorApi.MatchV1.GetMatchAsync(x).GetAwaiter().GetResult()).ToArray();    
;