using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;

namespace ToDo.DAL;

public sealed class ToDoDbContext : DbContext
{
    public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
    {
        if (Database.GetPendingMigrations().Any())
        {
            Database.Migrate();
        }
    }
    
    public DbSet<UserEntity> Users { get; set; } = null!;
}