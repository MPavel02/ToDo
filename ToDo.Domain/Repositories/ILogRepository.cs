using ToDo.Domain.Entities;

namespace ToDo.Domain.Repositories;

public interface ILogRepository
{
    Task<IList<LogEntry>> GetAllBeforeDateAsync(DateTime receiptDate, CancellationToken cancellationToken = default);
    Task AddAsync(LogEntry entity, CancellationToken cancellationToken = default);
    Task DeleteAllBeforeDateAsync(DateTime deletionDate, CancellationToken cancellationToken = default);
}