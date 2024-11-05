using Scanner.Domain.Entities;
using Scanner.Infrastructure.HiScoreClient.Interface;
using Scanner.Infrastructure.HiScoreClient.Models;
using static System.String;

namespace Scanner.Infrastructure.HiScoreClient;

public class HiScoreClient : IHiScoreClient
{
    private const string HiScoreIndexLiteUrl = "https://secure.runescape.com/m=hiscore/index_lite.ws?player={0}";

    public async Task<StatOverview?> IndexLite(Player player)
    {
        var client = new HttpClient();
        var response = await client.GetAsync(Format(HiScoreIndexLiteUrl, player.Name));
        if (!response.IsSuccessStatusCode) return null;
        var content = await response.Content.ReadAsStringAsync();
        var stat = new StatOverview(player, content);
        return stat;
    }
}