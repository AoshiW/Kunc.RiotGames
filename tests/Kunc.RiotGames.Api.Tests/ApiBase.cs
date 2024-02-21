using Microsoft.Extensions.DependencyInjection;

namespace Kunc.RiotGames.Api.Tests;

public class ApiBase
{
    protected static readonly IRiotGamesApi api = new ServiceCollection()
        .AddRiotGamesApi(c => c.ApiKey = "RGAPI-450b1174-1cb7-4ab9-86e6-f6e37a47333b")
        .BuildServiceProvider()
        .GetRequiredService<IRiotGamesApi>();

    protected const string Puuid = "myX6hakkZP-iqDRVz2qu9EuggqMf6kzzMZpnTGgItkPiA1t8nGD4ogGEJZYOgU49sKzNP8QGJgn0OA";

    protected static readonly (string GameName, string TagLine) RiotId = ("Aoshi W", "IRON");
}
