using ToDo.DAL.Core.Entities;

namespace ToDo.DAL.Entities;

/// <summary>
/// Модель заметки.
/// </summary>
public sealed class Note : BaseEntityWithDates
{
    public required string Title { get; set; }
    public required string Details { get; set; }
    public Guid UserID { get; set; }
    public User User { get; set; }
}