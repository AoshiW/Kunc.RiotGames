using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Shared.Api.Account;

public record Account : BaseDto, IRiotID
{
    /// <summary>
    /// Account's Puuid.
    /// </summary>
    [JsonPropertyName("puuid")]
    public string Puuid { get; init; } = default!;

    /// <inheritdoc/>
    [JsonPropertyName("gameName")]
    public string? GameName { get; init; }

    /// <inheritdoc/>
    [JsonPropertyName("tagLine")]
    public string? TagLine { get; init; }

    /// <inheritdoc/>
    [JsonIgnore, MemberNotNullWhen(true, nameof(GameName), nameof(TagLine))]
    public bool HasRiotID =>  !string.IsNullOrEmpty(GameName) && !string.IsNullOrEmpty(TagLine);
}
