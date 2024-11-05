namespace Scanner.Domain.Entities;

public class SkillStat
{
    public Guid Id { get; set; }
    public required GameVersion GameVersion { get; set; }
    public required Player Player { get; set; }
    public required Skill Skill { get; set; }
    public int Level { get; set; }
    public long Experience { get; set; }
    public long Rank { get; set; }
    public DateTime LastUpdated { get; set; }
    
    public virtual Guid PlayerId { get; set; }
    public virtual Guid GameVersionId { get; set; }
    public virtual Guid SkillId { get; set; }
}