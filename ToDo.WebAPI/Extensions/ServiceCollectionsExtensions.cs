using System.Text;
using ClickHouse.EntityFrameworkCore.Extensions;
using FluentValidation;
using MediatR;
using MediatR.Extensions.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ToDo.Application.BackgroundServices;
using ToDo.Application.Models.Settings;
using ToDo.Application.Services;
using ToDo.DAL.ClickHouse.Logs.Persistence;
using ToDo.DAL.ClickHouse.Logs.Repositories;
using ToDo.DAL.Persistence;
using ToDo.DAL.Repositories;
using ToDo.Domain.BackgroundServices;
using ToDo.Domain.Enums;
using ToDo.Domain.Repositories;
using ToDo.Domain.Services;

namespace ToDo.WebAPI.Extensions;

public static class ServiceCollectionsExtensions
{
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
    
    public static WebApplicationBuilder AddBearerAuthentication(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    
                    ValidIssuer = builder.Configuration["Authentication:Issuer"],
                    ValidAudience = builder.Configuration["Authentication:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["Authentication:TokenPrivateKey"]!))
                };
            });
        
        builder.Services.AddAuthorizationBuilder()
            .AddPolicy(nameof(RoleTypes.Admin), policy => policy.RequireRole(RoleTypes.Admin.ToString()))
            .AddPolicy(nameof(RoleTypes.User), policy => policy.RequireRole(RoleTypes.User.ToString()));
        
        return builder;
    }
    
    public static WebApplicationBuilder AddOptions(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Authentication"));

        return builder;
    }
    
    public static WebApplicationBuilder AddDataAccess(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ToDoDbContext>(opt =>
            opt.UseNpgsql(builder.Configuration.GetConnectionString("PostgresToDoConnection")));
        
        builder.Services.AddDbContext<LogsDbContext>(opt =>
            opt.UseClickHouse(builder.Configuration.GetConnectionString("ClickHouseToDoLogsConnection")));
        
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<INoteRepository, NoteRepository>();
        builder.Services.AddScoped<ILogRepository, LogRepository>();

        return builder;
    }
    
    public static WebApplicationBuilder AddMediatr(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddMediatR(cfg => cfg
                .RegisterServicesFromAssembly(typeof(Application.AssemblyReference).Assembly));
        
        builder.Services.AddValidatorsFromAssemblyContaining<Application.AssemblyReference>();
        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return builder;
    }
    
    public static WebApplicationBuilder AddApplicationServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
        builder.Services.AddScoped<ITokenService, JwtTokenService>();
        builder.Services.AddScoped<ILoggerService, LoggerService>();
        
        return builder;
    }
    
    public static WebApplicationBuilder AddBackgroundServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<ILogQueue, LogQueue>();
        builder.Services.AddHostedService<LoggerBackgroundService>();
            
        return builder;
    }
}