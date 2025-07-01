using ToDo.DAL.Entities;
using ToDo.Domain.DomainEntities;
using ToDo.Domain.ValueObjects;

namespace ToDo.DAL.Mappers;

public static class UserMapper
{
    public static UserDomain Map(this User user)
    {
        return UserDomain.LoadFromDb(
            user.ID,
            user.CreatedAt,
            user.UpdatedAt,
            Username.From(user.Username),
            user.PasswordHash,
            user.Role,
            user.Notes.Map().ToList());
    }

    public static IEnumerable<UserDomain> Map(this IEnumerable<User> users)
    {
        return users.Select(Map);
    }
    
    public static User Map(this UserDomain user)
    {
        return new User
        {
            ID = user.ID,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt,
            Username = user.Username.Value,
            PasswordHash = user.PasswordHash,
            Role = user.Role,
            Notes = user.Notes.Map().ToList()
        };
    }
    
    public static void Map(UserDomain source, User target)
    {
        target.UpdatedAt = source.UpdatedAt;
        
        target.Username = source.Username.Value;
        target.PasswordHash = source.PasswordHash;
        
        target.Notes = source.Notes.Map().ToList();
    }
}