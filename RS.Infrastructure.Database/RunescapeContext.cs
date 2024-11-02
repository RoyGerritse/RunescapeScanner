using Microsoft.EntityFrameworkCore;
using Scanner.Domain.Entities;
using Scanner.Infrastructure.Database.Interface;

namespace Scanner.Infrastructure.Database;

public class RunescapeContext : DbContext, IRunescapeContext
{
    public DbSet<User> User => Set<User>();
    public DbSet<LogRecord> LogRecord => Set<LogRecord>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasIndex(a => a.Name).IsUnique();
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql("User ID=admin;Password=postgresFtw;Host=10.0.128.71;Port=5432;Database=runescape;");
    }
}