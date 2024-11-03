using Microsoft.EntityFrameworkCore;
using Scanner.Application.Interactor;
using Scanner.Domain.Entities;
using Scanner.Infrastructure.Database.Interface;

namespace Scanner.Infrastructure.Database;

public class RunescapeContext : DbContext, IRunescapeContext
{
    public DbSet<Activity> Activity => Set<Activity>();
    public DbSet<ActivityStat> ActivityStat => Set<ActivityStat>();
    public DbSet<ActivityStatHistory> ActivityStatHistory => Set<ActivityStatHistory>();
    public DbSet<CurrentSession> CurrentSession => Set<CurrentSession>();
    public DbSet<GameVersion> GameVersion => Set<GameVersion>();
    public DbSet<Player> Player => Set<Player>();
    public DbSet<Skill> Skill => Set<Skill>();
    public DbSet<SkillStat> SkillStat => Set<SkillStat>();
    public DbSet<SkillStatHistory> SkillStatHistory => Set<SkillStatHistory>();

    public DbSet<LogRecord> LogRecord => Set<LogRecord>();
    public DbSet<User> User => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>().HasKey(a => a.Id);
        modelBuilder.Entity<ActivityStat>().HasKey(a => a.Id);
        modelBuilder.Entity<ActivityStatHistory>().HasKey(a => a.Id);
        modelBuilder.Entity<CurrentSession>().HasKey(a => a.Id);
        modelBuilder.Entity<GameVersion>().HasKey(a => a.Id);
        modelBuilder.Entity<Player>().HasKey(a => a.Id);
        modelBuilder.Entity<Skill>().HasKey(a => a.Id);
        modelBuilder.Entity<SkillStat>().HasKey(a => a.Id);
        modelBuilder.Entity<ActivityStat>().HasKey(a => a.Id);
        modelBuilder.Entity<LogRecord>().HasKey(a => a.Id);
        modelBuilder.Entity<Player>()
            .HasOne<GameVersion>(a => a.GameVersion)
            .WithMany(a => a.Players)
            .HasForeignKey(a => a.GameVersionId);

        modelBuilder.Entity<GameVersion>()
            .HasData(new GameVersion
            {
                Id = new Guid("8d292ae5-87c6-44f6-a7a7-71898af17f52"),
                Name = RunescapeVersion.Oldschool
            }, new GameVersion
            {
                Id = new Guid("83cce0f7-3d54-437c-b4c1-3f270792fc8c"),
                Name = RunescapeVersion.Regular
            });
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql("User ID=admin;Password=postgresFtw;Host=10.0.128.71;Port=5432;Database=runescape;");
    }
}