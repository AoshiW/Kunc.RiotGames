using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.RiotAccountV1;

public class AccountDto : BaseDto
{
    /// <summary>
    /// Player Universal Unique Identifier.
    /// </summary>
    [JsonPropertyName("puuid")]
    public string Puuid { get; set; } = string.Empty;

    [JsonPropertyName("gameName")]
    public string? GameName { get; set; }

    [JsonPropertyName("tagLine")]
    public string? TagLine { get; set; }

    [JsonIgnore, MemberNotNullWhen(true, nameof(GameName), nameof(TagLine))]
    public bool HasRiotId => GameName is not null && TagLine is not null;

    public RiotId GetRiotId()
    {
        return HasRiotId
            ? new(GameName, TagLine)
            : throw new InvalidOperationException("Riot id is not set.");
    }
}
