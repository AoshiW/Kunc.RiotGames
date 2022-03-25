using System.Text;

using Kunc.RiotGames.Extensions;

namespace Kunc.RiotGames.Lol.Api.Match;

/// <inheritdoc cref="ILolMatchV5"/>
public class LolMatchEndpoint : ILolMatchV5
{
    private readonly RiotGamesApiClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="LolMatchEndpoint"/> class with the specified <paramref name="client"/>.
    /// </summary>
    /// <param name="client"></param>
    /// <exception cref="ArgumentNullException">If <paramref name="client"/> is null.</exception>
    public LolMatchEndpoint(RiotGamesApiClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<string[]> GetListMatchIdsAsync(Region rouing, string puuid,
        long? startTime = null, long? endTime = null, int? queue = null, string? type = null, int? start = null, int? count = null,
        CancellationToken cancellationToken = default)
    {
        if (count.HasValue && count < 0 || count > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(count), count, "Valid values: 0 to 100.");
        }
        const string methodId = "/lol/match/v5/matches/by-puuid/{puuid}/ids";
        var query = new StringBuilder(90);
        if (startTime.HasValue)
            query.Append($"&{nameof(startTime)}=").Append(startTime.Value); // cca 21 char
        if (endTime.HasValue)
            query.Append($"&{nameof(endTime)}=").Append(endTime.Value); // cca 19 char
        if (queue.HasValue)
            query.Append($"&{nameof(queue)}=").Append(queue.Value); // cca 11 char
        if (type is not null)
            query.Append($"&{nameof(type)}=").Append(type); // cca 14 char
        if (start.HasValue)
            query.Append($"&{nameof(start)}=").Append(start.Value); // cca 10 char
        if (count.HasValue)
            query.Append($"&{nameof(count)}=").Append(count.Value); // cca 10 char
        if (query.Length > 0)
            query[0] = '?';
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, $"/lol/match/v5/matches/by-puuid/{puuid}/ids{query}");
        var rotation = await _client.SendAndDeserializeAsync<string[]>(rouing.ToLowerString(), requestFunc, methodId, cancellationToken).ConfigureAwait(false);
        return rotation!;
    }

    /// <inheritdoc/>
    public async Task<Match?> GetMatchAsync(Region rouing, string matchId, CancellationToken cancellationToken = default)
    {
        const string methodId = "/lol/match/v5/matches/{matchId}";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, $"/lol/match/v5/matches/{matchId}");
        return await _client.SendAndDeserializeAsync<Match>(rouing.ToLowerString(), requestFunc, methodId, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MatchTimeline?> GetMatchTimelineAsync(Region rouing, string matchId, CancellationToken cancellationToken = default)
    {
        const string methodId = "/lol/match/v5/matches/{matchId}/timeline";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, $"/lol/match/v5/matches/{matchId}/timeline");
        return await _client.SendAndDeserializeAsync<MatchTimeline>(rouing.ToLowerString(), requestFunc, methodId, cancellationToken).ConfigureAwait(false);
    }
}
