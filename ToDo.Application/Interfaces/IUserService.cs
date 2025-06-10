using ToDo.Domain.Models.Users;

namespace ToDo.Application.Interfaces;

public interface IUserService
{
    Task<UserDto> Create(CreateUserDto userDto);
    Task<List<UserDto>> GetAll();
    Task<UserDto> GetByID(Guid userID);
    Task<UserDto> Update(UserDto userDto);
    Task<UserDto> Delete(Guid userID);
}