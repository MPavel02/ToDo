namespace ToDo.Domain.Entities;

public class Note : BaseEntity
{
    public required string Title { get; set; }
    public required string Details { get; set; }
    
    public required Guid UserID { get; set; }
    public User? User { get; set; }
}