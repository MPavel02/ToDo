using ToDo.Application.Models.Note;

namespace ToDo.WebAPI.Models.User;

public class CreateUserDto
{
    public required string Username { get; set; }
}