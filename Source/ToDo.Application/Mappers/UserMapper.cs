using ToDo.Application.Models.User;
using ToDo.Domain.DomainEntities;

namespace ToDo.Application.Mappers;

public static class UserMapper
{
    public static UserDto Map(this UserDomain userDomain)
    {
        return new UserDto
        {
            ID = userDomain.ID,
            Username = userDomain.Username.Value,
            Role = userDomain.Role,
            CreatedAt = userDomain.CreatedAt,
            UpdatedAt = userDomain.UpdatedAt,
            Notes = userDomain.Notes.Map()
        };
    }
    
    public static UserLookupDto MapToLookup(this UserDomain userDomain)
    {
        return new UserLookupDto
        {
            ID = userDomain.ID,
            Username = userDomain.Username.Value,
            Role = userDomain.Role,
            CreatedAt = userDomain.CreatedAt,
            UpdatedAt = userDomain.UpdatedAt
        };
    }
}