using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Application.Models.Settings;
using ToDo.Application.Services;
using ToDo.Domain.Services;

namespace ToDo.Application.ServiceExtensions;

/// <summary>
/// Расширение для добавления сервисов токена.
/// </summary>
public static class TokenServiceExtensions
{
    /// <summary>
    /// Название секции настроек токена.
    /// </summary>
    private const string TokenConfigurationSectionName = "Authentication";
    
    public static IServiceCollection AddTokenServices(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection(TokenConfigurationSectionName));
        
        return services.AddScoped<ITokenService, JwtTokenService>();
    }
}