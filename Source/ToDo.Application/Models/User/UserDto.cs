using ToDo.Application.Models.Note;
using ToDo.Domain.Enums;

namespace ToDo.Application.Models.User;

public class UserDto : UserLookupDto
{
    public required ICollection<NoteDto> Notes { get; set; }
}