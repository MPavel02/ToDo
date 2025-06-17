using ToDo.Application.Models.Note;

namespace ToDo.Application.Models.User;

public class UserDto
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public required ICollection<NoteDto> Notes { get; set; }
}