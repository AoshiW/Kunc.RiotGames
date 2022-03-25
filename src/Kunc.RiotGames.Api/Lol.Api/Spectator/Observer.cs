using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api.Spectator;

public record Observer
{
    /// <summary>
    /// Key used to decrypt the spectator grid game data for playback.
    /// </summary>
    [JsonPropertyName("encryptionKey")]
    public string EncryptionKey { get; init; } = default!;
}
