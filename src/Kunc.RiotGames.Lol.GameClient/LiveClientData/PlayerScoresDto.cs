using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

public class PlayerScoresDto : BaseDto, IKda
{
    [JsonPropertyName("assists")]
    public int Assists { get; set; }

    [JsonPropertyName("creepScore")]
    public int CreepScore { get; set; }

    [JsonPropertyName("deaths")]
    public int Deaths { get; set; }

    [JsonPropertyName("kills")]
    public int Kills { get; set; }

    [JsonPropertyName("wardScore")]
    public double WardScore { get; set; }
}
