namespace ToDo.Application.Models.Note;

public class UpdateNoteModel
{
    public Guid ID { get; set; }
    public required string Title { get; set; }
    public required string Details { get; set; }
}