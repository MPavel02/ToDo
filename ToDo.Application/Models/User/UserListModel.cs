namespace ToDo.Application.Models.User;

public class UserListModel
{
    public required IList<UserLookupDto> Users { get; set; }
}