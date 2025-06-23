using ToDo.Domain.Enums;

namespace ToDo.Domain.Entities;

public class LogEntry : BaseEntity
{
    public LogEntry(Guid ID, DateTime timestamp, LogLevel logLevel, string message, string? exception = null)
        : base(ID)
    {
        Timestamp = timestamp;
        LogLevel = logLevel;
        Message = message;
        Exception = exception;
    }
    
    /// <summary>
    /// Время записи лога.
    /// </summary>
    public DateTime Timestamp { get; private set; }
    
    /// <summary>
    /// Уровень логирования.
    /// </summary>
    public LogLevel LogLevel { get; private set; }
    
    /// <summary>
    /// Сообщение.
    /// </summary>
    public string Message { get; private set; }
    
    /// <summary>
    /// Текст исключения.
    /// </summary>
    public string? Exception { get; private set; }
}