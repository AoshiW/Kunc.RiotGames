using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api.Match;

public record ParticipantInfo : BaseDto
{
    [JsonPropertyName("participantId")]
    public int ParticipantId { get; init; }

    [JsonPropertyName("puuid")]
    public string Puuid { get; init; } = default!;
}