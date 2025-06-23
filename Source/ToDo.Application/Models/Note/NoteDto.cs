namespace ToDo.Application.Models.Note;

public class NoteDto
{
    public Guid ID { get; set; }
    public required string Title { get; set; }
    public required string Details { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}