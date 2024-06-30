﻿using Kunc.RiotGames.Api.Http;

namespace Kunc.RiotGames.Api.LolSummonerV4;

public class LolSummonerV4Endpoint : ApiEndpoint, ILolSummonerV4
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LolSummonerV4Endpoint"/> class.
    /// </summary>
    public LolSummonerV4Endpoint(IServiceProvider services) : base(services)
    {
    }

    /// <inheritdoc/>
    public async Task<SummonerDto> GetSummonerByPuuidAsync(string region, string puuid, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);
        ArgumentException.ThrowIfNullOrEmpty(puuid);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/summoner/v4/summoners/by-puuid/{encryptedPUUID}",
            Path = $"/lol/summoner/v4/summoners/by-puuid/{puuid}",
        };
        var data = await Client.SendAndDeserializeAsync<SummonerDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <inheritdoc/>
    public async Task<SummonerDto> GetSummonerBySummonerIdAsync(string region, string summonerId, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);
        ArgumentException.ThrowIfNullOrEmpty(summonerId);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/summoner/v4/summoners/{encryptedSummonerId}",
            Path = $"/lol/summoner/v4/summoners/{summonerId}",
        };
        var data = await Client.SendAndDeserializeAsync<SummonerDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
        return data!;
    }
}
