namespace ToDo.Domain.Models.Note;

public class UpdateNoteDto
{
    public required Guid ID { get; set; }
    public required Guid UserID { get; set; }
    public required string Title { get; set; }
    public required string Details { get; set; }
}