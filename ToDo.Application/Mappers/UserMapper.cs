using ToDo.Application.Users.Commands.CreateUser;
using ToDo.Application.Users.Commands.UpdateUser;
using ToDo.Domain.Entities;
using ToDo.Domain.Models.User;

namespace ToDo.Application.Mappers;

public static class UserMapper
{
    public static UserModel Map(this User entity) =>
        new()
        {
            ID = entity.ID,
            Name = entity.Name,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt
        };

    public static UserLookupDto MapToLookup(this User entity) =>
        new()
        {
            ID = entity.ID,
            Name = entity.Name
        };

    public static CreateUserCommand Map(this CreateUserDto dto) =>
        new()
        {
            Name = dto.Name
        };

    public static UpdateUserCommand Map(this UpdateUserDto dto) =>
        new()
        {
            ID = dto.ID,
            Name = dto.Name
        };
}