namespace ToDo.Domain.Entities;

public class BaseEntity
{
    public Guid ID { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}