using Microsoft.AspNetCore.Identity;
using OnlineShop.API.Extensions;
using OnlineShop.Domain.Auth;
using OnlineShop.Infrastructure.Persistance.Contexts;
using OnlineShop.Infrastructure.Persistance.DataSeed;

namespace OnlineShop.API.Extensions
{
    public static class HostExtensions
    {
        public static async Task SeedData(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<OnlineShopDbContext>();
                    var userManager = services.GetRequiredService<UserManager<User>>();

                    await SeedFacade.SeedData(context, userManager);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occured during migration");
                }
            }
        }
    }
}
