using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToDo.Domain.BackgroundServices;
using ToDo.Domain.Repositories;

namespace ToDo.Application.BackgroundServices;

public class LoggerBackgroundService(ILogQueue logQueue, IServiceProvider serviceProvider) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            while (logQueue.TryDequeue(out var log) && log is not null)
            {
                using var scope = serviceProvider.CreateScope();
                var logRepository = scope.ServiceProvider.GetRequiredService<ILogRepository>();
                
                await logRepository.AddAsync(log, stoppingToken);
            }

            await Task.Delay(1000, stoppingToken);
        }
    }
}