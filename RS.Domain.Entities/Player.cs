namespace Scanner.Domain.Entities;

public class Player
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required AccountType AccountType { get; set; } = AccountType.Unknown;
    public virtual GameVersion? GameVersion { get; set; }
    public virtual Guid? GameVersionId { get; set; }
}