using ToDo.Application.Models.User;
using ToDo.Domain.Entities;

namespace ToDo.Application.Mappers;

public static class UserMapper
{
    public static UserDto Map(this User user)
    {
        return new UserDto
        {
            ID = user.ID,
            Name = user.Name.Value,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt,
            Notes = user.Notes.Map()
        };
    }
    
    public static UserLookupDto MapToLookup(this User user)
    {
        return new UserLookupDto
        {
            ID = user.ID,
            Name = user.Name.Value,
            Notes = user.Notes.MapToLookup()
        };
    }
}