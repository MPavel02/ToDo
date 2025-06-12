namespace ToDo.Domain.Models.User;

public class UserModel
{
    public Guid ID { get; set; }
    public required string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}