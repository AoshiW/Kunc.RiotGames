#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Division
{
    None,
    I,
    II,
    III,
    IV
}

internal static class DivisionExtensions
{
    public static string ToFastString(this Division division)
    {
        return division switch
        {
            Division.None => nameof(Division.None),
            Division.I => nameof(Division.I),
            Division.II => nameof(Division.II),
            Division.III => nameof(Division.III),
            Division.IV => nameof(Division.IV),
            _ => division.ToString()
        };
    }
}
