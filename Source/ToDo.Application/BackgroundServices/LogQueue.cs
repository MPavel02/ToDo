using System.Collections.Concurrent;
using ToDo.Domain.BackgroundServices;
using ToDo.Domain.DomainEntities;

namespace ToDo.Application.BackgroundServices;

internal class LogQueue : ILogQueue
{
    private readonly ConcurrentQueue<LogEntryDomain> _queue = new();

    public void Enqueue(LogEntryDomain log) => _queue.Enqueue(log);

    public bool TryDequeue(out LogEntryDomain? log) => _queue.TryDequeue(out log);
}