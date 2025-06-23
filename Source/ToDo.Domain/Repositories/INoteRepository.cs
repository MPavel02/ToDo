using ToDo.Domain.Entities;

namespace ToDo.Domain.Repositories;

public interface INoteRepository
{
    Task<Note?> GetByIDAsync(Guid ID, CancellationToken cancellationToken = default);
    Task<IList<Note>> GetAllByIDAsync(Guid userID, CancellationToken cancellationToken = default);
    Task AddAsync(Note entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(Note entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(Note entity, CancellationToken cancellationToken = default);
}