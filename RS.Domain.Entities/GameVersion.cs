﻿namespace Scanner.Domain.Entities;

public class GameVersion
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    
    public virtual IEnumerable<Player>? Players { get; set; }
}