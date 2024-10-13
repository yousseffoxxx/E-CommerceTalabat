using Domain.Contracts;
using Persistence.Data;
using Persistence.Repositories;
using Persistence;
using E_Commerce.API.Factories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

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

            services.AddSingleton<ConnectionMultiplexer>(_ => ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis")));

            return services;
        }
    }
}