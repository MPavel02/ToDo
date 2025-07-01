namespace ToDo.Application.Models;

public abstract class BaseEntityDto
{
    public Guid ID { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}