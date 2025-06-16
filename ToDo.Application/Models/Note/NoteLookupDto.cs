namespace ToDo.Application.Models.Note;

public class NoteLookupDto
{
    public Guid ID { get; set; }
    public required string Title { get; set; }
}