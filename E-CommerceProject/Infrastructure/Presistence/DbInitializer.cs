using Domain.Entities.OrderEntities;
using Domain.Entities.ProductEntities;
using Domain.Entities.UserEntities;
using Microsoft.AspNetCore.Identity;
using Persistence.Data;
using System.Text.Json;

namespace Persistence
{
    public class DbInitializer : IDbInitializer
    {
        private readonly StoreContext _storeContext;
        private readonly UserManager<User> _userManger;
        private readonly RoleManager<IdentityRole> _roleManger;

        public DbInitializer(StoreContext storeContext, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _storeContext = storeContext;
            _roleManger = roleManager;
            _userManger = userManager;
        }

        public async Task InitializeAsync()
        {
            try
            {
                // Create DataBase if it doesn't Exist & Applying any Pending Migrations
                if(_storeContext.Database.GetPendingMigrations().Any())
                    await _storeContext.Database.MigrateAsync();

                // Apply Data seeding
                if (!_storeContext.ProductTypes.Any())
                {
                    // Read Types from Files
                    var typesData = await File.ReadAllTextAsync(@"..\Infrastructure\Presistence\Data\Seeding\types.json");
                
                    // Transform into C# objects
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    // Add to DB & save Changes
                    if(types is not null && types.Any())
                    {
                        await _storeContext.ProductTypes.AddRangeAsync(types);
                        await _storeContext.SaveChangesAsync();
                    }
                }

                if (!_storeContext.ProductBrands.Any())
                {
                    // Read Types from Files
                    var brandsData = await File.ReadAllTextAsync(@"..\Infrastructure\Presistence\Data\Seeding\brands.json");
                
                    // Transform into C# objects
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    // Add to DB & save Changes
                    if(brands is not null && brands.Any())
                    {
                        await _storeContext.ProductBrands.AddRangeAsync(brands);
                        await _storeContext.SaveChangesAsync();
                    }
                }

                if (!_storeContext.Products.Any())
                {
                    // Read Types from Files
                    var productsData = await File.ReadAllTextAsync(@"..\Infrastructure\Presistence\Data\Seeding\products.json");
                
                    // Transform into C# objects
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    // Add to DB & save Changes
                    if(products is not null && products.Any())
                    {
                        await _storeContext.Products.AddRangeAsync(products);
                        await _storeContext.SaveChangesAsync();
                    }
                }

                if (!_storeContext.DeliveryMethods.Any())
                {
                    // Read Types from Files
                    var Data = await File.ReadAllTextAsync(@"..\Infrastructure\Presistence\Data\Seeding\delivery.json");
                
                    // Transform into C# objects
                    var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(Data);

                    // Add to DB & save Changes
                    if(methods is not null && methods.Any())
                    {
                        await _storeContext.DeliveryMethods.AddRangeAsync(methods);
                        await _storeContext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task InitializeIdentityAsync()
        {
            // seed Default roles
            if (!_roleManger.Roles.Any())
            {
                await _roleManger.CreateAsync(new IdentityRole("SuperAdmin"));
                await _roleManger.CreateAsync(new IdentityRole("Admin"));
            }
            // Seed Default Users

            if (!_userManger.Users.Any())
            {
                var superAdminUser = new User
                {
                    DisplayName = "super Admin User",
                    Email = "superAdminUser@Gmail.com",
                    UserName = "superAdminUser",
                    PhoneNumber = "123456789",
                };

                var AdminUser = new User
                {
                    DisplayName = "Admin User",
                    Email = "AdminUser@Gmail.com",
                    UserName = "AdminUser",
                    PhoneNumber = "24682468",
                };

                await _userManger.CreateAsync(superAdminUser, "password");
                await _userManger.CreateAsync(AdminUser, "password");

                await _userManger.AddToRoleAsync(superAdminUser, "SuperAdmin");
                await _userManger.AddToRoleAsync(AdminUser, "Admin");
            }
        }
    }
}