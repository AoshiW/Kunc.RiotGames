using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolSpectatorV4;

public class ObserverDto : BaseDto
{
    /// <summary>
    /// Key used to decrypt the spectator grid game data for playback.
    /// </summary>
    [JsonPropertyName("encryptionKey")]
    public string EncryptionKey { get; set; } = string.Empty;
}

