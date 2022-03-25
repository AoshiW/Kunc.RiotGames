using System.Text.Json.Serialization;

namespace Kunc.RiotGames;

/// <summary>
/// Regional routing values.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Region
{
    /// <summary>
    /// Americas
    /// </summary>
    Americas,

    /// <summary>
    /// Asia
    /// </summary>
    Asia,

    Esports,

    /// <summary>
    /// Europe
    /// </summary>
    Europe,

    /// <summary>
    /// Southeast Asia
    /// </summary>
    Sea,
}
