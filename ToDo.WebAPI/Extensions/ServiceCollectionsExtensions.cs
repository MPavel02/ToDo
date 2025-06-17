using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ToDo.DAL.Persistence;
using ToDo.DAL.Repositories;
using ToDo.Domain.Repositories;

namespace ToDo.WebAPI.Extensions;

public static class ServiceCollectionsExtensions
{
    /// <summary>
    /// Параметр в файле настроек, отвечающий за строку подключения к базе данных.
    /// </summary>
    private const string SettingsDatabaseParam = "ToDo";
    
    public static WebApplicationBuilder AddSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "ToDo API", 
                Version = "v1"
            });
            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        return builder;
    }
    
    public static WebApplicationBuilder AddData(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ToDoDbContext>(opt =>
            opt.UseNpgsql(builder.Configuration.GetConnectionString(SettingsDatabaseParam)));

        return builder;
    }
    
    public static WebApplicationBuilder AddMediatr(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddMediatR(cfg => cfg
                .RegisterServicesFromAssembly(typeof(Application.AssemblyReference).Assembly));

        return builder;
    }
    
    public static WebApplicationBuilder AddApplicationServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<INoteRepository, NoteRepository>();

        return builder;
    }
}