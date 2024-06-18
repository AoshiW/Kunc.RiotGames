using System.Text.Json;
using Microsoft.Extensions.Options;

namespace Kunc.RiotGames.Lor.GameClient;

/// <summary>
/// Options for the <see cref="LorGameClient"/>.
/// </summary>
public class LorGameClientOptions : IOptions<LorGameClientOptions>
{
    /// <summary>
    /// Options to control the behavior during deserialization.
    /// </summary>
    public JsonSerializerOptions? JsonSerializerOptions { get; set; }

    public int Port { get; set; } = 21337;

    LorGameClientOptions IOptions<LorGameClientOptions>.Value => this;
}
