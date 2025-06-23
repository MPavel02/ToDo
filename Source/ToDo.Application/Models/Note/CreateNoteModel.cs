namespace ToDo.Application.Models.Note;

public class CreateNoteModel
{
    public required string Title { get; set; }
    public required string Details { get; set; }
}