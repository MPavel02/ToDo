namespace ToDo.Domain.Models.Note;

public class NoteListModel
{
    public required IList<NoteLookupDto> Notes { get; set; }
}