namespace ToDo.Domain.Entities;

public class User : BaseEntity
{
    public required string Name { get; set; }
    public ICollection<Note> Notes { get; set; } = [];
}