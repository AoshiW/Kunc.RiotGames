using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;

namespace Kunc.RiotGames.Lol.DataDragon;

/// <summary>
/// Options for the <see cref="LolDataDragon"/>.
/// </summary>
public class LolDataDragonOptions : IOptions<LolDataDragonOptions>
{
    public string BaseAdress { get; set; } = "https://ddragon.leagueoflegends.com";

    public DistributedCacheEntryOptions? DefaultCacheEntryOptions { get; set; }

    /// <summary>
    /// Options to control the behavior during deserialization.
    /// </summary>
    public JsonSerializerOptions? JsonSerializerOptions { get; set; }

    LolDataDragonOptions IOptions<LolDataDragonOptions>.Value => this;
}
