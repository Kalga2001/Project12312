using Microsoft.AspNetCore.Identity;
using OnlineShop.Domain.Auth;

namespace OnlineShop.Infrastructure.Persistance.DataSeed
{
    public class UsersSeed
    {
        public static async Task Seed(UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new User()
                {
                    UserName = "Misha2001",
                    Email = "mishakalga@gmail.com",
                };

                await userManager.CreateAsync(user, "Qwerty1!");
            }
        }
    }
}
