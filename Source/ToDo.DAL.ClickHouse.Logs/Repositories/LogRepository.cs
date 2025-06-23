using Microsoft.EntityFrameworkCore;
using ToDo.DAL.ClickHouse.Logs.Persistence;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;

namespace ToDo.DAL.ClickHouse.Logs.Repositories;

public class LogRepository(LogsDbContext context) : ILogRepository
{
    public async Task<IList<LogEntry>> GetAllBeforeDateAsync(DateTime receiptDate, CancellationToken cancellationToken = default)
    {
        return await context.Logs
            .Where(l => l.Timestamp < receiptDate)
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task AddAsync(LogEntry entity, CancellationToken cancellationToken = default)
    {
        await context.Logs.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAllBeforeDateAsync(DateTime deletionDate, CancellationToken cancellationToken = default)
    {
        var entities = context.Logs.Where(l => l.Timestamp < deletionDate);
        context.Logs.RemoveRange(entities);
        await context.SaveChangesAsync(cancellationToken);
    }
}