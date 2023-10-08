#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol;

#if NET8_0_OR_GREATER
[JsonConverter(typeof(JsonStringEnumConverter<Division>))]
#else
[JsonConverter(typeof(JsonStringEnumConverter))]
#endif
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
