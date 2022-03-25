using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api.Spectator;

public record CurrentGameParticipant : Participant
{
    /// <summary>
    /// List of Game Customizations.
    /// </summary>
    [JsonPropertyName("gameCustomizationObjects")]
    public GameCustomizationObject[] GameCustomizationObjects { get; init; } = default!;

    /// <summary>
    /// The encrypted summoner ID of this participant.
    /// </summary>
    [JsonPropertyName("summonerId")]
    public string SummonerId { get; init; } = default!;

    /// <summary>
    /// Perks/Runes Reforged Information.
    /// </summary>
    [JsonPropertyName("perks")]
    public Perks Perks { get; init; } = default!;
}