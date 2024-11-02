namespace Scanner.Domain.Entities;

public class ActivityStat
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public long Rank { get; set; }
}