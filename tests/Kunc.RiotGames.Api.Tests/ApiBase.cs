using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kunc.RiotGames.Api.Tests;

public class ApiBase
{
    static readonly IConfiguration Configuration = new ConfigurationManager()
        .AddJsonFile("appsettings.json", true)
        .AddJsonFile("appsettings.Development.json", false)
        .AddEnvironmentVariables()
        .Build();

    protected static readonly IRiotGamesApi api = new ServiceCollection()
        .AddSingleton<IConfiguration>(Configuration)
        .AddRiotGamesApi(c => c.ApiKey = Configuration["RGAPIKEY"]!)
        .BuildServiceProvider()
        .GetRequiredService<IRiotGamesApi>();

    //todo move all fields to appsettings.json file 
    protected const string Puuid = "myX6hakkZP-iqDRVz2qu9EuggqMf6kzzMZpnTGgItkPiA1t8nGD4ogGEJZYOgU49sKzNP8QGJgn0OA";
    protected const string SummonerId = "nsWGILVTyUc2ixBlPQkzsbHfUJataEZ23suzfeRn5LcO1iw";

    protected static readonly (string GameName, string TagLine) RiotId = ("Aoshi W", "IRON");
}
