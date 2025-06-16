using Microsoft.EntityFrameworkCore;
using ToDo.DAL.Persistence.Configurations;
using ToDo.Domain.Entities;

namespace ToDo.DAL.Persistence;

public sealed class ToDoDbContext : DbContext
{
    #region Constructor

    public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
    {
        if (Database.GetPendingMigrations().Any())
        {
            Database.Migrate();
        }
    }

    #endregion
    
    #region DbSets
    
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Note> Notes { get; set; } = null!;
    
    #endregion
    
    #region Base Overides

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new NoteConfiguration());
    }

    #endregion
}