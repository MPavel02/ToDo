namespace ToDo.WebAPI.Models.Note;

public class CreateNoteDto
{
    public required string Title { get; set; }
    public required string Details { get; set; }
    
    public required Guid UserID { get; set; }
}