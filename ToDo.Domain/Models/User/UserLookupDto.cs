namespace ToDo.Domain.Models.User;

public class UserLookupDto
{
    public Guid ID { get; set; }
    public required string Name { get; set; }
}