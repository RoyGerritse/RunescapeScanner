namespace Scanner.Domain.Entities;

public class CurrentSession
{
    public Guid Id { get; set; }
    public required string SessionName { get; set; }
    public required Dictionary<string, string> Setting { get; set; }
    public bool Active { get; set; }
}