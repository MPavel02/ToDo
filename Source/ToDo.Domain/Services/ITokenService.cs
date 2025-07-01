using ToDo.Domain.DomainEntities;

namespace ToDo.Domain.Services;

public interface ITokenService
{
    string GenerateToken(UserDomain userDomain);
}