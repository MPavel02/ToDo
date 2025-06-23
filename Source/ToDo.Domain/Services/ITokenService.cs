using ToDo.Domain.Entities;

namespace ToDo.Domain.Services;

public interface ITokenService
{
    string GenerateToken(User user);
}