using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Lol;
/// <summary>
/// League of Legends game types.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverterWithAltNames<GameType>))]
public enum GameType
{
    [JsonEnumName("CUSTOM_GAME")]
    CustomGame,

    [JsonEnumName("TUTORIAL_GAME")]
    TutorialGame,

    [JsonEnumName("MATCHED_GAME")]
    MatchedGame,

    Matched,
}
