using ToDo.Domain.Enums;

namespace ToDo.Domain.Services;

public interface ILoggerService
{
    void LogAsync(
        LogLevel logLevel,
        string message,
        Exception? exception = null);
}