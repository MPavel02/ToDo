using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ToDo.DAL.Settings;

namespace ToDo.DAL.Persistence;

/// <inheritdoc />
public class ToDoDbContextFactory(IOptions<DatabaseConnectionSettings> connectionSettings) : IToDoDbContextFactory
{
    private readonly DatabaseConnectionSettings _connectionSettings = connectionSettings.Value;

    /// <inheritdoc />
    public ToDoDbContext Create()
    {
        var options = new DbContextOptionsBuilder<ToDoDbContext>()
            .UseNpgsql(_connectionSettings.ToDoConnection,
                x => x.EnableRetryOnFailure());

        return new ToDoDbContext(options.Options);
    }
}