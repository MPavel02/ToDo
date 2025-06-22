using ToDo.Application.Models.Note;
using ToDo.Domain.Enums;

namespace ToDo.Application.Models.User;

public class UserDto
{
    public Guid ID { get; set; }
    public string Username { get; set; }
    public RoleTypes Role { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public required ICollection<NoteDto> Notes { get; set; }
}