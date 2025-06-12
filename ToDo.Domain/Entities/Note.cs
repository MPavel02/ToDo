namespace ToDo.Domain.Entities;

public class Note : BaseEntity
{
    public required string Title { get; set; }
    public required string Details { get; set; }
    
    public required User User { get; set; }
}