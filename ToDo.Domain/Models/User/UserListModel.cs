namespace ToDo.Domain.Models.User;

public class UserListModel
{
    public required IList<UserLookupDto> Users { get; set; }
}