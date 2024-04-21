using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolMatchV5;

public class ParticipantTimelineDto : BaseDto
{
    [JsonPropertyName("participantId")]
    public int ParticipantId { get; set; }

    /// <summary>
    /// Player Universal Unique Identifier.
    /// </summary>
    [JsonPropertyName("puuid")]
    public string Puuid { get; set; } = string.Empty;
}
