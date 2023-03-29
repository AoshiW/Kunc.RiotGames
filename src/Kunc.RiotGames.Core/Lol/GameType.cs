using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol;
/// <summary>
/// League of Legends game types.
/// </summary>
[JsonConverter(typeof(GameTypeConverter))]
public enum GameType
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    CustomGame,
    TutorialGame,
    MatchedGame,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}

class GameTypeConverter : JsonConverter<GameType>
{
    static ReadOnlySpan<byte> CUSTOM_GAME => "CUSTOM_GAME"u8;
    static ReadOnlySpan<byte> TUTORIAL_GAME => "TUTORIAL_GAME"u8;
    static ReadOnlySpan<byte> MATCHED_GAME => "MATCHED_GAME"u8;

    public override GameType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var span = reader.ValueSpan;
#pragma warning disable IDE0046 // Convert to conditional expression
        if (span.SequenceEqual(CUSTOM_GAME))
            return GameType.CustomGame;
        else if (span.SequenceEqual(TUTORIAL_GAME))
            return GameType.TutorialGame;
        else if (span.SequenceEqual(MATCHED_GAME))
            return GameType.MatchedGame;
        else
            throw new NotImplementedException();
#pragma warning restore IDE0046 // Convert to conditional expression
    }

    public override void Write(Utf8JsonWriter writer, GameType value, JsonSerializerOptions options)
    {
        var span = value switch
        {
            GameType.CustomGame => CUSTOM_GAME,
            GameType.TutorialGame => TUTORIAL_GAME,
            GameType.MatchedGame => MATCHED_GAME,
            _ => throw new NotImplementedException()
        };
        writer.WriteStringValue(span);
    }
}
