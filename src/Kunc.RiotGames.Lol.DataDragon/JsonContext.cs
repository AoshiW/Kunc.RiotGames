using System.Text.Json.Serialization;
using Kunc.RiotGames.Lol.DataDragon.Challenge;
using Kunc.RiotGames.Lol.DataDragon.Champion;
using Kunc.RiotGames.Lol.DataDragon.Item;
using Kunc.RiotGames.Lol.DataDragon.Map;
using Kunc.RiotGames.Lol.DataDragon.ProfileIcon;
using Kunc.RiotGames.Lol.DataDragon.RuneReforged;
using Kunc.RiotGames.Lol.DataDragon.SummonerSpell;

namespace Kunc.RiotGames.Lol.DataDragon;

[JsonSerializable(typeof(string[]))]
[JsonSerializable(typeof(RootDto<ProfileIconDto>))]
[JsonSerializable(typeof(RootDto<SummonerSpellDto>))]
[JsonSerializable(typeof(RootDto<ItemDto>))]
[JsonSerializable(typeof(RootDto<ChampionBaseDto>))]
[JsonSerializable(typeof(RootDto<MapDto>))]
[JsonSerializable(typeof(RootDto<ChampionDto>))]
[JsonSerializable(typeof(RuneReforgedDto[]))]
[JsonSerializable(typeof(ChallengeDto[]))]
internal partial class JsonContext : JsonSerializerContext
{
}
