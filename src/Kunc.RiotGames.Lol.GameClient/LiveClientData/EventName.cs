using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

[JsonConverter(typeof(JsonStringEnumMemberConverter)), JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: UnknownEnumValue)]
public enum EventName
{
    /// <summary>
    /// Represent unknow enum value.
    /// </summary>
    UnknownEnumValue,

    GameStart,
    MinionsSpawning,
    FirstBrick,
    TurretKilled,
    InhibKilled,
    InhibRespawningSoon,
    InhibRespawned,
    FirstBlood,
    DragonKill,
    HeraldKill,
    BaronKill,
    ChampionKill,
    Ace,
    GameEnd,
}
