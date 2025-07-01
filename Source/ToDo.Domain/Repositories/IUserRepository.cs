using ToDo.Domain.DomainEntities;
using ToDo.Domain.ValueObjects;

namespace ToDo.Domain.Repositories;

public interface IUserRepository
{
    Task<UserDomain?> GetByIDAsync(Guid ID, CancellationToken cancellationToken = default);
    Task<UserDomain?> GetByNameAsync(Username username, CancellationToken cancellationToken = default);
    Task<IEnumerable<UserDomain>> GetAllAsync(CancellationToken cancellationToken = default);
    Task AddAsync(UserDomain entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(UserDomain entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid ID, CancellationToken cancellationToken = default);
}