using Microsoft.Extensions.DependencyInjection;
using ToDo.Application.BackgroundServices;
using ToDo.Application.Services;
using ToDo.Domain.BackgroundServices;
using ToDo.Domain.Services;

namespace ToDo.Application.ServiceExtensions;

/// <summary>
/// Расширение для добавления сервисов логгера.
/// </summary>
public static class LoggerServiceExtensions
{
    public static IServiceCollection AddLoggerServices(this IServiceCollection services)
    {
        return services
            .AddScoped<ILoggerService, LoggerService>()
            .AddSingleton<ILogQueue, LogQueue>()
            .AddHostedService<LoggerBackgroundService>();
    }
}