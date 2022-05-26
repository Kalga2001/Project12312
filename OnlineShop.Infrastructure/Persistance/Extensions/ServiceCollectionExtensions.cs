using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Application.Common.Interfaces.Repositories;
using OnlineShop.Domain.Auth;
using OnlineShop.Infrastructure.Identity;
using OnlineShop.Infrastructure.Persistance.Contexts;
using OnlineShop.Infrastructure.Persistance.Repositories;

namespace OnlineShop.Infrastructure.Persistance.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OnlineShopDbContext>(optionBuilder =>
            {
                optionBuilder.UseSqlServer(configuration.GetConnectionString("OnlineShopConnection"));
            });

            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequiredLength = 8;
            })
            .AddEntityFrameworkStores<OnlineShopDbContext>();

            services.AddScoped<EFCoreRepository, EFCoreRepository>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<ITokenService, TokenService>();

            return services;
        }
    }

}
