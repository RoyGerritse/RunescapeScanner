using Scanner.Domain.Entities;
using Scanner.Infrastructure.HiScoreClient.Interface;
using Scanner.Infrastructure.HiScoreClient.Models;
using static System.String;

namespace Scanner.Infrastructure.HiScoreClient;

public class HiScoreClient : IHiScoreClient
{
    private const string HiScoreIndexLiteUrl = "https://secure.runescape.com/m=hiscore/index_lite.ws?player={0}";

    public async Task<StatOverview> IndexLite(User user)
    {
        var client = new HttpClient();
        var content = await client.GetStringAsync(Format(HiScoreIndexLiteUrl, user.Name));
        var stat = new StatOverview(user,content);
        return stat;
    }
}