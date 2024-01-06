using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon.Champion;

[DebuggerDisplay($"{nameof(Attack)}: {{{nameof(Attack)}}}, {nameof(Defense)}: {{{nameof(Defense)}}}, {nameof(Magic)}: {{{nameof(Magic)}}}, {nameof(Difficulty)}: {{{nameof(Difficulty)}}}")]
public class ChamionInfoDto : BaseDto
{
    [JsonPropertyName("attack")]
    public int Attack { get; set; }

    [JsonPropertyName("defense")]
    public int Defense { get; set; }

    [JsonPropertyName("magic")]
    public int Magic { get; set; }

    [JsonPropertyName("difficulty")]
    public int Difficulty { get; set; }
}
