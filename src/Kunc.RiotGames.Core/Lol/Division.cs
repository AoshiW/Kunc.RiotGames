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
