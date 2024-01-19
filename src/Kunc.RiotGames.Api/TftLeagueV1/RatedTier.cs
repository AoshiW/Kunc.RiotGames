using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.TftLeagueV1;

[JsonConverter(typeof(JsonStringEnumConverter<RatedTier>))]
public enum RatedTier
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Orange,
    Purple,
    Blue,
    Green,
    Gray,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
