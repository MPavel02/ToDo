namespace ToDo.WebAPI.Models.User;

public class UpdateUserDto
{
    public Guid ID { get; set; }
    public required string Username { get; set; }
}