using System.Text.Json.Serialization;
using Kunc.RiotGames.Lol;

namespace Kunc.RiotGames.Api.TftLeagueV1;

public class LeagueListDto : BaseDto
{
    [JsonPropertyName("leagueId")]
    public Guid LeagueId { get; set; }
    
    [JsonPropertyName("entries")]
    public LeagueItemDto[] Entries { get; set; } = [];

    [JsonPropertyName("tier")]
    public Tier Tier { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("queue")]
    public QueueType Queue { get; set; }
}
