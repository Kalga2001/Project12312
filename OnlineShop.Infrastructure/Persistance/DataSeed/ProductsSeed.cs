using OnlineShop.Domain;
using OnlineShop.Infrastructure.Persistance.Contexts;

namespace OnlineShop.Infrastructure.Persistance.DataSeed
{
    public class ProductsSeed
    {
        public static async Task Seed(OnlineShopDbContext context)
        {
            if (!context.Products.Any())
            {
                var p1 = new Product()
                {
                   Name= "Angular Speedster Board 2000",
                   Description= "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. " +
                   "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                   Price= 200,
                   PictureUrl= "images/products/sb-ang1.png",
                   ProductTypeId= 1,
                   ProductBrandId= 1
                };

                var p2 = new Product()
                {
                     Name= "Green Angular Board 3000",
                     Description= "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.",
                     Price= 150,
                     PictureUrl= "images/products/sb-ang2.png",
                     ProductTypeId= 1,
                     ProductBrandId= 1
                };

                await context.SaveChangesAsync();
            }
        }
    }
}
