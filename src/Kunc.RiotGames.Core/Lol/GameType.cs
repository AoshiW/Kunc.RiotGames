using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol;

[JsonConverter(typeof(GameTypeConverter))]
public enum GameType
{
    CustomGame,
    TutorialGame,
    MatchedGame,
}

class GameTypeConverter : JsonConverter<GameType>
{
    static ReadOnlySpan<byte> CUSTOM_GAME => "CUSTOM_GAME"u8;
    static ReadOnlySpan<byte> TUTORIAL_GAME => "TUTORIAL_GAME"u8;
    static ReadOnlySpan<byte> MATCHED_GAME => "MATCHED_GAME"u8;

    public override GameType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var span = reader.ValueSpan;
        if (span.SequenceEqual(CUSTOM_GAME))
            return GameType.CustomGame;
        else if(span.SequenceEqual(TUTORIAL_GAME))
            return GameType.TutorialGame;
        else if(span.SequenceEqual(MATCHED_GAME))
            return GameType.MatchedGame;
        else
            throw new NotImplementedException();
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
