using Microsoft.EntityFrameworkCore;
using ToDo.Application.Interfaces;
using ToDo.DAL;
using ToDo.Domain.Entities;
using ToDo.Domain.Exceptions;
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
    
    public async Task<UserDto> GetByID(Guid userID)
    {
        var user = await context.Users.FirstOrDefaultAsync(user => user.ID == userID);

        if (user is null)
        {
            throw new NotFoundException($"Пользователь с ID = {userID} не существует.");
        }
        
        return user.ToDto();
    }

    public async Task<List<UserDto>> GetAll()
    {
        var users = await context.Users.ToListAsync();
        return users.Select(u => u.ToDto()).ToList();
    }

    public async Task<UserDto> Update(UserDto userDto)
    {
        var user = await context.Users.FirstOrDefaultAsync(user => user.ID == userDto.ID);

        if (user is null)
        {
            throw new NotFoundException($"Пользователь с ID = {userDto.ID} не существует.");
        }
        
        user.Name = userDto.Name;
        await context.SaveChangesAsync();
        
        return user.ToDto();
    }

    public async Task<UserDto> Delete(Guid userID)
    {
        var user = await context.Users.FirstOrDefaultAsync(user => user.ID == userID);

        if (user is null)
        {
            throw new NotFoundException($"Пользователь с ID = {userID} не существует.");
        }
        
        context.Users.Remove(user);
        await context.SaveChangesAsync();
        
        return user.ToDto();
    }
}