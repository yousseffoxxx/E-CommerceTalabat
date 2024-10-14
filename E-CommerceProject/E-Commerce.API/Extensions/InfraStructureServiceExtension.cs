using Domain.Contracts;
using Persistence.Data;
using Persistence.Repositories;
using Persistence;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Persistence.Identity;

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

            return services;
        }
    }     
}