using ToDo.Domain.Enums;

namespace ToDo.Application.Models.User;

public class UserLookupDto : BaseEntityDto
{
    public string Username { get; set; }
    public RoleTypes Role { get; set; }
}