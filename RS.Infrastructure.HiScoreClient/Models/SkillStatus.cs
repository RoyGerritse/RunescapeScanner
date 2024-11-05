using Scanner.Infrastructure.HiScoreClient.Interface;

namespace Scanner.Infrastructure.HiScoreClient.Models;

public class SkillStatus : IStatus
{
    public SkillStatus(HiScoreIndex.Skill skill) 
    {
        Rank = 0;
        Level = 0;
        Experience = 0;
        Skill = skill;
    }
    
    public SkillStatus(string[] records, HiScoreIndex.Skill skill)
    {
        Rank = long.Parse(records[0]);;
        Level = int.Parse(records[1]);
        Experience = long.Parse(records[2]);
        Skill = skill;
    }

    public HiScoreIndex.Skill Skill { get; set; }
    public long Rank { get; set; }
    public int Level { get; set; }
    public long Experience { get; set; }
}