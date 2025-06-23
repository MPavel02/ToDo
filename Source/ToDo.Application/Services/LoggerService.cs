using ToDo.Domain.BackgroundServices;
using ToDo.Domain.Entities;
using ToDo.Domain.Enums;
using ToDo.Domain.Extensions;
using ToDo.Domain.Services;

namespace ToDo.Application.Services;

public class LoggerService(ILogQueue logQueue) : ILoggerService
{
    public void LogAsync(
        LogLevel logLevel,
        string message,
        Exception? exception = null)
    {
        var log = new LogEntry(
            Guid.NewGuid(),
            DateTime.UtcNow,
            logLevel,
            message,
            exception?.ToText());

        logQueue.Enqueue(log);
    }
}