using System.Buffers;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Kunc.RiotGames.JsonConverters;

// MS in .NET 9 add supports for alternative names for enum member names (https://github.com/dotnet/runtime/issues/74385)
// but Riot sometimes returns an empty string as a value and this scenario is not supported in .NET
// so here is the copied JsonConverter which is modified to allow empty string as an alternative enum member name
internal sealed class CustomJsonStringEnumConverter<T> : JsonConverter<T> where T : struct, Enum
{
    private static readonly TypeCode s_enumTypeCode = Type.GetTypeCode(typeof(T));

    // Odd type codes are conveniently signed types (for enum backing types).
    private static readonly bool s_isSignedEnum = ((int)s_enumTypeCode % 2) == 1;
    private static readonly bool s_isFlagsEnum = typeof(T).IsDefined(typeof(FlagsAttribute), inherit: false);

    private readonly EnumConverterOptions _converterOptions;

    private readonly JsonNamingPolicy? _namingPolicy;

    /// <summary>
    /// Stores metadata for the individual fields declared on the enum.
    /// </summary>
    private readonly EnumFieldInfo[] _enumFieldInfo;

    /// <summary>
    /// Defines a case-insensitive index of enum field names to their metadata.
    /// In case of casing conflicts, extra fields are appended to a list in the value.
    /// This is the main dictionary that is queried by the enum parser implementation.
    /// </summary>
    private readonly Dictionary<string, EnumFieldInfo> _enumFieldInfoIndex;

    /// <summary>
    /// Holds a cache from enum value to formatted UTF-8 text including flag combinations.
    /// <see cref="ulong"/> is as the key used rather than <typeparamref name="T"/> given measurements that
    /// show private memory savings when a single type is used https://github.com/dotnet/runtime/pull/36726#discussion_r428868336.
    /// </summary>
    private readonly ConcurrentDictionary<ulong, JsonEncodedText> _nameCacheForWriting;

    /// <summary>
    /// Holds a mapping from input text to enum values including flag combinations and alternative casings.
    /// </summary>
    private readonly ConcurrentDictionary<string, ulong> _nameCacheForReading;

    // This is used to prevent flooding the cache due to exponential bitwise combinations of flags.
    // Since multiple threads can add to the cache, a few more values might be added.
    private const int NameCacheSizeSoftLimit = 64;

    public CustomJsonStringEnumConverter() : this(EnumConverterOptions.AllowStrings, null, JsonSerializerOptions.Default)
    {
    }

    public CustomJsonStringEnumConverter(EnumConverterOptions converterOptions, JsonNamingPolicy? namingPolicy, JsonSerializerOptions options)
    {
        _converterOptions = converterOptions;
        _namingPolicy = namingPolicy;
        _enumFieldInfo = ResolveEnumFields(namingPolicy);
        _enumFieldInfoIndex = new(StringComparer.OrdinalIgnoreCase);

        _nameCacheForWriting = new();
        _nameCacheForReading = new(StringComparer.Ordinal);

        JavaScriptEncoder? encoder = options.Encoder;
        foreach (EnumFieldInfo fieldInfo in _enumFieldInfo)
        {
            AddToEnumFieldIndex(fieldInfo);

            JsonEncodedText encodedName = JsonEncodedText.Encode(fieldInfo.JsonName, encoder);
            _nameCacheForWriting.TryAdd(fieldInfo.Key, encodedName);
            _nameCacheForReading.TryAdd(fieldInfo.JsonName, fieldInfo.Key);
        }

        if (namingPolicy != null)
        {
            // Additionally populate the field index with the default names of fields that used a naming policy.
            // This is done to preserve backward compat: default names should still be recognized by the parser.
            foreach (EnumFieldInfo fieldInfo in _enumFieldInfo)
            {
                if (fieldInfo.Kind is EnumFieldNameKind.NamingPolicy)
                {
                    AddToEnumFieldIndex(new EnumFieldInfo(fieldInfo.Key, EnumFieldNameKind.Default, fieldInfo.OriginalName, fieldInfo.OriginalName));
                }
            }
        }

        void AddToEnumFieldIndex(EnumFieldInfo fieldInfo)
        {
            if (!_enumFieldInfoIndex.TryAdd(fieldInfo.JsonName, fieldInfo))
            {
                // We have a casing conflict, append field to the existing entry.
                EnumFieldInfo existingFieldInfo = _enumFieldInfoIndex[fieldInfo.JsonName];
                existingFieldInfo.AppendConflictingField(fieldInfo);
            }
        }
    }

    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.String when (_converterOptions & EnumConverterOptions.AllowStrings) != 0:
                if (TryParseEnumFromString(ref reader, out T result))
                {
                    return result;
                }
                break;

            case JsonTokenType.Number when (_converterOptions & EnumConverterOptions.AllowNumbers) != 0:
                switch (s_enumTypeCode)
                {
                    case TypeCode.Int32 when reader.TryGetInt32(out int int32): return Unsafe.As<int, T>(ref int32);
                    case TypeCode.UInt32 when reader.TryGetUInt32(out uint uint32): return Unsafe.As<uint, T>(ref uint32);
                    case TypeCode.Int64 when reader.TryGetInt64(out long int64): return Unsafe.As<long, T>(ref int64);
                    case TypeCode.UInt64 when reader.TryGetUInt64(out ulong uint64): return Unsafe.As<ulong, T>(ref uint64);
                    case TypeCode.Byte when reader.TryGetByte(out byte ubyte8): return Unsafe.As<byte, T>(ref ubyte8);
                    case TypeCode.SByte when reader.TryGetSByte(out sbyte byte8): return Unsafe.As<sbyte, T>(ref byte8);
                    case TypeCode.Int16 when reader.TryGetInt16(out short int16): return Unsafe.As<short, T>(ref int16);
                    case TypeCode.UInt16 when reader.TryGetUInt16(out ushort uint16): return Unsafe.As<ushort, T>(ref uint16);
                }
                break;
        }

        ThrowHelper.ThrowJsonException();
        return default;
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        EnumConverterOptions converterOptions = _converterOptions;
        if ((converterOptions & EnumConverterOptions.AllowStrings) != 0)
        {
            ulong key = ConvertToUInt64(value);

            if (_nameCacheForWriting.TryGetValue(key, out JsonEncodedText formatted))
            {
                writer.WriteStringValue(formatted);
                return;
            }

            if (IsDefinedValueOrCombinationOfValues(key))
            {
                Debug.Assert(s_isFlagsEnum, "Should only be entered by flags enums.");
                string stringValue = FormatEnumAsString(key, value, dictionaryKeyPolicy: null);
                if (_nameCacheForWriting.Count < NameCacheSizeSoftLimit)
                {
                    formatted = JsonEncodedText.Encode(stringValue, options.Encoder);
                    writer.WriteStringValue(formatted);
                    _nameCacheForWriting.TryAdd(key, formatted);
                }
                else
                {
                    // We also do not create a JsonEncodedText instance here because passing the string
                    // directly to the writer is cheaper than creating one and not caching it for reuse.
                    writer.WriteStringValue(stringValue);
                }

                return;
            }
        }

        if ((converterOptions & EnumConverterOptions.AllowNumbers) == 0)
        {
            ThrowHelper.ThrowJsonException();
        }

        if (s_isSignedEnum)
        {
            writer.WriteNumberValue(ConvertToInt64(value));
        }
        else
        {
            writer.WriteNumberValue(ConvertToUInt64(value));
        }
    }

    private bool TryParseEnumFromString(ref Utf8JsonReader reader, out T result)
    {
        Debug.Assert(reader.TokenType is JsonTokenType.String or JsonTokenType.PropertyName);

        int bufferLength = JsonHelpers.get_ValueLength(ref reader);
        char[]? rentedBuffer = null;
        bool success;

        Span<char> charBuffer = bufferLength <= JsonConstants.StackallocCharThreshold
            ? stackalloc char[JsonConstants.StackallocCharThreshold]
            : (rentedBuffer = ArrayPool<char>.Shared.Rent(bufferLength));

        int charsWritten = reader.CopyString(charBuffer);
        charBuffer = charBuffer.Slice(0, charsWritten);
#if NET9_0_OR_GREATER
        ReadOnlySpan<char> source = charBuffer.Trim();
        ConcurrentDictionary<string, ulong>.AlternateLookup<ReadOnlySpan<char>> lookup = _nameCacheForReading.GetAlternateLookup<ReadOnlySpan<char>>();
#else
        string source = ((ReadOnlySpan<char>)charBuffer).Trim().ToString();
        ConcurrentDictionary<string, ulong> lookup = _nameCacheForReading;
#endif
        if (lookup.TryGetValue(source, out ulong key))
        {
            result = ConvertFromUInt64(key);
            success = true;
            goto End;
        }

        if (JsonHelpers.IntegerRegex.IsMatch(source))
        {
            // We found an integer that is not an enum field name.
            if ((_converterOptions & EnumConverterOptions.AllowNumbers) != 0)
            {
                success = Enum.TryParse(source, out result);
            }
            else
            {
                result = default;
                success = false;
            }
        }
        else
        {
            success = TryParseNamedEnum(source, out result);
        }

        if (success && _nameCacheForReading.Count < NameCacheSizeSoftLimit)
        {
            lookup.TryAdd(source, ConvertToUInt64(result));
        }

    End:
        if (rentedBuffer != null)
        {
            charBuffer.Clear();
            ArrayPool<char>.Shared.Return(rentedBuffer);
        }

        return success;
    }

    private bool TryParseNamedEnum(ReadOnlySpan<char> source, out T result)
    {
#if NET9_0_OR_GREATER
        Dictionary<string, EnumFieldInfo>.AlternateLookup<ReadOnlySpan<char>> lookup = _enumFieldInfoIndex.GetAlternateLookup<ReadOnlySpan<char>>();
#else
        Dictionary<string, EnumFieldInfo> lookup = _enumFieldInfoIndex;
#endif
        ReadOnlySpan<char> rest = source;
        ulong key = 0;

        do
        {
            ReadOnlySpan<char> next;
            int i = rest.IndexOf(',');
            if (i == -1)
            {
                next = rest;
                rest = default;
            }
            else
            {
                next = rest.Slice(0, i).TrimEnd();
                rest = rest.Slice(i + 1).TrimStart();
            }

            if (lookup.TryGetValue(
#if NET9_0_OR_GREATER
                    next,
#else
                        next.ToString(),
#endif
                    out EnumFieldInfo? firstResult) &&
                firstResult.GetMatchingField(next) is EnumFieldInfo match)
            {
                key |= match.Key;
                continue;
            }

            result = default;
            return false;

        } while (!rest.IsEmpty);

        result = ConvertFromUInt64(key);
        return true;
    }

    private static ulong ConvertToUInt64(T value)
    {
        switch (s_enumTypeCode)
        {
            case TypeCode.Int32 or TypeCode.UInt32: return Unsafe.As<T, uint>(ref value);
            case TypeCode.Int64 or TypeCode.UInt64: return Unsafe.As<T, ulong>(ref value);
            case TypeCode.Int16 or TypeCode.UInt16: return Unsafe.As<T, ushort>(ref value);
            default:
                Debug.Assert(s_enumTypeCode is TypeCode.SByte or TypeCode.Byte);
                return Unsafe.As<T, byte>(ref value);
        };
    }

    private static long ConvertToInt64(T value)
    {
        Debug.Assert(s_isSignedEnum);
        switch (s_enumTypeCode)
        {
            case TypeCode.Int32: return Unsafe.As<T, int>(ref value);
            case TypeCode.Int64: return Unsafe.As<T, long>(ref value);
            case TypeCode.Int16: return Unsafe.As<T, short>(ref value);
            default:
                Debug.Assert(s_enumTypeCode is TypeCode.SByte);
                return Unsafe.As<T, sbyte>(ref value);
        };
    }

    private static T ConvertFromUInt64(ulong value)
    {
        switch (s_enumTypeCode)
        {
            case TypeCode.Int32 or TypeCode.UInt32:
                uint uintValue = (uint)value;
                return Unsafe.As<uint, T>(ref uintValue);

            case TypeCode.Int64 or TypeCode.UInt64:
                ulong ulongValue = value;
                return Unsafe.As<ulong, T>(ref ulongValue);

            case TypeCode.Int16 or TypeCode.UInt16:
                ushort ushortValue = (ushort)value;
                return Unsafe.As<ushort, T>(ref ushortValue);

            default:
                Debug.Assert(s_enumTypeCode is TypeCode.SByte or TypeCode.Byte);
                byte byteValue = (byte)value;
                return Unsafe.As<byte, T>(ref byteValue);
        };
    }

    /// <summary>
    /// Attempt to format the enum value as a comma-separated string of flag values, or returns false if not a valid flag combination.
    /// </summary>
    private string FormatEnumAsString(ulong key, T value, JsonNamingPolicy? dictionaryKeyPolicy)
    {
        Debug.Assert(IsDefinedValueOrCombinationOfValues(key), "must only be invoked against valid enum values.");
        Debug.Assert(
            s_isFlagsEnum || (dictionaryKeyPolicy is not null && Enum.IsDefined<T>(value)),
            "must either be a flag type or computing a dictionary key policy.");

        if (s_isFlagsEnum)
        {
            using ValueStringBuilder sb = new(stackalloc char[JsonConstants.StackallocCharThreshold]);
            ulong remainingBits = key;

            foreach (EnumFieldInfo enumField in _enumFieldInfo)
            {
                ulong fieldKey = enumField.Key;
                if (fieldKey == 0 ? key == 0 : (remainingBits & fieldKey) == fieldKey)
                {
                    remainingBits &= ~fieldKey;
                    string name = dictionaryKeyPolicy is not null
                        ? ResolveAndValidateJsonName(enumField.OriginalName, dictionaryKeyPolicy, enumField.Kind)
                        : enumField.JsonName;

                    if (sb.Length > 0)
                    {
                        sb.Append(", ");
                    }

                    sb.Append(name);

                    if (remainingBits == 0)
                    {
                        break;
                    }
                }
            }

            Debug.Assert(remainingBits == 0 && sb.Length > 0, "unexpected remaining bits or empty string.");
            return sb.ToString();
        }
        else
        {
            Debug.Assert(dictionaryKeyPolicy != null);

            foreach (EnumFieldInfo enumField in _enumFieldInfo)
            {
                // Search for an exact match and apply the key policy.
                if (enumField.Key == key)
                {
                    return ResolveAndValidateJsonName(enumField.OriginalName, dictionaryKeyPolicy, enumField.Kind);
                }
            }

            Debug.Fail("should not have been reached.");
            return null;
        }
    }

    private bool IsDefinedValueOrCombinationOfValues(ulong key)
    {
        if (s_isFlagsEnum)
        {
            ulong remainingBits = key;

            foreach (EnumFieldInfo fieldInfo in _enumFieldInfo)
            {
                ulong fieldKey = fieldInfo.Key;
                if (fieldKey == 0 ? key == 0 : (remainingBits & fieldKey) == fieldKey)
                {
                    remainingBits &= ~fieldKey;

                    if (remainingBits == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        else
        {
            foreach (EnumFieldInfo fieldInfo in _enumFieldInfo)
            {
                if (fieldInfo.Key == key)
                {
                    return true;
                }
            }

            return false;
        }
    }

    private static EnumFieldInfo[] ResolveEnumFields(JsonNamingPolicy? namingPolicy)
    {
        string[] names = Enum.GetNames<T>();
        T[] values = Enum.GetValues<T>();
        Debug.Assert(names.Length == values.Length);

        Dictionary<string, string>? enumMemberAttributes = null;
        foreach (FieldInfo field in typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static))
        {
            if (field.GetCustomAttribute<JsonStringEnumMemberNameAttribute>() is { } attribute)
            {
                (enumMemberAttributes ??= new(StringComparer.Ordinal)).Add(field.Name, attribute.Name);
            }
        }

        var enumFields = new EnumFieldInfo[names.Length];
        for (int i = 0; i < names.Length; i++)
        {
            string originalName = names[i];
            T value = values[i];
            ulong key = ConvertToUInt64(value);
            EnumFieldNameKind kind;

            if (enumMemberAttributes != null && enumMemberAttributes.TryGetValue(originalName, out string? attributeName))
            {
                originalName = attributeName;
                kind = EnumFieldNameKind.Attribute;
            }
            else
            {
                kind = namingPolicy != null ? EnumFieldNameKind.NamingPolicy : EnumFieldNameKind.Default;
            }

            string jsonName = ResolveAndValidateJsonName(originalName, namingPolicy, kind);
            enumFields[i] = new EnumFieldInfo(key, kind, originalName, jsonName);
        }

        return enumFields;
    }

    private static string ResolveAndValidateJsonName(string name, JsonNamingPolicy? namingPolicy, EnumFieldNameKind kind)
    {
        if (kind is not EnumFieldNameKind.Attribute && namingPolicy is not null)
        {
            // Do not apply a naming policy to names that are explicitly set via attributes.
            // This is consistent with JsonPropertyNameAttribute semantics.
            name = namingPolicy.ConvertName(name);
        }

        if (name is null ||
            (name.Length > 0 && (char.IsWhiteSpace(name[0]) || char.IsWhiteSpace(name[^1]))) ||
            (s_isFlagsEnum && (name is "" || name.AsSpan().IndexOf(',') >= 0)))
        {
            // Reject ~~null~~ or empty strings or strings with leading or trailing whitespace.
            // In the case of flags additionally reject strings containing commas.
            ThrowHelper.ThrowInvalidOperationException_UnsupportedEnumIdentifier(typeof(T), name);
        }

        return name;
    }

    private sealed class EnumFieldInfo(ulong key, EnumFieldNameKind kind, string originalName, string jsonName)
    {
        private List<EnumFieldInfo>? _conflictingFields;
        public EnumFieldNameKind Kind { get; } = kind;
        public ulong Key { get; } = key;
        public string OriginalName { get; } = originalName;
        public string JsonName { get; } = jsonName;

        /// <summary>
        /// Assuming we have field that conflicts with the current up to case sensitivity,
        /// append it to a list of trailing values for use by the enum value parser.
        /// </summary>
        public void AppendConflictingField(EnumFieldInfo other)
        {
            Debug.Assert(JsonName.Equals(other.JsonName, StringComparison.OrdinalIgnoreCase), "The conflicting entry must be equal up to case insensitivity.");

            if (Kind is EnumFieldNameKind.Default || JsonName.Equals(other.JsonName, StringComparison.Ordinal))
            {
                // Silently discard if the preceding entry is the default or has identical name.
                return;
            }

            List<EnumFieldInfo> conflictingFields = _conflictingFields ??= [];

            // Walk the existing list to ensure we do not add duplicates.
            foreach (EnumFieldInfo conflictingField in conflictingFields)
            {
                if (conflictingField.Kind is EnumFieldNameKind.Default || conflictingField.JsonName.Equals(other.JsonName, StringComparison.Ordinal))
                {
                    return;
                }
            }

            conflictingFields.Add(other);
        }

        public EnumFieldInfo? GetMatchingField(ReadOnlySpan<char> input)
        {
            Debug.Assert(input.Equals(JsonName, StringComparison.OrdinalIgnoreCase), "Must equal the field name up to case insensitivity.");

            if (Kind is EnumFieldNameKind.Default || input.SequenceEqual(JsonName))
            {
                // Default enum names use case insensitive parsing so are always a match.
                return this;
            }

            if (_conflictingFields is { } conflictingFields)
            {
                Debug.Assert(conflictingFields.Count > 0);
                foreach (EnumFieldInfo matchingField in conflictingFields)
                {
                    if (matchingField.Kind is EnumFieldNameKind.Default || input.SequenceEqual(matchingField.JsonName))
                    {
                        return matchingField;
                    }
                }
            }

            return null;
        }
    }

    private enum EnumFieldNameKind
    {
        Default = 0,
        NamingPolicy = 1,
        Attribute = 2,
    }
}

[Flags]
internal enum EnumConverterOptions
{
    /// <summary>
    /// Allow string values.
    /// </summary>
    AllowStrings = 0b0001,

    /// <summary>
    /// Allow number values.
    /// </summary>
    AllowNumbers = 0b0010
}

static file class JsonConstants
{
    public static int StackallocByteThreshold => 256;
    public static int StackallocCharThreshold => StackallocByteThreshold / 2;
}

file class ThrowHelper
{
    [DoesNotReturn]
    public static void ThrowJsonException(string? message = null)
    {
        var exception = new JsonException(message);
        BackingField_AppendPathInformation(exception) = true;
        throw exception;

        [UnsafeAccessor(UnsafeAccessorKind.Field, Name = "<AppendPathInformation>k__BackingField")]
        static extern ref bool BackingField_AppendPathInformation(JsonException exception);
    }

    [DoesNotReturn]
    public static void ThrowInvalidOperationException_UnsupportedEnumIdentifier(Type enumType, string? enumName)
    {
        throw new InvalidOperationException(
            $"Enum type '{enumType.Name}' uses unsupported identifier '{enumName}'. " +
            $"It must not be null, empty, or containing leading or trailing whitespace. " +
            $"Flags enums must additionally not contain commas.");
    }
}

internal static partial class JsonHelpers
{
    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "get_ValueLength")]
    public static extern int get_ValueLength(ref Utf8JsonReader reader);

    public static readonly Regex IntegerRegex = CreateIntegerRegex();

    [GeneratedRegex(@"^\s*(?:\+|\-)?[0-9]+\s*$", RegexOptions.None, matchTimeoutMilliseconds: 200)]
    private static partial Regex CreateIntegerRegex();
}

file ref partial struct ValueStringBuilder
{
    private char[]? _arrayToReturnToPool;
    private Span<char> _chars;
    private int _pos;

    public ValueStringBuilder(Span<char> initialBuffer)
    {
        _arrayToReturnToPool = null;
        _chars = initialBuffer;
        _pos = 0;
    }
    public int Length
    {
        readonly get => _pos;
        set
        {
            Debug.Assert(value >= 0);
            Debug.Assert(value <= _chars.Length);
            _pos = value;
        }
    }

    public override string ToString()
    {
        string s = _chars.Slice(0, _pos).ToString();
        Dispose();
        return s;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Append(char c)
    {
        int pos = _pos;
        Span<char> chars = _chars;
        if ((uint)pos < (uint)chars.Length)
        {
            chars[pos] = c;
            _pos = pos + 1;
        }
        else
        {
            GrowAndAppend(c);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Append(string? s)
    {
        if (s == null)
        {
            return;
        }

        int pos = _pos;
        if (s.Length == 1 && (uint)pos < (uint)_chars.Length) // very common case, e.g. appending strings from NumberFormatInfo like separators, percent symbols, etc.
        {
            _chars[pos] = s[0];
            _pos = pos + 1;
        }
        else
        {
            AppendSlow(s);
        }
    }

    private void AppendSlow(string s)
    {
        int pos = _pos;
        if (pos > _chars.Length - s.Length)
        {
            Grow(s.Length);
        }

        s.CopyTo(_chars.Slice(pos));
        _pos += s.Length;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private void GrowAndAppend(char c)
    {
        Grow(1);
        Append(c);
    }

    /// <summary>
    /// Resize the internal buffer either by doubling current buffer size or
    /// by adding <paramref name="additionalCapacityBeyondPos"/> to
    /// <see cref="_pos"/> whichever is greater.
    /// </summary>
    /// <param name="additionalCapacityBeyondPos">
    /// Number of chars requested beyond current position.
    /// </param>
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void Grow(int additionalCapacityBeyondPos)
    {
        Debug.Assert(additionalCapacityBeyondPos > 0);
        Debug.Assert(_pos > _chars.Length - additionalCapacityBeyondPos, "Grow called incorrectly, no resize is needed.");

        const uint ArrayMaxLength = 0x7FFFFFC7; // same as Array.MaxLength

        // Increase to at least the required size (_pos + additionalCapacityBeyondPos), but try
        // to double the size if possible, bounding the doubling to not go beyond the max array length.
        int newCapacity = (int)Math.Max(
            (uint)(_pos + additionalCapacityBeyondPos),
            Math.Min((uint)_chars.Length * 2, ArrayMaxLength));

        // Make sure to let Rent throw an exception if the caller has a bug and the desired capacity is negative.
        // This could also go negative if the actual required length wraps around.
        char[] poolArray = ArrayPool<char>.Shared.Rent(newCapacity);

        _chars.Slice(0, _pos).CopyTo(poolArray);

        char[]? toReturn = _arrayToReturnToPool;
        _chars = _arrayToReturnToPool = poolArray;
        if (toReturn != null)
        {
            ArrayPool<char>.Shared.Return(toReturn);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Dispose()
    {
        char[]? toReturn = _arrayToReturnToPool;
        this = default; // for safety, to avoid using pooled array if this instance is erroneously appended to again
        if (toReturn != null)
        {
            ArrayPool<char>.Shared.Return(toReturn);
        }
    }
}
