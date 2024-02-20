using System.Text.Json;

namespace Kunc.RiotGames.Api;

public class RiotGamesApiOptions
{
    public string ApiKey { get; set; }

    public TimeSpan Delay { get; set; }

    public JsonSerializerOptions JsonSerializerOptions { get; set; } = new()
    {

    };
}
