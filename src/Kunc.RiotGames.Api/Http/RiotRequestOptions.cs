namespace Kunc.RiotGames.Api.Http;

public class RiotRequestOptions
{
    static internal readonly RiotRequestOptions Default = new();

    public bool IncludeApiKey { get; set; } = true;
}
