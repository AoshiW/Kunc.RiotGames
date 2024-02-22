using Microsoft.Extensions.DependencyInjection;

namespace Kunc.RiotGames.Api.Tests;

public class ApiBase
{
    protected static readonly IRiotGamesApi api = new ServiceCollection()
        .AddRiotGamesApi(c => c.ApiKey = "RGAPI-749afbb0-5a3a-432c-97b9-850dde23b1fc")
        .BuildServiceProvider()
        .GetRequiredService<IRiotGamesApi>();

    protected const string Puuid = "myX6hakkZP-iqDRVz2qu9EuggqMf6kzzMZpnTGgItkPiA1t8nGD4ogGEJZYOgU49sKzNP8QGJgn0OA";
    protected const string SummonerId = "nsWGILVTyUc2ixBlPQkzsbHfUJataEZ23suzfeRn5LcO1iw";

    protected static readonly (string GameName, string TagLine) RiotId = ("Aoshi W", "IRON");
}
