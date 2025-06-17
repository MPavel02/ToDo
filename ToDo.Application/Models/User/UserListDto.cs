namespace ToDo.Application.Models.User;

public class UserListDto
{
    public required IList<UserLookupDto> Users { get; set; }
}