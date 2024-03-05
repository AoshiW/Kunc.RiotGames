using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol;
/// <summary>
/// League of Legends game types.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<GameType>))]
public enum GameType
{
    CUSTOM_GAME,
    TUTORIAL_GAME,
    MATCHED_GAME,
    MATCHED
}
