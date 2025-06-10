using ToDo.Domain.Entities;
using ToDo.Domain.Models.Users;

namespace ToDo.Domain.Mappers;

public static class UsersMapper
{
    public static UserDto ToDto(this UserEntity entity)
    {
        return new UserDto
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }
        
    public static UserEntity ToEntity(this CreateUserDto dto)
    {
        return new UserEntity { Name = dto.Name };
    }
}