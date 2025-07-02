using ToDo.Application.Models.Note;

namespace ToDo.Application.Models.User;

public class UserDto : UserLookupDto
{
    public required ICollection<NoteDto> Notes { get; set; }
}