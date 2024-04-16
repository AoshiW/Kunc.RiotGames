using System.Buffers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.JsonConverters;

class RiotIdConverter : JsonConverter<RiotId>
{
    /// <inheritdoc/>
    public override RiotId? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.HasValueSequence)
            throw new InvalidOperationException("String for RiotId is too long.");

        var len = reader.ValueSpan.Length;
        char[]? array = null;
        Span<char> buffer = len <= 128
            ? stackalloc char[len]
            : (array = ArrayPool<char>.Shared.Rent(len));

        var written = reader.CopyString(buffer);
        var riotId = RiotId.Parse(buffer.Slice(0, written), null);

        if (array is not null)
            ArrayPool<char>.Shared.Return(array);
        return riotId;
    }

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, RiotId value, JsonSerializerOptions options)
    {
        var len = value.GameName.Length + 1 + value.TagLine.Length;
        char[]? array = null;
        Span<char> buffer = len <= 128
            ? stackalloc char[len]
            : (array = ArrayPool<char>.Shared.Rent(len));

        value.TryFormat(buffer, out var written, string.Empty, null);
        writer.WriteStringValue(buffer.Slice(0, written));

        if (array is not null)
            ArrayPool<char>.Shared.Return(array);
    }
}
