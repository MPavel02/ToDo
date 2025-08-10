using ClickHouse.EntityFrameworkCore.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDo.DAL.ClickHouse.Logs.Persistence;
using ToDo.DAL.ClickHouse.Logs.Repositories;
using ToDo.Domain.Repositories;

namespace ToDo.DAL.ClickHouse.Logs;

public static class DataAccessLogsClickHouseServiceExtensions
{
    /// <summary>
    /// Название ключа строки подключения к ClickHouse базе данных.
    /// </summary>
    private const string DataAccessClickHouseSectionName = "ClickHouseToDoLogsConnection";
    
    public static IServiceCollection AddDataAccessLogsClickHouseServices(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddDbContext<LogsDbContext>(opt =>
            opt.UseClickHouse(configuration.GetConnectionString("ClickHouseToDoLogsConnection")));
        
        return services.AddScoped<ILogRepository, LogRepository>();
    }
}