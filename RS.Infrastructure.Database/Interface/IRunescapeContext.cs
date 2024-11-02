using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Scanner.Domain.Entities;

namespace Scanner.Infrastructure.Database.Interface;

public interface IRunescapeContext
{
    DbSet<User> User { get; }
    DbSet<LogRecord> LogRecord { get; }

    DatabaseFacade Database { get; }
    ChangeTracker ChangeTracker { get; }
    IModel Model { get; }
    DbContextId ContextId { get; }
    bool Equals(object? obj);
    int GetHashCode();
    string? ToString();
    int SaveChanges();
    int SaveChanges(bool acceptAllChangesOnSuccess);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken);
    void Dispose();
    ValueTask DisposeAsync();
    EntityEntry Entry(object entity);
    EntityEntry Add(object entity);
    ValueTask<EntityEntry> AddAsync(object entity, CancellationToken cancellationToken);
    EntityEntry Attach(object entity);
    EntityEntry Update(object entity);
    EntityEntry Remove(object entity);
    void AddRange(params object[] entities);
    void AddRange(IEnumerable<object> entities);
    Task AddRangeAsync(params object[] entities);
    Task AddRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken);
    void AttachRange(params object[] entities);
    void AttachRange(IEnumerable<object> entities);
    void UpdateRange(params object[] entities);
    void UpdateRange(IEnumerable<object> entities);
    void RemoveRange(params object[] entities);
    void RemoveRange(IEnumerable<object> entities);
    object? Find(Type entityType, params object?[]? keyValues);
    ValueTask<object?> FindAsync(Type entityType, params object?[]? keyValues);
    ValueTask<object?> FindAsync(Type entityType, object?[]? keyValues, CancellationToken cancellationToken);
    event EventHandler<SavingChangesEventArgs>? SavingChanges;
    event EventHandler<SavedChangesEventArgs>? SavedChanges;
    event EventHandler<SaveChangesFailedEventArgs>? SaveChangesFailed;
}