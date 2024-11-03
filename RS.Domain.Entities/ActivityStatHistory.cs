namespace Scanner.Domain.Entities;

public class ActivityStatHistory
{
    public Guid Id { get; set; }
    public required GameVersion GameVersion { get; set; }
    public required Player Player { get; set; }
    public required Activity Activity { get; set; }
    public long Score { get; set; }
    public long Rank { get; set; }
    public DateTime RecordedAt { get; set; }
}