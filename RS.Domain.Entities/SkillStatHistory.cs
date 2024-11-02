namespace Scanner.Domain.Entities;

public class SkillStatHistory
{
    public Guid Id { get; set; }
    public required User User { get; set; }
    public required Skill Skill { get; set; }
    public required GameVersion GameVersion { get; set; }
    public int Level { get; set; }
    public long Experience { get; set; }
    public long Rank { get; set; }
    public DateTime RecordedAt { get; set; }
}