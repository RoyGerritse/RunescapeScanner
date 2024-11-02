namespace Scanner.Domain.Entities;

public class LogRecord
{
    public required Guid Id { get; set; }
    public int Page { get; set; }
    public int Rank { get; set; }
    public required string Total { get; set; }
    public required long Xp { get; set; }
    public User User { get; set; } = null!;
    public DateTime ChangeDate { get; set; }
}