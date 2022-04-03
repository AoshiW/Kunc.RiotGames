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
    FirstBlood,
    ChampionKill,
    Multikill,
    Ace,
    InhibKilled,
    InhibRespawningSoon,
    InhibRespawned,
    DragonKill,
    HeraldKill,
    BaronKill,
    GameEnd,
}
