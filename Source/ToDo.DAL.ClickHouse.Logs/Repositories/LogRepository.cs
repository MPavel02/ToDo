using Microsoft.EntityFrameworkCore;
using ToDo.DAL.ClickHouse.Logs.Mappers;
using ToDo.DAL.ClickHouse.Logs.Persistence;
using ToDo.Domain.DomainEntities;
using ToDo.Domain.Repositories;

namespace ToDo.DAL.ClickHouse.Logs.Repositories;

internal class LogRepository(LogsDbContext context) : ILogRepository
{
    public async Task<IEnumerable<LogEntryDomain>> GetAllBeforeDateAsync(DateTime receiptDate, CancellationToken cancellationToken = default)
    {
        var logs = await context.Logs
            .Where(l => l.Timestamp < receiptDate)
            .ToListAsync(cancellationToken: cancellationToken);
        
        return logs.Map();
    }

    public async Task AddAsync(LogEntryDomain entity, CancellationToken cancellationToken = default)
    {
        await context.Logs.AddAsync(entity.Map(), cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAllBeforeDateAsync(DateTime deletionDate, CancellationToken cancellationToken = default)
    {
        var entities = context.Logs.Where(l => l.Timestamp < deletionDate);
        context.Logs.RemoveRange(entities);
        await context.SaveChangesAsync(cancellationToken);
    }
}