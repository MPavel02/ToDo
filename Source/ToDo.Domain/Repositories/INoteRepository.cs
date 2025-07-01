using ToDo.Domain.DomainEntities;

namespace ToDo.Domain.Repositories;

public interface INoteRepository
{
    Task<NoteDomain?> GetByIDAsync(Guid ID, CancellationToken cancellationToken = default);
    Task<IEnumerable<NoteDomain>> GetAllByIDAsync(Guid userID, CancellationToken cancellationToken = default);
    Task AddAsync(NoteDomain entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(NoteDomain entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid ID, CancellationToken cancellationToken = default);
}