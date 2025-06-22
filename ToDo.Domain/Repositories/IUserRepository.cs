using ToDo.Domain.Entities;

namespace ToDo.Domain.Repositories;

public interface IUserRepository
{
    Task<User?> GetByIDAsync(Guid ID, CancellationToken cancellationToken = default);
    Task<User?> GetByNameAsync(string username, CancellationToken cancellationToken = default);
    Task<IList<User>> GetAllAsync(CancellationToken cancellationToken = default);
    Task AddAsync(User entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(User entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(User entity, CancellationToken cancellationToken = default);
}