using ToDo.Domain.Enums;

namespace ToDo.Domain.DomainEntities;

public class LogEntryDomain : BaseEntityDomain
{
    private LogEntryDomain(Guid ID, DateTime timestamp, LogLevel logLevel, string message, string? exception = null)
        : base(ID)
    {
        Timestamp = timestamp;
        LogLevel = logLevel;
        Message = message;
        Exception = exception;
    }
    
    public static LogEntryDomain Create(
        LogLevel logLevel,
        string message,
        string? exception) 
        => new(Guid.NewGuid(), DateTime.UtcNow, logLevel, message, exception);
    
    public static LogEntryDomain LoadFromDb(
        Guid ID,
        DateTime timestamp,
        LogLevel logLevel,
        string message,
        string? exception)
    {
        return new LogEntryDomain(
            ID,
            timestamp,
            logLevel,
            message,
            exception);
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