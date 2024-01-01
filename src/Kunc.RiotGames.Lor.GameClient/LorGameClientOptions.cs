using System.Text.Json;
using Microsoft.Extensions.Options;

namespace Kunc.RiotGames.Lor.GameClient;

public class LorGameClientOptions : IOptions<LorGameClientOptions>
{
    /// <summary>
    /// Options to control the behavior during deserialization.
    /// </summary>
    public JsonSerializerOptions JsonSerializerOptions { get; set; } = new()
    {
        TypeInfoResolver = JsonContext.Default
    };

    public int Port { get; set; } = 21337;

    LorGameClientOptions IOptions<LorGameClientOptions>.Value => this;
}
