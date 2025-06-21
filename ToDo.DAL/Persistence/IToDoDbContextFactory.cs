namespace ToDo.DAL.Persistence;

/// <summary>
/// Фабрика создания контекста БД.
/// </summary>
public interface IToDoDbContextFactory
{
    ToDoDbContext Create();
}