using Scanner.Infrastructure.HiScoreClient.Interface;

namespace Scanner.Infrastructure.HiScoreClient.Models;

public class SkillStat : IStat
{
    public SkillStat() 
    {
        Rank = 0;
        Level = 0;
        Experience = 0;
    }
    public SkillStat(string[] records)
    {
        Rank = long.Parse(records[0]);;
        Level = int.Parse(records[1]);
        Experience = long.Parse(records[2]);
    }

    public long Rank { get; set; }
    public int Level { get; set; }
    public long Experience { get; set; }
}