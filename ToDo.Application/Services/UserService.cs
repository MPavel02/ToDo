using Microsoft.EntityFrameworkCore;
using ToDo.Application.Interfaces;
using ToDo.DAL;
using ToDo.Domain.Entities;
using ToDo.Domain.Mappers;
using ToDo.Domain.Models.Users;

namespace ToDo.Application.Services;

public class UserService(ToDoDbContext context) : IUserService
{
    public async Task<UserDto> Create(CreateUserDto userDto)
    {
        var entity = new UserEntity { Name = userDto.Name };
        var result = await context.Users.AddAsync(entity);
        await context.SaveChangesAsync();

        return result.Entity.ToDto();
    }

    public async Task<List<UserDto>> GetAll()
    {
        var users = await context.Users.ToListAsync();
        
        return users.Select(u => u.ToDto()).ToList();
    }
}