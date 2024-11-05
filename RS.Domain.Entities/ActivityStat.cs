namespace Scanner.Domain.Entities;

public class ActivityStat
{
    public Guid Id { get; set; }
    public required GameVersion GameVersion { get; set; }
    public required Player Player { get; set; }
    public required Activity Activity { get; set; }
    public long Rank { get; set; }
    public long Score { get; set; }
    public DateTime LastUpdated { get; set; }
    
    
    public virtual Guid PlayerId { get; set; }
    public virtual Guid GameVersionId { get; set; }
    public virtual Guid ActivityId { get; set; }
}