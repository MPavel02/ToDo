namespace ToDo.DAL.Core.Entities;

public class BaseEntityWithDates : BaseEntity
{
    /// <summary>
    /// Дата и время создания.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Дата и время редактирования.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}