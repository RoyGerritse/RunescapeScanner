using Scanner.Infrastructure.HiScoreClient.Interface;

namespace Scanner.Infrastructure.HiScoreClient.Models;

public class ActivityStatus : IStatus
{
    public ActivityStatus(HiScoreIndex.Activity activity)
    {
        Rank = 0;
        Score = 0;
        Activity = activity;
    }

    public ActivityStatus(string[] split, HiScoreIndex.Activity activity)
    {
        Rank = long.Parse(split[0]);
        Score = long.Parse(split[1]);
        Activity = activity;
    }
    
    
    public HiScoreIndex.Activity Activity { get; set; }
    public long Rank { get; set; }
    public long Score { get; set; }
}