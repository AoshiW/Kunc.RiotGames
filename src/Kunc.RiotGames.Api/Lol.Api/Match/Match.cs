using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api.Match;

public record Match : BaseDto, IJsonOnDeserialized
{
    /// <summary>
    /// Match metadata.
    /// </summary>
    [JsonPropertyName("metadata")]
    public MatchMetadata Metadata { get; init; } = default!;

    /// <summary>
    /// Match info.
    /// </summary>
    [JsonPropertyName("info")]
    public Info Info { get; init; } = default!;

    private static Version? s_version;
    private static Version Version => s_version ??= new(11, 20);
    void IJsonOnDeserialized.OnDeserialized()
    {
        //Prior to patch 11.20, this field returns the game length in milliseconds calculated from gameEndTimestamp -gameStartTimestamp.
        //Post patch 11.20, this field returns the max timePlayed of any participant in the game in seconds, which makes the behavior of this field consistent with that of match-v4.
        //The best way to handling the change in this field is to treat the value as milliseconds if the gameEndTimestamp field isn't in the response and to treat the value as seconds if gameEndTimestamp is in the response.
        if (Info.GameEnd == default)
        {
            var gameDuration = TimeSpan.FromMilliseconds(Info.GameDuration.TotalSeconds);
            Info.FixGameDurationAndEnd(gameDuration, Info.GameStart + gameDuration);
        }
    }
}
