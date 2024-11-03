using Scanner.Infrastructure.HiScoreClient.Interface;

namespace Scanner.Infrastructure.HiScoreClient.Models;

public class ActivityStat : IStat
{
    public ActivityStat()
    {
        Rank = 0;
        Score = 0;
    }

    public ActivityStat(string[] records)
    {
        Rank = long.Parse(records[0]);
        Score = long.Parse(records[1]);
    }

    public long Rank { get; set; }
    public long Score { get; set; }
}