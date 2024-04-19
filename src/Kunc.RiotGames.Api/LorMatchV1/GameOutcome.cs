using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LorMatchV1;

[JsonConverter(typeof(JsonStringEnumConverter<GameOutcome>))]
public enum GameOutcome
{
    Win,
    Tie,
    Loss,
}
