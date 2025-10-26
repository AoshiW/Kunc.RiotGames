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
        var riotId = Parse(buffer.Slice(0, written));

        if (array is not null)
            ArrayPool<char>.Shared.Return(array);
        return riotId;
    }

    protected virtual RiotId Parse(ReadOnlySpan<char> chars)
    {
        return RiotId.Parse(chars, null);
    }

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, RiotId value, JsonSerializerOptions options)
    {
        var len = value.GameName.Length + 1 + value.TagLine.Length;
        char[]? array = null;
        Span<char> buffer = len <= 128
            ? stackalloc char[len]
            : (array = ArrayPool<char>.Shared.Rent(len));

        Format(buffer, value, options, out var written);
        writer.WriteStringValue(buffer.Slice(0, written));

        if (array is not null)
            ArrayPool<char>.Shared.Return(array);
    }

    protected virtual void Format(Span<char> buffer, RiotId value, JsonSerializerOptions options, out int written)
    {
        value.TryFormat(buffer, out written, string.Empty, null);
    }
    
    internal class Anonymous : RiotIdConverter
    {
        protected override RiotId Parse(ReadOnlySpan<char> chars)
        {
            if (chars.Contains('#'))
                return base.Parse(chars);

            return new RiotId(chars.ToString(), string.Empty);
        }

        protected override void Format(Span<char> buffer, RiotId value, JsonSerializerOptions options, out int written)
        {
            if (!string.IsNullOrEmpty(value.TagLine))
            {
                base.Format(buffer, value, options, out written);
                return;
            }

            value.GameName.CopyTo(buffer);
            written = value.GameName.Length;
            return;
        }
    }
}
