using System.Text;
using BlazorAuth.Api.Repositories;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace BlazorAuth.Api.Extensions;

public static class ApiConfiguration
{
    public static IServiceCollection AddJWTAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = "Bearer";
            options.DefaultChallengeScheme = "Bearer";
        }).AddJwtBearer(conf =>
        {
            conf.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
            };
        });

        return services;
    }

    public static IServiceCollection AddCORSConfiguration(this IServiceCollection services)
    {
        services.AddCors(opt => opt.AddPolicy("local", conf =>
        {
            conf.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        }));

        return services;
    }

    public static IServiceCollection AddDIContainerConfiguration(this IServiceCollection services)
    {
        services.AddSingleton<IUserRepository, UserRepository>();
        services.AddSingleton<IBookRepository, BookRepository>();

        return services;
    }

    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "Books API", Version = "v1" });

            // Configure Swagger to use JWT tokens for authorization
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                    new string[] {}
                }
            });
        });

        return services;
    }
}