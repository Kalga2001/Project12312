using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Auth;
using OnlineShop.Infrastructure.Persistance.Contexts;

namespace OnlineShop.Infrastructure.Persistance.DataSeed
{
    public class SeedFacade
    {
        public static async Task SeedData(OnlineShopDbContext onlineShopDbContext, UserManager<User> userManager)
        {
            onlineShopDbContext.Database.Migrate();

            await BrandsSeed.Seed(onlineShopDbContext);
            await ProductsSeed.Seed(onlineShopDbContext);
            await TypesSeed.Seed(onlineShopDbContext);
            await UsersSeed.Seed(userManager);
        }
    }
}
