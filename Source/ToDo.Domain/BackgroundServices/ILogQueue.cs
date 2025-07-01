using ToDo.Domain.DomainEntities;

namespace ToDo.Domain.BackgroundServices;

public interface ILogQueue
{
    void Enqueue(LogEntryDomain log);
    bool TryDequeue(out LogEntryDomain? log);
}