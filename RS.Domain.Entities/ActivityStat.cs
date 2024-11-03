namespace Scanner.Domain.Entities;

public class ActivityStat
{
    public Guid Id { get; set; }
    public required GameVersion GameVersion { get; set; }
    public required Player Player { get; set; }
    public required Activity Activity { get; set; }
    public required string Name { get; set; }
    public long Rank { get; set; }
}