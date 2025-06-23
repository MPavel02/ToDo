using ToDo.Domain.Entities;

namespace ToDo.Domain.BackgroundServices;

public interface ILogQueue
{
    void Enqueue(LogEntry log);
    bool TryDequeue(out LogEntry? log);
}