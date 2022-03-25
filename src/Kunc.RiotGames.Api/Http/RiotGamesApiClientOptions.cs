using System.Net;

namespace Kunc.RiotGames.Http;

public class RiotGamesApiClientOptions
{
    public TimeSpan Delay { get; set; } = TimeSpan.FromSeconds(1); 
    public string BaseAddress { get; set; } = "https://{0}.api.riotgames.com";
    public HttpStatusCode[] NullSucess { get; set; } = new[] { HttpStatusCode.NotFound };
    public int Retries { get; set; } = -1;
}
