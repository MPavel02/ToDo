using ToDo.Domain.Entities;

namespace ToDo.Domain.Repositories;

public interface IUserRepository
{
    Task<User?> GetByIDAsync(Guid ID, CancellationToken cancellationToken = default);
    Task<IList<User>> GetAllAsync(CancellationToken cancellationToken = default);
    Task AddAsync(User user, CancellationToken cancellationToken = default);
    Task UpdateAsync(User user, CancellationToken cancellationToken = default);
    Task DeleteAsync(User user, CancellationToken cancellationToken = default);
}