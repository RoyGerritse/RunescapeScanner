namespace Scanner.Domain.Entities;

public class User
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required AccountType AccountType { get; set; } = AccountType.Unknown;
    public required GameVersion Version { get; set; }
}