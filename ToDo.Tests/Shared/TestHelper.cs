using Microsoft.EntityFrameworkCore;
using ToDo.DAL.Persistence;

namespace ToDo.Tests.Shared;

/// <summary>
/// Класс-помощник для тестов.
/// </summary>
public static class TestHelper
{
    /// <summary>
    /// Создает контекст для тестов в БД.
    /// </summary>
    /// <returns>Контекст в виде <see cref="ToDoDbContext"/>.</returns>
    public static ToDoDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<ToDoDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        return new ToDoDbContext(options);
    }
}