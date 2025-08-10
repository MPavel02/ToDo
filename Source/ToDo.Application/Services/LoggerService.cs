using ToDo.Domain.BackgroundServices;
using ToDo.Domain.DomainEntities;
using ToDo.Domain.Enums;
using ToDo.Domain.Extensions;
using ToDo.Domain.Services;

namespace ToDo.Application.Services;

internal class LoggerService(ILogQueue logQueue) : ILoggerService
{
    public void LogAsync(
        LogLevel logLevel,
        string message,
        Exception? exception = null)
    {
        var log = LogEntryDomain.Create(logLevel, message, exception?.ToText());

        logQueue.Enqueue(log);
    }
}