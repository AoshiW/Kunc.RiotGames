using Kunc.RiotGames.Api;

Console.WriteLine("Hello, Kunc.RiotGames!");

var puuid = "myX6hakkZP-iqDRVz2qu9EuggqMf6kzzMZpnTGgItkPiA1t8nGD4ogGEJZYOgU49sKzNP8QGJgn0OA";
var ml = await Api.LolMatchV5.GetListOfMatchIdsAsync(Regions.EUROPE, puuid, new()
{
    Count = 100
});
foreach (var matchId in ml)
{
    try
    {

        var match = await Api.LolMatchV5.GetMatchAsync(Regions.EUROPE, matchId);
        var timeline = await Api.LolMatchV5.GetMatchTimelineAsync(Regions.EUROPE, matchId);
    }
    catch (Exception ex)
    {
        ;
    }
}
