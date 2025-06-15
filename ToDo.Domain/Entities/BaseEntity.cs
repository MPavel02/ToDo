namespace ToDo.Domain.Entities;

public class BaseEntity
{
    public Guid ID { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // TODO: Домен должен устанавливать значение
    public DateTime? UpdatedAt { get; set; }
}