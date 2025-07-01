using ToDo.DAL.Core.Entities;
using ToDo.Domain.Enums;

namespace ToDo.DAL.ClickHouse.Logs.Models;

/// <summary>
/// Модель лога.
/// </summary>
public sealed class LogEntry : BaseEntity
{
    public DateTime Timestamp { get; set; }
    public LogLevel LogLevel { get; set; }
    public required string Message { get; set; }
    public string? Exception { get; set; }
}