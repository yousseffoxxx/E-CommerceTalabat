using Domain.Contracts;
using Persistence.Data;
using Persistence.Repositories;
using Persistence;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Persistence.Identity;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Domain.Entities.UserEntities;

namespace E_Commerce.API.Extensions
{
    public static class InfraStructureServiceExtension
    {
        public static IServiceCollection AddInfraStructureServices(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddScoped<IDbInitializer, DbInitializer>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBasketRepository, BasketRepository>();

            services.AddDbContext<StoreContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultSQLConnection"));
            });
            services.AddDbContext<StoreIdentityContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("IdentitySQLConnection"));
            });

            services.AddSingleton<IConnectionMultiplexer>(_ => ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis")));
            services.ConfigureIdentityService();
            services.ConfigureJwtService(configuration);

            return services;
        }
    
        public static IServiceCollection ConfigureIdentityService(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 8;

                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<StoreIdentityContext>();

            return services;
        }
    
        public static IServiceCollection ConfigureJwtService(this IServiceCollection services , IConfiguration configuration)
        {
            var jwtOptions = configuration.GetSection("JwtOptions").Get<JwtOptions>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwtOptions.Issure,
                    ValidAudience = jwtOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey))
                };
            });

            services.AddAuthorization();

            return services;
        }
    }     
}