using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.RiotAccountV1;

public class AccountDto : BaseDto
{
    [JsonPropertyName("puuid")]
    public string Puuid { get; set; }

    [JsonPropertyName("gameName")]
    public string? GameName { get; set; }

    [JsonPropertyName("tagLine")]
    public string? TagLine { get; set; }

    [MemberNotNullWhen(true, nameof(GameName), nameof(TagLine))]
    public bool HasRiotID => GameName is not null && TagLine is not null;
}
