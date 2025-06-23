using ClickHouse.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;
using ToDo.DAL.ClickHouse.Logs.Persistence.Configurations;
using ToDo.Domain.Entities;

namespace ToDo.DAL.ClickHouse.Logs.Persistence;

public sealed class LogsDbContext : DbContext
{
    #region Constructor
    
    public LogsDbContext(DbContextOptions<LogsDbContext> options) : base(options)
    {
        if (Database.IsClickHouse() && Database.GetPendingMigrations().Any())
        {
            Database.Migrate();
        }
    }
    
    #endregion
    
    #region DbSets
    
    public DbSet<LogEntry> Logs { get; set; } = null!;
    
    #endregion
    
    #region Base Overrides

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new LogConfiguration());
    }

    #endregion
}