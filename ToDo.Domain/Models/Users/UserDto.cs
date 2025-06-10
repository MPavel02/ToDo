namespace ToDo.Domain.Models.Users;

public class UserDto : CreateUserDto
{
    public Guid ID { get; set; }
}