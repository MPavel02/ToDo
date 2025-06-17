namespace ToDo.Application.Models.Note;

public class NoteListDto
{
    public required ICollection<NoteLookupDto> Notes { get; set; }
}