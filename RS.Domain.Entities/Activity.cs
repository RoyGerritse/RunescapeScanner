﻿namespace Scanner.Domain.Entities;

public class Activity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required GameVersion GameVersion { get; set; }
}