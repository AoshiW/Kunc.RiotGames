using System.Text.Json.Serialization;
using Kunc.RiotGames.Lol;

namespace Kunc.RiotGames.Api.LolMatchV5;

public class TeamDto : BaseDto
{
    [JsonPropertyName("bans")]
    public BanDto[] Bans { get; set; } = [];

    [JsonPropertyName("objectives")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public ObjectivesDto Objectives { get; set; } = new();

    [JsonPropertyName("teamId")]
    public TeamId TeamId { get; set; }

    [JsonPropertyName("win")]
    public bool IsWinner { get; set; }
}
