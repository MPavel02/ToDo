using ToDo.Domain.Models;
using ToDo.Domain.Models.Users;

namespace ToDo.Application.Interfaces;

public interface IUserService
{
    Task<UserDto> Create(CreateUserDto userDto);
    Task<List<UserDto>> GetAll();
}