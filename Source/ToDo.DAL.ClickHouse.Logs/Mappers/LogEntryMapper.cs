using ToDo.DAL.ClickHouse.Logs.Models;
using ToDo.Domain.DomainEntities;

namespace ToDo.DAL.ClickHouse.Logs.Mappers;

internal static class LogEntryMapper
{
    public static LogEntryDomain Map(this LogEntry log)
    {
        return LogEntryDomain.LoadFromDb(
            log.ID,
            log.Timestamp,
            log.LogLevel,
            log.Message,
            log.Exception);
    }
    
    public static IEnumerable<LogEntryDomain> Map(this IEnumerable<LogEntry> logs)
    {
        return logs.Select(Map);
    }
    
    public static LogEntry Map(this LogEntryDomain log)
    {
        return new LogEntry
        {
            ID = log.ID,
            Timestamp = log.Timestamp,
            LogLevel = log.LogLevel,
            Message = log.Message,
            Exception = log.Exception
        };
    }
}