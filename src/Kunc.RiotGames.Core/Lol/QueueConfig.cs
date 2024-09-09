using System.Collections.Frozen;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol;

[Experimental(DiagnosticIds.KNCRG0000, UrlFormat = DiagnosticIds.UrlFormat)]
[JsonConverter(typeof(QueueConverter))]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public class QueueConfig : IEquatable<QueueConfig?>
{
    internal static readonly QueueConfig Default;
    private static readonly FrozenDictionary<int, QueueConfig> Queues;
    private readonly QueueFlags _flags;

    public int QueueId { get; }

    public MapId Map { get; }
    public GameMode GameMode { get; }

    public static implicit operator QueueConfig(int queueId)
    {
        return Queues.TryGetValue(queueId, out var queue)
            ? queue
            : new(queueId, MapId.None, GameMode.EmptyString, QueueFlags.None);
    }

    static QueueConfig()
    {
        var queues = new Dictionary<int, QueueConfig>();

        Default = new(0, MapId.None, GameMode.EmptyString, QueueFlags.None);
        queues.Add(Default.QueueId, Default);

        Add(400, MapId.SummonersRiftV2, GameMode.Classic, QueueFlags.PvP); // 5v5 Draft Pick
        Add(420, MapId.SummonersRiftV2, GameMode.Classic, QueueFlags.PvP | QueueFlags.Ranked); // 5v5 Ranked Solo/Duo
        Add(440, MapId.SummonersRiftV2, GameMode.Classic, QueueFlags.PvP | QueueFlags.Ranked); // 5v5 Ranked Flex
        Add(450, MapId.HowlingAbyss, GameMode.Aram, QueueFlags.PvP); // Aram
        Add(490, MapId.SummonersRiftV2, GameMode.Classic, QueueFlags.PvP); // 5v5 Normal (Quickplay)
        Add(870, MapId.SummonersRiftV2, GameMode.TutorialModule1, QueueFlags.Bots); // Co-op vs. AI Intro Bot games
        Add(880, MapId.SummonersRiftV2, GameMode.TutorialModule2, QueueFlags.Bots); // Co-op vs. AI Beginner Bot games
        Add(890, MapId.SummonersRiftV2, GameMode.TutorialModule3, QueueFlags.Bots); // Co-op vs. AI Intermediate Bot games
        Add(1090, MapId.Convergence, GameMode.Tft, QueueFlags.PvP); // TFT Normal
        Add(1100, MapId.Convergence, GameMode.Tft, QueueFlags.PvP | QueueFlags.Ranked); // TFT Ranked
        Add(1130, MapId.Convergence, GameMode.Tft, QueueFlags.PvP); // TFT Hyper roll
        Add(1160, MapId.Convergence, GameMode.Tft, QueueFlags.PvP); // TFT Double up (workshop)
        Add(1220, MapId.Convergence, GameMode.Tft, QueueFlags.PvE);
        Add(1700, MapId.RingsOfWrath, GameMode.Cherry, QueueFlags.PvP); // Arena
        Add(1810, MapId.Strawberry, GameMode.Strawberry, QueueFlags.PvE); // Swarm Solo
        Add(1820, MapId.Strawberry, GameMode.Strawberry, QueueFlags.PvE); // Swarm 2 Members
        Add(1830, MapId.Strawberry, GameMode.Strawberry, QueueFlags.PvE); // Swarm 3 Members
        Add(1840, MapId.Strawberry, GameMode.Strawberry, QueueFlags.PvE); // Swarm 4 Members

        Queues = queues.ToFrozenDictionary();

        void Add(int queueId, MapId map, GameMode gameMode, QueueFlags flags)
        {
            var queue = new QueueConfig(queueId, map, gameMode, flags);
            queues.Add(queueId, queue);
        }
    }

    private QueueConfig(int queueId, MapId mapId, GameMode gameMode, QueueFlags flags)
    {
        QueueId = queueId;
        Map = mapId;
        GameMode = gameMode;
        _flags = flags;
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        return Equals(obj as QueueConfig);
    }

    /// <inheritdoc/>
    public bool Equals(QueueConfig? other)
    {
        return other is not null &&
               QueueId == other.QueueId;
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return HashCode.Combine(QueueId);
    }

    private string GetDebuggerDisplay()
    {
        return $"QueueId: {QueueId}, Map: {Map} ({_flags})";
    }
}

[Flags]
enum QueueFlags
{
    None = 0,
    Ranked = 1 << 0,
    PvP = 1 << 1,
    PvE = 1 << 2,
    Bots = 1 << 3,
}

class QueueConverter : JsonConverter<QueueConfig>
{
    public override QueueConfig? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var id = reader.GetInt32();
        return id; // implicit conversion
    }

    public override void Write(Utf8JsonWriter writer, QueueConfig value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value.QueueId);
    }
}
