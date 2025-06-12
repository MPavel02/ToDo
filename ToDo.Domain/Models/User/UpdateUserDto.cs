namespace ToDo.Domain.Models.User;

public class UpdateUserDto
{
    public Guid ID { get; set; }
    public required string Name { get; set; }
}