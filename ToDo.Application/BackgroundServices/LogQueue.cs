using System.Collections.Concurrent;
using ToDo.Domain.BackgroundServices;
using ToDo.Domain.Entities;

namespace ToDo.Application.BackgroundServices;

public class LogQueue : ILogQueue
{
    private readonly ConcurrentQueue<LogEntry> _queue = new();

    public void Enqueue(LogEntry log) => _queue.Enqueue(log);

    public bool TryDequeue(out LogEntry? log) => _queue.TryDequeue(out log);
}