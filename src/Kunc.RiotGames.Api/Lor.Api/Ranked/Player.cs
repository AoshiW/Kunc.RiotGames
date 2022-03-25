using Kunc.RiotGames.JsonConverters;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lor.Api.Ranked;

public record Player : BaseDto
{
    /// <summary>
    /// Player's name.
    /// </summary>
    public string Name { get; init; } = default!;

    /// <summary>
    /// Rank in current tier.
    /// </summary>
    public int Rank { get; init; }

    /// <summary>
    /// League points.
    /// </summary>
    [JsonConverter(typeof(Int32Converter))]
    public int LP { get; init; }
}