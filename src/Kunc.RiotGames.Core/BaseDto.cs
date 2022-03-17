using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames;

public abstract record BaseDto
{
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? ExtensionData { get; init; }

    /// <inheritdoc/>
    protected virtual bool PrintMembers(StringBuilder builder)
    {
        if (ExtensionData is null)
        {
            return false;
        }
        builder.Append("ExtensionData.Count = ").Append(ExtensionData.Count);
        return true;
    }
}
