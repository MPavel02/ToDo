namespace ToDo.Application.Models.User;

public class UserDto
{
    public Guid ID { get; set; }
    public required string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}