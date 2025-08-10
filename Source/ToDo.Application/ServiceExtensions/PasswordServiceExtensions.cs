using Microsoft.Extensions.DependencyInjection;
using ToDo.Application.Services;
using ToDo.Domain.Services;

namespace ToDo.Application.ServiceExtensions;

/// <summary>
/// Расширение для добавления сервисов паролей.
/// </summary>
public static class PasswordServiceExtensions
{
    public static IServiceCollection AddPasswordServices(this IServiceCollection services)
    {
        return services
            .AddScoped<IPasswordHasher, BCryptPasswordHasher>();
    }
}