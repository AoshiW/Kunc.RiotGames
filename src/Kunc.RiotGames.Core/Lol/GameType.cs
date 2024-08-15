using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Lol;
/// <summary>
/// League of Legends game types.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverterWithAltNames<GameType>))]
public enum GameType
{
    [JsonStringEnumMemberName("")]
    EmptyString,

    [JsonStringEnumMemberName("CUSTOM_GAME")]
    CustomGame,

    [JsonStringEnumMemberName("TUTORIAL_GAME")]
    TutorialGame,

    [JsonStringEnumMemberName("MATCHED_GAME")]
    MatchedGame,

    Matched,
}
