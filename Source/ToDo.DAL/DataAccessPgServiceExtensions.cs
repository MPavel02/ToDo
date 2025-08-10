using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDo.DAL.Persistence;
using ToDo.DAL.Repositories;
using ToDo.Domain.Repositories;

namespace ToDo.DAL;

/// <summary>
/// Расширение для добавления сервисов базы данных Postgres.
/// </summary>
public static class DataAccessPgServiceExtensions
{
    /// <summary>
    /// Название ключа строки подключения к Postgres базе данных.
    /// </summary>
    private const string DataAccessPgSectionName = "PostgresToDoConnection";
    
    public static IServiceCollection AddDataAccessPgServices(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddDbContext<ToDoDbContext>(opt =>
            opt.UseNpgsql(configuration.GetConnectionString(DataAccessPgSectionName)));
        
        return services
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<INoteRepository, NoteRepository>();
    }
}