using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolChallengesV1;

[JsonConverter(typeof(JsonStringEnumConverter<Tracking>))]
public enum Tracking
{
    /// <summary>
    /// stats are incremented without reset
    /// </summary>
    Lifetime,
    
    /// <summary>
    /// stats are accumulated by season and reset at the beginning of new season
    /// </summary>
    Season,
}
