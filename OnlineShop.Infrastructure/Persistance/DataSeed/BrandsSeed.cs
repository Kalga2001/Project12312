using OnlineShop.Domain;
using OnlineShop.Infrastructure.Persistance.Contexts;

namespace OnlineShop.Infrastructure.Persistance.DataSeed
{
    public class BrandsSeed
    {
        public static async Task Seed(OnlineShopDbContext context)
        {
            if (!context.ProductBrands.Any())
            {
                var br1 = new ProductBrand()
                {
                    Id = 1,
                    Name="Angular"
                    
                };

                var br2 = new ProductBrand()
                {
                    Id = 2,
                    Name = "NetCore"

                };

                var br3 = new ProductBrand()
                {
                    Id = 3,
                    Name = "VS Code"

                };

                var br4 = new ProductBrand()
                {
                    Id = 4,
                    Name = "React"

                };

                var br5 = new ProductBrand()
                {
                    Id = 5,
                    Name = "TypeScript"

                };

                var br6 = new ProductBrand()
                {
                    Id = 6,
                    Name = "Redis"

                };

                context.ProductBrands.Add(br1);
                context.ProductBrands.Add(br2);
                context.ProductBrands.Add(br3);
                context.ProductBrands.Add(br4);
                context.ProductBrands.Add(br5);
                context.ProductBrands.Add(br6);


                await context.SaveChangesAsync();
            }
        }
    }
}
