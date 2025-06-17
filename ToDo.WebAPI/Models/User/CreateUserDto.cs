using ToDo.Application.Models.Note;

namespace ToDo.WebAPI.Models.User;

public class CreateUserDto
{
    public required string Name { get; set; }
    public ICollection<CreateNoteModel> Notes { get; set; }
}