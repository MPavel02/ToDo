using Microsoft.EntityFrameworkCore;
using ToDo.DAL.Entities;
using ToDo.DAL.Persistence.Configurations;

namespace ToDo.DAL.Persistence;

public sealed class ToDoDbContext : DbContext
{
    #region Constructor

    public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
    {
        if (Database.IsNpgsql() && Database.GetPendingMigrations().Any())
        {
            Database.Migrate();
        }
    }

    #endregion
    
    #region DbSets
    
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Note> Notes { get; set; } = null!;
    
    #endregion
    
    #region Base Overrides

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new NoteConfiguration());
    }

    #endregion
}