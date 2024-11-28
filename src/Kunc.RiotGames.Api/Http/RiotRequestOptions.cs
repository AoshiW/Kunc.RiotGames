namespace Kunc.RiotGames.Api.Http;

public class RiotRequestOptions
{
    internal static readonly RiotRequestOptions Default = new();

    public bool IncludeApiKey { get; set; } = true;
}
