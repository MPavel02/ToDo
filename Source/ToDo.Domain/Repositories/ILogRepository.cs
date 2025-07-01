using ToDo.Domain.DomainEntities;

namespace ToDo.Domain.Repositories;

public interface ILogRepository
{
    Task<IEnumerable<LogEntryDomain>> GetAllBeforeDateAsync(DateTime receiptDate, CancellationToken cancellationToken = default);
    Task AddAsync(LogEntryDomain entity, CancellationToken cancellationToken = default);
    Task DeleteAllBeforeDateAsync(DateTime deletionDate, CancellationToken cancellationToken = default);
}